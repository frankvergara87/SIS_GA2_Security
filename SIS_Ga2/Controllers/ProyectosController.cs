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

        
        public JsonResult ListarProyectos(int idTipoDiseno, int idUsuario)
        {

            Sistema usuario = new Sistema();
            usuario = ((Sistema)Session["sistema.general"]);
            ProyectoBL objProyecto = new ProyectoBL();
            List<Proyecto> Proyecto = objProyecto.ListarProyectos(idTipoDiseno, idUsuario);
            return Json(new { data = Proyecto }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult ListarProyectos2(String strProyecto, String strFechaProyecto, String FechaContrato, String Departamento, String Provincia, String Distrito, String IdIngeniero )
        {
            ProyectoBL objProyecto = new ProyectoBL();
            List<BEProyecto> lObjBeProyecto = objProyecto.ListarProyectos2(strProyecto, strFechaProyecto, FechaContrato, Int32.Parse(Departamento), Int32.Parse(Provincia), Int32.Parse(Distrito), Int32.Parse(IdIngeniero));
            return Json(new { data = lObjBeProyecto }, JsonRequestBehavior.AllowGet);

        }

        public int GuardarProyecto(Proyecto DataProyecto)
        {
            ProyectoBL BLProyecto = new ProyectoBL();
            int id;

            id = BLProyecto.GuardarProyecto(DataProyecto);

            return id;
        }
    }
}