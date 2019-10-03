using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIS_Ga2.Entity;
using SIS_Ga2.Business;

namespace SIS_Ga2.Controllers
{
    public class ProyectosController : Controller
    {
        // GET: Proyectos
        public ActionResult Index()
        {
            return View();
        }

        
        public JsonResult ListarProyectos(string NumProyecto, string FechaProyecto, string FechaContrato, int IdUsuario, int Distrito, int Provincia, int Departamento)
        {

            Sistema usuario = new Sistema();
            usuario = ((Sistema)Session["sistema.general"]);
            ProyectoBL objProyecto = new ProyectoBL();
            List<BEProyecto> Proyecto = objProyecto.ListarProyectos(NumProyecto, FechaProyecto, FechaContrato, IdUsuario, Distrito, Provincia, Departamento);
            return Json(new { data = Proyecto }, JsonRequestBehavior.AllowGet);

        }

        //public JsonResult ListadoProyectos(String strNumProyecto, String strFechaProyecto, String strFechaContrato, int strIdUsuario, int strIdDistrito, int strIdProvincia, int strIdDepartamento )
        //{
        //    ProyectoBL objProyecto = new ProyectoBL();
        //    List<BEProyecto> lObjBeProyecto = objProyecto.ListarProyectos2(strNumProyecto, strFechaProyecto, strFechaContrato, strIdUsuario, strIdDistrito, strIdProvincia, strIdDepartamento);
        //    return Json(new { data = lObjBeProyecto }, JsonRequestBehavior.AllowGet);

        //}

        public int GuardarProyecto(Proyecto DataProyecto)
        {
            ProyectoBL BLProyecto = new ProyectoBL();
            int id;

            id = BLProyecto.GuardarProyecto(DataProyecto);

            return id;
        }
    }
}