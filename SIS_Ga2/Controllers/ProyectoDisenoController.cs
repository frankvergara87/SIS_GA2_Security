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
      
        public ActionResult Index(Int32 Id_Proyecto, Int32 Id_Diseno)
        {
            BLDepartamento objblDepartamento = new BLDepartamento();
            List<SelectListItem> data_list = new List<SelectListItem>();
            data_list.AddRange(objblDepartamento.ListarDepartamentos(0).Select(a => new SelectListItem() { Text = a.Departamento.ToUpper(), Value = Convert.ToString(a.Id_Departamento) }));
            ViewData["ddlDepartamento"] = data_list;
            ViewData["ddlProvincia"] = new SelectList(new[] { "(Selecciona)" });
            ViewData["ddlDistrito"] = new SelectList(new[] { "(Selecciona)" });

            //Implementar el codigo para obtener los valores y cargarlos

            return View();
        }


        public int RegistroProyDiseno(BEProyecto ObjProyecto, BEDiseno ObjDiseno)
        {

            BEProyecto Proyecto = new BEProyecto();
            BEDiseno Diseno = new BEDiseno();
            ProyectoBL BLProyecto = new ProyectoBL();

            Proyecto.Num_Proyecto = ObjProyecto.Num_Proyecto;
            Proyecto.Proyecto = ObjProyecto.Proyecto;
            Proyecto.Fecha_Proyecto_Date = ObjProyecto.Fecha_Proyecto_Date;
            Proyecto.Estado = Convert.ToBoolean(1);
            Proyecto.id_Usuario = ObjProyecto.id_Usuario;
            Proyecto.FechaCreacion = 0;
            Proyecto.Fecha_Contrato = 0;
            Proyecto.HoraCreacion = 0;
            Proyecto.UsrCreacion = ObjProyecto.UsrCreacion;
            Proyecto.FechaActualizacion = 0;
            Proyecto.HoraActualizacion = 0;
            Proyecto.UsrActualizacion = "";
            Proyecto.Ingeniero = ObjProyecto.Ingeniero;

            Diseno.NumeroDiseno = ObjDiseno.NumeroDiseno;
            Diseno.idTramo = ObjDiseno.idTramo;
            Diseno.idReglamento = ObjDiseno.idReglamento;
            Diseno.IdTipoDiseno = ObjDiseno.IdTipoDiseno;
            Diseno.idDistrito = ObjDiseno.idDistrito;

            if (!String.IsNullOrEmpty(ObjProyecto.Num_Proyecto))
            {
                int id;
                id = BLProyecto.GuardarProyecto(Proyecto, Diseno);

                return 1;
            }
            else
            {
                return 0;
            }
        }

    }
}