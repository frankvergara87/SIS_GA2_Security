using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SIS_Ga2.Business;
using SIS_Ga2.Entity;

using System.Net.Mail;
using System.Security.Cryptography;


namespace SIS_Ga2.Controllers
{
    public class SeguridadController : Controller
    {
        // GET: Seguridad
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Login()
        {
            try
            {
                //bool usaAzure = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["UsaAzure"].ToString());
                //bool usaAzure = false;
                //if (usaAzure) return RedirectToAction("Index", "Account");

                //else 
                return View();
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpPost]
        public ActionResult Login(string loginUsername, string loginPassword)
        {
            BEUsuario usuario = new BEUsuario();
            Sistema sistema = new Sistema();
            BEProyecto proyecto = new BEProyecto();
            //usuario.Usuario = Request.Params["loginUsername"].ToString();
            //usuario.Clave = Request.Params["loginPassword"].ToString();

            usuario.Usuario = loginUsername;
            usuario.Clave = loginPassword;


            SistemaBL autorizacion = new SistemaBL();
            usuario = autorizacion.login(usuario);

            
            if (usuario.Usuario != null)
            {
                AplicacionBL objBL = new AplicacionBL();
                List<Aplicacion> Aplicaciones = objBL.ListarAplicaciones();

                sistema.cuenta = usuario.Usuario;
                sistema.clave = usuario.Clave;
                sistema.idUsuario = usuario.Id_Usuario;

                Session.Add("sistema.usuario", usuario);
                Session.Add("sistema.general", sistema);
                Session.Add("proyecto.general", proyecto);

                return RedirectToAction("Aplicaciones", "Seguridad");
            }

            ViewBag.Mensaje = "Usuario/Contraseña incorrecto";
            return View();
            //return RedirectToAction("Login", "Seguridad");

        }


        [HttpGet]
        public ActionResult Aplicaciones()
        {
            BEUsuario usuario = Session["sistema.usuario"] as BEUsuario;
            if (usuario == null) return RedirectToAction("Login", "Seguridad");

            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpPost]
        public ActionResult Aplicaciones(int IdAplicacion)
        {
            try
            {
                BEUsuario usuario = (BEUsuario)Session["sistema.usuario"];
                Sistema sistema = (Sistema)Session["sistema.general"];
                BEProyecto proyecto = (BEProyecto)Session["proyecto.general"];
                sistema.idAplicacion = IdAplicacion;
                usuario.Aplicacion = IdAplicacion;


                DateTime hoy = DateTime.Now;
                proyecto.Fecha_Proyecto_Date = hoy.ToString("dd/MM/yyyy");

                switch (IdAplicacion)
                {
                    case 1:
                        sistema.TipoDiseno = "ASFALTO";
                        break;
                    case 2:
                        sistema.TipoDiseno = "ADOQUIN";
                        break;
                    case 3:
                        sistema.TipoDiseno = "CONCRETO";
                        break;
                }

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            System.Web.Security.FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Seguridad");
        }

        public JsonResult MostrarAplicaciones()
        {
            try
            {
                AplicacionBL objBLApp = new AplicacionBL();
                List<Aplicacion> objLista = objBLApp.ListarAplicaciones();
                TempData.Remove("Seguridad.Aplicaciones");
                TempData.Add("Seguridad.Aplicaciones", objLista);

                Autorizacionusuario usuario = (Autorizacionusuario)Session["sistema.usuario"];
                var resultado = "OK";
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("NO-OK:" + ex.Message);
            }

        }

        public string SendEmail(string EmailDestino)
        {
            string EmailOrigen = "geslid.consultoria@gmail.com";
            string Contrasena = "SVergara2014";

            string emailCript; 

            MailMessage oMailMessage = new MailMessage(EmailOrigen, EmailDestino, "Prueba - Recuperación de Contraseña",
                "<p>Correo de recuperación de contraseña</p><br>" +
                "<p>Version de prueba desarrollado por Frank Vergara.</p><br>" +
                "<p>Pendiente credenciales para su ACCESO al sistema SIS-Ga2.</p><br>"
                );
            oMailMessage.IsBodyHtml = true;

            SmtpClient oSmtpClient = new SmtpClient("smtp.gmail.com");
            oSmtpClient.EnableSsl = true;
            oSmtpClient.UseDefaultCredentials = false;

            oSmtpClient.Port = 587;
            oSmtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigen, Contrasena);

            oSmtpClient.Send(oMailMessage);
            oSmtpClient.Dispose();

            emailCript = HideEmail(EmailDestino);

            return emailCript;
        }


        public string HideEmail(string email)
        {
            //string email = "ejemplo123@ejemplo.com";
            string[] separada = email.Split('@');
            int inicio = 1; //Caracteres al inicio de la cadena que dejamos visibles
            int final = 3; //Caracteres al final de la cadena que dejamos visibles
            int longitud;
            if (separada[0].Length > inicio + final)
                longitud = separada[0].Length - final - inicio;
            else
                longitud = 1;

            separada[0] = separada[0].Remove(inicio, longitud).Insert(inicio, new string('*', longitud));
            email = String.Join("@", separada);

            return email;

        }




    }
}