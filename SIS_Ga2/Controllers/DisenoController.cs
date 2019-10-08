using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIS_Ga2.Entity;
using SIS_Ga2.Business;

namespace SIS_Ga2.Controllers
{
    public class DisenoController : Controller
    {
        // GET: Diseno
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListarDisenos()
        {
            //Sistema usuario = new Sistema();
            //usuario = ((Sistema)Session["sistema.general"]);
            //BLDisenos objDisenos = new BLDisenos();
            //List<BEDiseno> Disenos = objDisenos.ListarDisenos();
            //return Json(new { data = Disenos }, JsonRequestBehavior.AllowGet);

            return View();

        }
    }
}