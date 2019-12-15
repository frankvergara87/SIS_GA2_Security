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
            List<SelectListItem> lstPeriodoDiseno = new List<SelectListItem>();
            lstPeriodoDiseno.Add(new SelectListItem() { Text = "5.00", Value = "1" });
            lstPeriodoDiseno.Add(new SelectListItem() { Text = "10.00", Value = "2" });
            lstPeriodoDiseno.Add(new SelectListItem() { Text = "15.00", Value = "3" });
            lstPeriodoDiseno.Add(new SelectListItem() { Text = "20.00", Value = "4" });
            ViewData["ddlPeriodoDisenoParam"] = lstPeriodoDiseno;


            BLTasaCrecimiento objblTasaCrecimiento = new BLTasaCrecimiento();
            List<SelectListItem> data_list = new List<SelectListItem>();
            data_list.AddRange(objblTasaCrecimiento.ListarTasaCrecimiento(0).Select(a => new SelectListItem() { Text = a.TasaCrecimiento.ToUpper(), Value = Convert.ToString(a.IdTasaCrecimiento) }));
            ViewData["ddlTasaCrecimiento"] = data_list;



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


            List<SelectListItem> lstTipoVehiculo = new List<SelectListItem>();
            lstTipoVehiculo.Add(new SelectListItem() { Text = "Vehiculos", Value = "1" });
            lstTipoVehiculo.Add(new SelectListItem() { Text = "Camionetas", Value = "2" });
            lstTipoVehiculo.Add(new SelectListItem() { Text = "Buses", Value = "3" });
            lstTipoVehiculo.Add(new SelectListItem() { Text = "Camiones", Value = "4" });
            lstTipoVehiculo.Add(new SelectListItem() { Text = "Semi Trailers", Value = "5" });
            lstTipoVehiculo.Add(new SelectListItem() { Text = "Trailers", Value = "6" });
            ViewData["ddlTipoVehiculo"] = lstTipoVehiculo;


            List<SelectListItem> lstVehiculo = new List<SelectListItem>();
            lstVehiculo.Add(new SelectListItem() { Text = "Seleccione", Value = "0" });
            ViewData["ddlVehiculo"] = lstVehiculo;

            List<SelectListItem> lstTipoEje_1 = new List<SelectListItem>();
            lstTipoEje_1.Add(new SelectListItem() { Text = " ", Value = "0" });
            ViewData["ddlTipoEje_1"] = lstTipoEje_1;

            List<SelectListItem> lstTipoEje_2 = new List<SelectListItem>();
            lstTipoEje_2.Add(new SelectListItem() { Text = " ", Value = "0" });
            ViewData["ddlTipoEje_2"] = lstTipoEje_2;

            List<SelectListItem> lstTipoEje_3 = new List<SelectListItem>();
            lstTipoEje_3.Add(new SelectListItem() { Text = " ", Value = "0" });
            ViewData["ddlTipoEje_3"] = lstTipoEje_3;

            List<SelectListItem> lstTipoEje_4 = new List<SelectListItem>();
            lstTipoEje_4.Add(new SelectListItem() { Text = " ", Value = "0" });
            ViewData["ddlTipoEje_4"] = lstTipoEje_4;

            List<SelectListItem> lstTipoEje_5 = new List<SelectListItem>();
            lstTipoEje_5.Add(new SelectListItem() { Text = " ", Value = "0" });
            ViewData["ddlTipoEje_5"] = lstTipoEje_5;


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


        public JsonResult ListarValorFactorDistrib(string Numero_Calzada, string Numero_Sentido, string Numero_Carril_x_Sentido)
        {

            try
            {
                List<BEPropFactorDistribucion> listadoFactorDistribucion = new List<BEPropFactorDistribucion>();
                BLPropFactorDistribucion blpropFactorDistribucion = new BLPropFactorDistribucion();
                listadoFactorDistribucion = blpropFactorDistribucion.ListarValorFactorDistrib(Convert.ToInt32(Numero_Calzada), Convert.ToInt32(Numero_Sentido), Convert.ToInt32(Numero_Carril_x_Sentido));

                return Json(listadoFactorDistribucion);
            }
            catch (Exception)
            {

                throw;
            }

        }


        public JsonResult ListaVehiculo(int idTipoVehiculo)
        {

            BLVehiculos objblVehiculos = new BLVehiculos();
            List<BEVehiculos> lobjVehiculos = new List<BEVehiculos>();
            lobjVehiculos = objblVehiculos.ListarVehiculos(idTipoVehiculo);

            if (lobjVehiculos == null)
                throw new ArgumentException("Vehiculo " + idTipoVehiculo + " no es correcto");
            return Json(lobjVehiculos);
        }





        public int ObtenerCantidadEjes(int idVehiculo)
        {
            int CantEjes = 0;
            BLEjes objblCantEjes = new BLEjes();
            List<BEEjes> lobjCantEjes = new List<BEEjes>();
            lobjCantEjes = objblCantEjes.ListarCantidadEjes(idVehiculo);

            foreach (BEEjes ce in lobjCantEjes)
            {
                CantEjes = ce.Total_Ejes;
            }            

            return CantEjes;
        }

        public decimal ListarEjesPeso(int idVehiculo, int idEje)
        {
            decimal EjePeso = 0;
            BLEjes objblPesoEjes = new BLEjes();
            List<BEEjes> lobjPesoEjes = new List<BEEjes>();
            lobjPesoEjes = objblPesoEjes.ListarEjesPeso(idVehiculo, idEje);

            foreach (BEEjes ce in lobjPesoEjes)
            {
                EjePeso = ce.Peso;
            }

            return EjePeso;
        }

        public JsonResult ListarEjesxVehiculo(int idVehiculo)
        {
            BLEjes objblEjes = new BLEjes();
            List<BEEjes> lobjEjes = new List<BEEjes>();
            lobjEjes = objblEjes.ListarEjesxVehiculo(idVehiculo);

            if (lobjEjes == null)
                throw new ArgumentException("Vehiculo " + idVehiculo + " no es correcto");
            return Json(lobjEjes);
        }


        public double CalcularFVP(string idTipoVehiculo, string idVehiculo, string TipoDiseno, string PesoE1, string PesoE2)
        {
            double FVP = 0;
            BLReglas objblReglas = new BLReglas();
            BECalculos lobjCalculos = new BECalculos();
            lobjCalculos.Id_TipoVehiculo = Convert.ToInt32(idTipoVehiculo);
            lobjCalculos.Id_Vehiculo = Convert.ToInt32(idVehiculo);
            lobjCalculos.TipoDiseno = TipoDiseno;



            if (PesoE1 == null || PesoE1.Length == 0)
            {
                lobjCalculos.PesoE1 = 0;
            }
            else
            {
                lobjCalculos.PesoE1 = Convert.ToDouble(PesoE1);
            }

            if (PesoE2 == null || PesoE2.Length == 0)
            {
                lobjCalculos.PesoE2 = 0;
            }
            else
            {
                lobjCalculos.PesoE2 = Convert.ToDouble(PesoE2);
            }    

            FVP = objblReglas.calcularFVP(lobjCalculos);

            return FVP;
        }




        public int GuardarVehiculosIMD(int idVehiculo)
        {

            int Id_Repet_Equivalentes;
            BLRepeticionesEqui objblRepeticionesEqui = new BLRepeticionesEqui();
            BERepeticionesEqui lobjRepeticionesEqu = new BERepeticionesEqui();

            lobjRepeticionesEqu.Id_Tasa_Crecimiento = 2;
            lobjRepeticionesEqu.Id_Prop_Factor_Distrib = 1;
            lobjRepeticionesEqu.Dias_Diseno = 34;
            lobjRepeticionesEqu.FP = 54;
            lobjRepeticionesEqu.Tipo_Diseno = 2;
            lobjRepeticionesEqu.Periodo = 12;
            lobjRepeticionesEqu.Valor_EE_Total = 123;
            lobjRepeticionesEqu.Id_Parametro = 2;
            lobjRepeticionesEqu.Fecha_Creacion = 0;
            lobjRepeticionesEqu.Hora_Creacion = 0;
            lobjRepeticionesEqu.Usr_Creacion = "fvergara";

            Id_Repet_Equivalentes = objblRepeticionesEqui.GuardarRepeticionesEqui(lobjRepeticionesEqu);


            int Id_Vehiculos_IMD;
            BLVehiculosIMD objblVehiculosIMD = new BLVehiculosIMD();
            BEVehiculosIMD lobjVehiculosIMD = new BEVehiculosIMD();
            lobjVehiculosIMD.Id_Vehiculos = idVehiculo;
            lobjVehiculosIMD.Id_Repet_Equivalentes = Id_Repet_Equivalentes;
            lobjVehiculosIMD.IMD_Base = 123;
            lobjVehiculosIMD.Estado = 0;
            lobjVehiculosIMD.Tipo_Eje_E1 = "xx";
            lobjVehiculosIMD.Peso_Tonelada_E1 = 0;
            lobjVehiculosIMD.Tipo_Eje_E1 = "xx";
            lobjVehiculosIMD.Peso_Tonelada_E1 = 0;
            lobjVehiculosIMD.Tipo_Eje_E1 = "xx";
            lobjVehiculosIMD.Peso_Tonelada_E1 = 0;
            lobjVehiculosIMD.Tipo_Eje_E1 = "xx";
            lobjVehiculosIMD.Peso_Tonelada_E1 = 0;
            lobjVehiculosIMD.Tipo_Eje_E1 = "xx";
            lobjVehiculosIMD.Peso_Tonelada_E1 = 0;
            lobjVehiculosIMD.Valor_FVP = 2;
            lobjVehiculosIMD.Valor_EE = 3;
            lobjVehiculosIMD.Fecha_Creacion = 0;
            lobjVehiculosIMD.Hora_Creacion = 0;
            lobjVehiculosIMD.Usr_Creacion = "fvergara";

            lobjVehiculosIMD.Fecha_Actualizacion = 0;
            lobjVehiculosIMD.Hora_Actualizacion = 0;
            lobjVehiculosIMD.Usr_Actualizacion = "fvergara";

            Id_Vehiculos_IMD = objblVehiculosIMD.GuardarVehiculosIMD(lobjVehiculosIMD);


            return Id_Vehiculos_IMD;
        }



        public decimal CoeficienteA2(string valorCBRBase)
        {

            try
            {
                decimal ValorA2 = 0;
                BECalculos objeBECalculos = new BECalculos();
                objeBECalculos.valorCBRBase = Convert.ToDouble(valorCBRBase);

                BLReglas blReglas = new BLReglas();
                ValorA2 = Convert.ToDecimal(blReglas.CoeficienteA2(objeBECalculos));

                return ValorA2;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public decimal CoeficienteA3(string valorCBRSubBase)
        {

            try
            {
                decimal ValorA3 = 0;
                BECalculos objeBECalculos = new BECalculos();
                objeBECalculos.valorCBRSubBase = Convert.ToDouble(valorCBRSubBase);

                BLReglas blReglas = new BLReglas();
                ValorA3 = Convert.ToDecimal(blReglas.CoeficienteA3(objeBECalculos));

                return ValorA3;
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}