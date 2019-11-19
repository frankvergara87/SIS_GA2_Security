using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SIS_Ga2.Business;
using SIS_Ga2.Entity;


namespace SIS_Ga2.Controllers
{
    public class SeguridadController : Controller
    {

        String Variable = "";
        // GET: Seguridad
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
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
    }
}