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
            data_list.AddRange(objblDepartamento.ListarDepartamentos(0).Select(a => new SelectListItem() { Text = a.Departamento.ToUpper(), Value = Convert.ToString(a.id_Departamento) }));
            ViewData["ddlDepartamento"] = data_list;
            ViewData["ddlProvincia"] = new SelectList(new[] { "(Selecciona)" });
            ViewData["ddlDistrito"] = new SelectList(new[] { "(Selecciona)" });
            return View();
        }

        [HttpPost]
        public ActionResult FormRegistraProyecto()
        {
            return RedirectToAction("Index", "Diseno");
        }

        public JsonResult ListaProvincias(int idDepartamento)
        {
            BLProvincia objblProvincia = new BLProvincia();
        
            List<BEProvincia> elements = objblProvincia.ListarProvincia(idDepartamento);
            if (elements == null)
                throw new ArgumentException("Departamento " + idDepartamento + " no es correcta");           
            return Json(elements);
        }

        public JsonResult ListaDepartamento(int idProvincia)
        {
            BLDistrito objDistrito = new BLDistrito();

            List<BEDistrito> elements = objDistrito.ListarDistrito(idProvincia);
            if (elements == null)
                throw new ArgumentException("Distrito " + idProvincia + " no es correcta");
            return Json(elements);
        }

    }
}