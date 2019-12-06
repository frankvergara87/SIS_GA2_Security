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
            BLTasaCrecimiento objblTasaCrecimiento = new BLTasaCrecimiento();
            List<SelectListItem> data_list = new List<SelectListItem>();
            data_list.AddRange(objblTasaCrecimiento.ListarTasaCrecimiento(0).Select(a => new SelectListItem() { Text = a.TasaCrecimiento.ToUpper(), Value = Convert.ToString(a.IdTasaCrecimiento) }));
            ViewData["ddlTasaCrecimiento"] = data_list;


            List<SelectListItem> lstPeriodo = new List<SelectListItem>();
            lstPeriodo.Add(new SelectListItem() { Text = "10", Value = "1" });
            lstPeriodo.Add(new SelectListItem() { Text = "20", Value = "2" });
            lstPeriodo.Add(new SelectListItem() { Text = "30", Value = "3" });
            lstPeriodo.Add(new SelectListItem() { Text = "40", Value = "4" });
            lstPeriodo.Add(new SelectListItem() { Text = "50", Value = "5" });
            ViewData["ddlPeriodoDiseno"] = lstPeriodo;


            BLPropFactorDistribucion objblPropFactorDistribucion = new BLPropFactorDistribucion();
            List<SelectListItem> data_list_2 = new List<SelectListItem>();
            data_list_2.AddRange(objblPropFactorDistribucion.ListarFactorDistribucion(1).Select(a => new SelectListItem() { Text = a.Numero_Calzada.ToString(), Value = Convert.ToString(a.Numero_Calzada) }));
            ViewData["ddlCalzada"] = data_list_2;

            List<SelectListItem> data_list_3 = new List<SelectListItem>();
            data_list_3.AddRange(objblPropFactorDistribucion.ListarFactorDistribucion(3).Select(a => new SelectListItem() { Text = a.Numero_Carril_x_Sentido.ToString(), Value = Convert.ToString(a.Numero_Carril_x_Sentido) }));
            ViewData["ddlCarrilxSentido"] = data_list_3;

            List<SelectListItem> data_list_4 = new List<SelectListItem>();
            data_list_4.AddRange(objblPropFactorDistribucion.ListarFactorDistribucion(2).Select(a => new SelectListItem() { Text = a.Numero_Sentido.ToString(), Value = Convert.ToString(a.Numero_Sentido) }));
            ViewData["ddlNumSentido"] = data_list_4;


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


        public double calcularN18Calc1(string ErrorCombiEstandar, string DesviEstandar, string valorMR, string DifServiciabilidad)
        {
            try
            {

                double resultadoN18calc1 = 0;
                BECalculos objCalculos = new BECalculos();
                objCalculos.ErrorCombiEstandar = Convert.ToDouble(ErrorCombiEstandar);
                objCalculos.DesviEstandar = Convert.ToDouble(DesviEstandar);
                objCalculos.valorMR = Convert.ToDouble(valorMR);
                objCalculos.SNReq = Convert.ToDouble(0);
                objCalculos.N18Calc2 = calcularN18Calc2(DifServiciabilidad);

                BLReglas blReglas = new BLReglas();
                resultadoN18calc1 = blReglas.calcularN18Calc1(objCalculos);
                return resultadoN18calc1;
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }


        public double calcularN18Calc2(string DifServiciabilidad)
        {
            try
            {

                double resultadoN18calc2 = 0;
                BECalculos objCalculos = new BECalculos();
                objCalculos.DifServiciabilidad = Convert.ToDouble(DifServiciabilidad);

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


        public decimal ListarValorFactorDistrib(string Numero_Calzada, string Numero_Sentido, string Numero_Carril_x_Sentido)
        {

            try
            {
                decimal Val_Distrib_Calculado = 0;
                List<BEPropFactorDistribucion> listadoFactorDistribucion = new List<BEPropFactorDistribucion>();
                BLPropFactorDistribucion blpropFactorDistribucion = new BLPropFactorDistribucion();
                listadoFactorDistribucion = blpropFactorDistribucion.ListarValorFactorDistrib(Convert.ToInt32(Numero_Calzada), Convert.ToInt32(Numero_Sentido), Convert.ToInt32(Numero_Carril_x_Sentido));

                foreach (BEPropFactorDistribucion fd in listadoFactorDistribucion)
                {
                    Val_Distrib_Calculado = fd.Valor_Distrib_Calculado;
                    break;
                }

                return Val_Distrib_Calculado;
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}