using SIS_Ga2.Entity;
using SIS_Ga2.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SIS_Ga2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FormRegistraProyecto()
        {
            return RedirectToAction("Index", "Diseno");
        }

        public List<SelectListItem> ComboDepartamento(int idDepartamento)
        {
            List<BeDepartamento> Departamentos = new List<BeDepartamento>();
            GenericController Obj = new GenericController();
            Departamentos  = Obj.ComboDepartamento(idDepartamento);
            //List<SelectListItem> data_list = new List<SelectListItem> { new SelectListItem() { Text = string.Format("[{0}]", "SELECCIONAR"), Value = "0" } };
            List<SelectListItem> data_list = new List<SelectListItem>();
            data_list.AddRange(Departamentos.Select(a => new SelectListItem() { Text = a.Departamento.ToUpper(), Value = Convert.ToString(a.idDepartamento) }));

            return data_list;

        }

        public List<SelectListItem> ComboProvincia(int idDepartamento)
        {
            List<BEProvincia> Provincias = new List<BEProvincia>();
            GenericController Obj = new GenericController();
            Provincias = Obj.ComboProvincia(idDepartamento);
            //List<SelectListItem> data_list = new List<SelectListItem> { new SelectListItem() { Text = string.Format("[{0}]", "SELECCIONAR"), Value = "0" } };
            List<SelectListItem> data_list = new List<SelectListItem>();
            data_list.AddRange(Provincias.Select(a => new SelectListItem() { Text = a.Provincia.ToUpper(), Value = Convert.ToString(a.idProvincia) }));

            return data_list;

        }

        public List<SelectListItem> ComboDistritos(int idDepartamento)
        {
            List<BEDistrito> Distritos = new List<BEDistrito>();
            GenericController Obj = new GenericController();
            Distritos = Obj.ComboDistrito(idDepartamento);
            //List<SelectListItem> data_list = new List<SelectListItem> { new SelectListItem() { Text = string.Format("[{0}]", "SELECCIONAR"), Value = "0" } };
            List<SelectListItem> data_list = new List<SelectListItem>();
            data_list.AddRange(Distritos.Select(a => new SelectListItem() { Text = a.Distrito.ToUpper(), Value = Convert.ToString(a.idDistrito) }));

            return data_list;

        }
    }
}