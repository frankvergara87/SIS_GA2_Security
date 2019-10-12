using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIS_Ga2.Entity;
using SIS_Ga2.Business;

namespace SIS_Ga2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
             
            BLDepartamento objblDepartamento = new BLDepartamento();
            List<SelectListItem> data_list = new List<SelectListItem>();
            data_list.AddRange(objblDepartamento.ListarDepartamentos(0).Select(a => new SelectListItem() { Text = a.Departamento.ToUpper(), Value = Convert.ToString(a.Id_Departamento) }));
            ViewData["ddlDepartamento"] = data_list;
            ViewData["ddlProvincia"] = new SelectList(new[] { "(Selecciona)" });
            ViewData["ddlDistrito"] = new SelectList(new[] { "(Selecciona)" });
            return View();
        }

        [HttpPost]
        public ActionResult FormRegistraProyecto()
        {

            Proyecto Proyecto = new Proyecto();
            ProyectosController RegistraProyecto = new ProyectosController();

            Proyecto.CodProyecto = Request.Form["frmProyecto"];
            Proyecto.NumDiseno = Request.Form["frmDiseno"];
            Proyecto.Reglamento = Request.Form["frmReglamento"];

            Session.Add("sistema.proyecto", Proyecto);


            return RedirectToAction("Index", "Diseno");
        }

        public JsonResult ListaProvincias(int idDepartamento)
        {
           
            BLProvincia objblProvincia = new BLProvincia();  
            List<BEProvincia> lobjProvincia = new List<BEProvincia>();
            lobjProvincia = objblProvincia.ListarProvincia(idDepartamento);   

            if (lobjProvincia == null)
                throw new ArgumentException("Departamento " + idDepartamento + " no es correcta");           
            return Json(lobjProvincia);
        }

        public JsonResult ListaDistritos(int idProvincia)
        {
                                  
            List<BEDistrito> lobjbeDistrito = new List<BEDistrito>();
            BLDistrito objDistrito = new BLDistrito();
 
            lobjbeDistrito = objDistrito.ListarDistrito(idProvincia);
            if (lobjbeDistrito == null)
                throw new ArgumentException("Distrito " + idProvincia + " no es correcta");
            return Json(lobjbeDistrito);
        }

        public JsonResult ListaUsuarios(Int32 strUsuario, String valorUsuario)
        {
            BLusuario objBLusuario = new BLusuario();
            List<BEUsuario> lobjBeUsuario = new List<BEUsuario>();

            lobjBeUsuario = objBLusuario.ListarUsuariosxPadre(strUsuario,valorUsuario);

            if (lobjBeUsuario == null)
                throw new ArgumentException("Usuarios " + strUsuario + " no es correcta");
            return Json(lobjBeUsuario);
        }

        public ActionResult NuevoProyecto()
        {
            return RedirectToAction("Index", "ProyectoDiseno", new { Id_Proyecto = 0, Id_Diseno = 0 });
        }

        
        public int EliminarProyDiseno(Int32 Id_Proyecto, Int32 Id_Diseno, Int32 Id_Usuario)
        {
            BEProyecto Proyecto = new BEProyecto();
            BEDiseno Diseno = new BEDiseno();
            ProyectoBL BLProyecto = new ProyectoBL();


            Proyecto.Id_Proyecto = Id_Proyecto;
            Diseno.idDiseno = Id_Diseno;
            Proyecto.id_Usuario = Id_Usuario;
            Proyecto.FechaActualizacion = 0;
            Proyecto.HoraActualizacion = 0;
            Proyecto.UsrActualizacion = "";

            int id;
            id = BLProyecto.EliminarProyecto(Id_Proyecto, Id_Diseno, Id_Usuario);

            return 1;
        }

        public ActionResult EditarProyDiseno(Int32 Id_Proyecto, Int32 Id_Diseno)
        {
            return RedirectToAction("Index", "ProyectoDiseno", new { Id_Proyecto = Id_Proyecto, Id_Diseno = Id_Diseno });
        }


    }
}