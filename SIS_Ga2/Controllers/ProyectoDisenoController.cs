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
            data_list.AddRange(objblDepartamento.ListarDepartamentos(0).Select(a => new SelectListItem() { Text = a.Departamento.ToUpper(), Value = Convert.ToString(a.Id_Departamento) }));
            ViewData["ddlDepartamento"] = data_list;
            ViewData["ddlProvincia"] = new SelectList(new[] { "(Selecciona)" });
            ViewData["ddlDistrito"] = new SelectList(new[] { "(Selecciona)" });
            return View();
        }


        public int RegistroProyecto(string NumProyecto, string FechaProyecto, string Ingeniero, int idUsuario)
        {

                BEProyecto Proyecto = new BEProyecto();
                ProyectoBL BLProyecto = new ProyectoBL();

                Proyecto.Num_Proyecto = NumProyecto;
                Proyecto.Proyecto = "";
                Proyecto.Fecha_Proyecto_Date = FechaProyecto;
                Proyecto.Estado = Convert.ToBoolean(1);
                Proyecto.id_Usuario = idUsuario;
                Proyecto.FechaCreacion = 0;
                Proyecto.Fecha_Contrato = 0;
                Proyecto.HoraCreacion = 0;
                Proyecto.UsrCreacion = "Yo";
                Proyecto.FechaActualizacion = 0;
                Proyecto.HoraActualizacion = 0;
                Proyecto.UsrActualizacion = "Yo";
                Proyecto.Ingeniero = Ingeniero;
                
                

            if (!String.IsNullOrEmpty(NumProyecto))
            {
                int id;
                id = BLProyecto.GuardarProyecto(Proyecto);

                return 1;
            }
            else
            {
                return 0;
            }
                
        }


        public int RegistroDiseno(string NumProyecto, string FechaProyecto, string Ingeniero, int idUsuario)
        {

            //BEProyecto Proyecto = new BEProyecto();
            //ProyectoBL BLProyecto = new ProyectoBL();

            //Proyecto.Num_Proyecto = NumProyecto;
            //Proyecto.Proyecto = "";
            //Proyecto.Fecha_Proyecto_Date = FechaProyecto;
            //Proyecto.Estado = Convert.ToBoolean(1);
            //Proyecto.id_Usuario = idUsuario;
            //Proyecto.FechaCreacion = 0;
            //Proyecto.Fecha_Contrato = 0;
            //Proyecto.HoraCreacion = 0;
            //Proyecto.UsrCreacion = "Yo";
            //Proyecto.FechaActualizacion = 0;
            //Proyecto.HoraActualizacion = 0;
            //Proyecto.UsrActualizacion = "Yo";
            //Proyecto.Ingeniero = Ingeniero;



            //if (!String.IsNullOrEmpty(NumProyecto))
            //{
            //    int id;
            //    id = BLProyecto.GuardarProyecto(Proyecto);

            //    return 1;
            //}
            //else
            //{
            //    return 0;
            //}

            return 1;
        }

    }
}