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


        public JsonResult ListaReporteCabecera(string Id_Proyecto, string Id_Diseno)
        {
            /* if (Id_Proyecto == "") { FechaProyecto = "0"; }
             if (Id_Diseno == "") { FechaContrato = "0"; }


             ProyectoBL objProyecto = new ProyectoBL();

             List<BEProyecto> Proyecto = objProyecto.ListarProyectos(NumProyecto, FechaProyecto, FechaContrato, Int32.Parse(IdUsuario), Int32.Parse(Distrito), Int32.Parse(Provincia), Int32.Parse(Departamento));
             return Json(new { data = Proyecto }, JsonRequestBehavior.AllowGet);

             { Pavimento: "Adoquin + arena", CoefCapa: "0.44", CoefDrenaje: "", Espesor: "3.15", SN: "1.39", Espesor: "8.00" },
             { Pavimento: "Base", CoefCapa: " 0.14", CoefDrenaje: "1.00", Espesor: "3.15", SN: "0.44", Espesor: "8.00" },
             { Pavimento: "Sub - Base", CoefCapa: "0.44", CoefDrenaje: "1", Espesor: "7.09", SN: "", Espesor: "18.00" }
             */
            ProyectoBL objblProyecto = new ProyectoBL();

            List<BEProyecto> objProyecto = new List<BEProyecto>();

            return Json(new { data = objProyecto }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarProyectos(string NumProyecto, string FechaProyecto, string FechaContrato, string IdUsuario, string Distrito, string Provincia, string Departamento)

        {
            if (FechaProyecto == "") { FechaProyecto = "0"; }
            if (FechaContrato == "") { FechaContrato = "0"; }
            if (Provincia == "") { Provincia = "0"; }
            if (Distrito == "") { Distrito = "0"; }
            if (Departamento == "") { Departamento = "0"; }
            if (IdUsuario == "") { IdUsuario = "0"; }

            ProyectoBL objProyecto = new ProyectoBL();

            List<BEProyecto> Proyecto = objProyecto.ListarProyectos(NumProyecto, FechaProyecto, FechaContrato, Int32.Parse(IdUsuario), Int32.Parse(Distrito), Int32.Parse(Provincia), Int32.Parse(Departamento));
            return Json(new { data = Proyecto }, JsonRequestBehavior.AllowGet);

        }

        //public JsonResult ListadoProyectos(String strNumProyecto, String strFechaProyecto, String strFechaContrato, int strIdUsuario, int strIdDistrito, int strIdProvincia, int strIdDepartamento )
        //{
        //    ProyectoBL objProyecto = new ProyectoBL();
        //    List<BEProyecto> lObjBeProyecto = objProyecto.ListarProyectos2(strNumProyecto, strFechaProyecto, strFechaContrato, strIdUsuario, strIdDistrito, strIdProvincia, strIdDepartamento);
        //    return Json(new { data = lObjBeProyecto }, JsonRequestBehavior.AllowGet);

        //}

        //public int GuardarProyecto(BEProyecto DataProyecto)
        //{
        //    ProyectoBL BLProyecto = new ProyectoBL();
        //    int id;

        //    id = BLProyecto.GuardarProyecto(DataProyecto);

        //    return id;
        //}
    }
}