using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIS_Ga2.Entity;
using SIS_Ga2.Business;

namespace SIS_Ga2.Controllers
{
    public class ProyectoDisenoController : Controller
    {
        // GET: ProyectoDiseno
      
        public ActionResult Index()
        {
            BLDepartamento objblDepartamento = new BLDepartamento();
            List<SelectListItem> data_list = new List<SelectListItem>();
            data_list.AddRange(objblDepartamento.ListarDepartamentos(0).Select(a => new SelectListItem() { Text = a.Departamento.ToUpper(), Value = Convert.ToString(a.id_Departamento) }));
            ViewData["ddlDepartamento"] = data_list;
            ViewData["ddlProvincia"] = new SelectList(new[] { "(Selecciona)" });
            ViewData["ddlDistrito"] = new SelectList(new[] { "(Selecciona)" });
            return View();
        }

        [HttpPost]
        public ActionResult FormRegistraProyecto()
        {

            BEProyecto Proyecto = new BEProyecto();
       
            Proyecto.NumProyecto = Request.Form["txtNombProyecto"];
            Proyecto.Proyecto = "";
            Proyecto.Fecha_Proyecto = 0;
            Proyecto.Estado = Convert.ToBoolean(1);
            Proyecto.id_Usuario = 1;
            Proyecto.FechaCreacion = 0;
            Proyecto.Fecha_Contrato = 0;
            Proyecto.HoraCreacion = 0;
            Proyecto.UsrCreacion = "Yo";
            Proyecto.FechaActualizacion = 0;
            Proyecto.HoraActualizacion = 0;
            Proyecto.UsrActualizacion = "Yo";
            Proyecto.Ingeniero = Request.Form["datetimepicker1"];
            ProyectoBL BLProyecto = new ProyectoBL();
            int id;

            id = BLProyecto.GuardarProyecto(Proyecto);

            return View(id);
        }
    }
}