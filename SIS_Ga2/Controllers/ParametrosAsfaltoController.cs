using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIS_Ga2.Business;
using SIS_Ga2.Entity;


namespace SIS_Ga2.Controllers
{
    public class ParametrosAsfaltoController : Controller
    {
        // GET: ParametrosAsfalto
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
            objCalculos.ServIniPI = Convert.ToDouble(ServInicial);
            objCalculos.ServFinPT = Convert.ToDouble(ServFinal);

            BLReglas blReglas = new BLReglas();

            resultadoPSI = blReglas.calcularPSI(objCalculos);

            return resultadoPSI;
        }


        public double calcularN18Nom(string CantESAL)
        {
            double resultadoN18Nomi = 0;
            BECalculos objCalculos = new BECalculos();
            objCalculos.CantESAL = Convert.ToDouble(CantESAL);

            BLReglas blReglas = new BLReglas();

            resultadoN18Nomi = blReglas.calcularN18Nom(objCalculos);

            return resultadoN18Nomi;
        }


        public double calcularN18Calc1(string ErrorCombiEstandar, string DesviEstandar, string valorMR)
        {
            try
            {

                double resultadoN18calc1 = 0;
                BECalculos objCalculos = new BECalculos();
                objCalculos.ErrorCombiEstandar = Convert.ToDouble(ErrorCombiEstandar);
                objCalculos.DesviEstandar = Convert.ToDouble(DesviEstandar);
                objCalculos.valorMR = Convert.ToDouble(valorMR);
                objCalculos.SNReq = Convert.ToDouble(0);
                objCalculos.N18Calc2 = calcularN18Calc2(DesviEstandar);

                BLReglas blReglas = new BLReglas();
                resultadoN18calc1 = blReglas.calcularN18Calc1(objCalculos);
                return resultadoN18calc1;
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }


        public double calcularN18Calc2(string DesviEstandar)
        {
            try
            {

                double resultadoN18calc2 = 0;
                BECalculos objCalculos = new BECalculos();
                objCalculos.DesviEstandar = Convert.ToDouble(DesviEstandar);

                BLReglas blReglas = new BLReglas();
                resultadoN18calc2 = blReglas.calcularN18Calc2(objCalculos);
                return resultadoN18calc2;
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }


        public double calcularSNReq(string ErrorCombiEstandar, string DesviEstandar, string valorMR, string N18Calc2, string N18Nominal)
        {

            try
            {
                double ResultadoSNReq = 0;
                BECalculos objeBECalculos = new BECalculos();
                objeBECalculos.ErrorCombiEstandar = Convert.ToDouble(ErrorCombiEstandar);
                objeBECalculos.DesviEstandar = Convert.ToDouble(DesviEstandar);
                objeBECalculos.valorMR = Convert.ToDouble(valorMR);
                objeBECalculos.N18Calc2 = Convert.ToDouble(N18Calc2);
                objeBECalculos.N18Nom = Convert.ToDouble(N18Nominal);

                BLReglas blReglas = new BLReglas();
                ResultadoSNReq = blReglas.calcularSNReq(objeBECalculos);

                return ResultadoSNReq;
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}