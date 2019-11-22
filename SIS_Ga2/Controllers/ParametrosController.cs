using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIS_Ga2.Business;
using SIS_Ga2.Entity;

namespace SIS_Ga2.Controllers
{
    public class ParametrosController : Controller
    {
        // GET: Parametros
        public ActionResult Index()
        {
            return View();
        }

        public double CalcularResilenciaASF(string CBR)
        {
            double ModResi_ASF = 0;
            BECalculos objCalculos = new BECalculos();
            objCalculos.valorCBR = Convert.ToDouble(CBR);
            BLReglas blReglas = new BLReglas();

            ModResi_ASF = blReglas.calcularModResilenciaAsf(objCalculos);


            return ModResi_ASF;
        }

        public double CalcularDesviacionEstandar(string ValorConfiabilidad)
        {
            double resultadoMR = 0;
            BECalculos objCalculos = new BECalculos();
            objCalculos.valorConfiabR = Convert.ToDouble(ValorConfiabilidad);
            BLReglas blReglas = new BLReglas();

            resultadoMR = blReglas.calcularDesvEstandZR(objCalculos);

            return resultadoMR;
        }


        public double CalcularDifServiciabilidad(string ServInicial, string ServFinal)
        {
            double resultadoPSI = 0;
            BECalculos objCalculos = new BECalculos();
            objCalculos.ServIniPI= Convert.ToDouble(ServInicial);
            objCalculos.ServFinPT= Convert.ToDouble(ServFinal);

            BLReglas blReglas = new BLReglas();

            resultadoPSI = blReglas.calcularPSI(objCalculos);

            return resultadoPSI;
        }
        

    }
}