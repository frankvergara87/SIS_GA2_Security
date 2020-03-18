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
    public class ParametrosConcretoController : Controller
    {
        // GET: ParametrosConcreto
        public ActionResult Index()
        {

            string IdDis = Session["DisenoId"].ToString();


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




            BLTipoVehiculo objblTipoVehiculo = new BLTipoVehiculo();
            List<SelectListItem> lstTipoVehiculo = new List<SelectListItem>();
            lstTipoVehiculo.AddRange(objblTipoVehiculo.ListarTipoVehiculos(0).Select(a => new SelectListItem() { Text = a.Tipo_Vehiculo.ToString(), Value = Convert.ToString(a.Id_Tipo_Vehiculo) }));
            ViewData["ddlTipoVehiculo"] = lstTipoVehiculo;
            ViewData["ddlTasaTipoVehiculo"] = lstTipoVehiculo;


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


            List<SelectListItem> lstCalidadDrenaje = new List<SelectListItem>();
            lstCalidadDrenaje.Add(new SelectListItem() { Text = "Excelente", Value = "1" });
            lstCalidadDrenaje.Add(new SelectListItem() { Text = "Bueno", Value = "2" });
            lstCalidadDrenaje.Add(new SelectListItem() { Text = "Regular", Value = "3" });
            lstCalidadDrenaje.Add(new SelectListItem() { Text = "Pobre", Value = "4" });
            lstCalidadDrenaje.Add(new SelectListItem() { Text = "Malo", Value = "5" });
            ViewData["ddlCalidadDrenaje"] = lstCalidadDrenaje;


            List<SelectListItem> lstCalidadDrenajeSubBase = new List<SelectListItem>();
            lstCalidadDrenajeSubBase.Add(new SelectListItem() { Text = "Excelente", Value = "1" });
            lstCalidadDrenajeSubBase.Add(new SelectListItem() { Text = "Bueno", Value = "2" });
            lstCalidadDrenajeSubBase.Add(new SelectListItem() { Text = "Regular", Value = "3" });
            lstCalidadDrenajeSubBase.Add(new SelectListItem() { Text = "Pobre", Value = "4" });
            lstCalidadDrenajeSubBase.Add(new SelectListItem() { Text = "Malo", Value = "5" });
            ViewData["ddlCalidadDrenajeSubBase"] = lstCalidadDrenajeSubBase;


            BLCoefEspesor objblCoefEspesor = new BLCoefEspesor();
            List<SelectListItem> lstEspesor = new List<SelectListItem>();
            lstEspesor.AddRange(objblCoefEspesor.ListaCoefEspesor().Select(a => new SelectListItem() { Text = a.Espesor.ToString(), Value = Convert.ToString(a.Id_Espesor) }));
            ViewData["ddlEspesor"] = lstEspesor;

            BLCoefPresion objblCoefPresion = new BLCoefPresion();
            List<SelectListItem> lstPresion = new List<SelectListItem>();
            lstPresion.AddRange(objblCoefPresion.ListaCoefPresion().Select(a => new SelectListItem() { Text = a.Presion.ToString(), Value = Convert.ToString(a.Id_Presion) }));
            ViewData["ddlPresion"] = lstPresion;




            return View();
        }

        public double CalcularResilenciaCON(string CBR)
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


        public double calcularSNReq(string ErrorCombiEstandar, string DesviEstandar, string valorMR, string N18Calc, string N18Calc2, string N18Nominal)
        {

            try
            {
                double ResultadoSNReq = 0;
                BECalculos objeBECalculos = new BECalculos();
                objeBECalculos.ErrorCombiEstandar = Convert.ToDouble(ErrorCombiEstandar);
                objeBECalculos.DesviEstandar = Convert.ToDouble(DesviEstandar);
                objeBECalculos.valorMR = Convert.ToDouble(valorMR);
                objeBECalculos.N18Calc = Convert.ToDouble(N18Calc);
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

        public int GuardarFdxFc(BEPropFactorDistribucion objPropFactorDistribucion)
        {

            int Id_Prop_Factor_Distrib;

            BLPropFactorDistribucion objblPropFactorDistribucion = new BLPropFactorDistribucion();
            BEPropFactorDistribucion objbePropFactorDistribucion = new BEPropFactorDistribucion();

            objbePropFactorDistribucion.Id_Factor_Distribucion = 8;
            objbePropFactorDistribucion.Numero_Calzada = objPropFactorDistribucion.Numero_Calzada;
            objbePropFactorDistribucion.Numero_Sentido = objPropFactorDistribucion.Numero_Sentido;
            objbePropFactorDistribucion.Numero_Carril_x_Sentido = objPropFactorDistribucion.Numero_Carril_x_Sentido;

            if (objPropFactorDistribucion.Valor_Distrib_Calculado.ToString().Length > 0)
            {
                objbePropFactorDistribucion.Valor_Distrib_Calculado = objPropFactorDistribucion.Valor_Distrib_Calculado;
            }
            else
            {
                objbePropFactorDistribucion.Valor_Distrib_Calculado = 0;
            }

            if (objPropFactorDistribucion.Valor_Distrib_Ingresado.ToString().Length > 0)
            {
                objbePropFactorDistribucion.Valor_Distrib_Ingresado = objPropFactorDistribucion.Valor_Distrib_Ingresado;
            }
            else
            {
                objbePropFactorDistribucion.Valor_Distrib_Ingresado = 0;
            }



            objPropFactorDistribucion.Fecha_Creacion = Convert.ToDouble(DateTime.Now.ToString("yyyyMMdd"));
            objPropFactorDistribucion.Usr_Creacion = "fvergara";


            Id_Prop_Factor_Distrib = objblPropFactorDistribucion.GuardarFactorDistrib(objPropFactorDistribucion);


            return Id_Prop_Factor_Distrib;
        }




        public decimal CalcularFVP(string idTipoVehiculo, string idVehiculo, string TipoDiseno, string PesoE1, string PesoE2, string PesoE3, string PesoE4, string PesoE5)
        {
            decimal FVP;
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

            if (PesoE3 == null || PesoE3.Length == 0)
            {
                lobjCalculos.PesoE3 = 0;
            }
            else
            {
                lobjCalculos.PesoE3 = Convert.ToDouble(PesoE3);
            }

            if (PesoE4 == null || PesoE4.Length == 0)
            {
                lobjCalculos.PesoE4 = 0;
            }
            else
            {
                lobjCalculos.PesoE4 = Convert.ToDouble(PesoE4);
            }

            if (PesoE5 == null || PesoE5.Length == 0)
            {
                lobjCalculos.PesoE5 = 0;
            }
            else
            {
                lobjCalculos.PesoE5 = Convert.ToDouble(PesoE5);
            }

            FVP = Convert.ToDecimal(objblReglas.calcularFVP(lobjCalculos));

            return FVP;
        }

        public int GuardarVehiculosIMD(BEVehiculosIMD objVehiculosIMD, BERepeticionesEqui objRepeticionesEqui, int hid_Id_Repet_Equi)
        {

            int Id_Repet_Equivalentes;

            if (hid_Id_Repet_Equi == 0) //Validamos si ya se creo la cabecera
            {
                BLRepeticionesEqui objblRepeticionesEqui = new BLRepeticionesEqui();
                BERepeticionesEqui lobjRepeticionesEqu = new BERepeticionesEqui();

                lobjRepeticionesEqu.Id_Tasa_Crecimiento = objRepeticionesEqui.Id_Tasa_Crecimiento;
                lobjRepeticionesEqu.Id_Prop_Factor_Distrib = objRepeticionesEqui.Id_Prop_Factor_Distrib;
                lobjRepeticionesEqu.Dias_Diseno = objRepeticionesEqui.Dias_Diseno;
                lobjRepeticionesEqu.FP = objRepeticionesEqui.FP;
                lobjRepeticionesEqu.Tipo_Diseno = objRepeticionesEqui.Tipo_Diseno;
                lobjRepeticionesEqu.Periodo = objRepeticionesEqui.Periodo;
                lobjRepeticionesEqu.Valor_EE_Total = 0;
                lobjRepeticionesEqu.Id_Diseno = objVehiculosIMD.Id_Diseno;
                lobjRepeticionesEqu.Fecha_Creacion = Convert.ToDouble(DateTime.Now.ToString("yyyyMMdd"));
                lobjRepeticionesEqu.Hora_Creacion = Convert.ToDouble(DateTime.Now.ToString("hhmmss").ToString());
                lobjRepeticionesEqu.Usr_Creacion = "fvergara";

                Id_Repet_Equivalentes = objblRepeticionesEqui.GuardarRepeticionesEqui(lobjRepeticionesEqu);
            }
            else
            {
                Id_Repet_Equivalentes = hid_Id_Repet_Equi;
            }


            int Id_Vehiculos_IMD;
            BLVehiculosIMD objblVehiculosIMD = new BLVehiculosIMD();
            BEVehiculosIMD lobjVehiculosIMD = new BEVehiculosIMD();
            lobjVehiculosIMD.Id_Vehiculos = objVehiculosIMD.Id_Vehiculos;
            lobjVehiculosIMD.Id_Repet_Equivalentes = Id_Repet_Equivalentes;
            lobjVehiculosIMD.IMD_Base = objVehiculosIMD.IMD_Base;
            lobjVehiculosIMD.Estado = 1;

            if (objVehiculosIMD.Tipo_Eje_E1 == null)
            { lobjVehiculosIMD.Tipo_Eje_E1 = " "; }
            else { lobjVehiculosIMD.Tipo_Eje_E1 = objVehiculosIMD.Tipo_Eje_E1; }

            if (objVehiculosIMD.Tipo_Eje_E2 == null)
            { lobjVehiculosIMD.Tipo_Eje_E2 = " "; }
            else { lobjVehiculosIMD.Tipo_Eje_E2 = objVehiculosIMD.Tipo_Eje_E2; }

            if (objVehiculosIMD.Tipo_Eje_E3 == null)
            { lobjVehiculosIMD.Tipo_Eje_E3 = " "; }
            else { lobjVehiculosIMD.Tipo_Eje_E3 = objVehiculosIMD.Tipo_Eje_E3; }

            if (objVehiculosIMD.Tipo_Eje_E4 == null)
            { lobjVehiculosIMD.Tipo_Eje_E4 = " "; }
            else { lobjVehiculosIMD.Tipo_Eje_E4 = objVehiculosIMD.Tipo_Eje_E4; }

            if (objVehiculosIMD.Tipo_Eje_E5 == null)
            { lobjVehiculosIMD.Tipo_Eje_E5 = " "; }
            else { lobjVehiculosIMD.Tipo_Eje_E5 = objVehiculosIMD.Tipo_Eje_E5; }


            lobjVehiculosIMD.Peso_Tonelada_E1 = objVehiculosIMD.Peso_Tonelada_E1;
            lobjVehiculosIMD.Peso_Tonelada_E2 = objVehiculosIMD.Peso_Tonelada_E2;
            lobjVehiculosIMD.Peso_Tonelada_E3 = objVehiculosIMD.Peso_Tonelada_E3;
            lobjVehiculosIMD.Peso_Tonelada_E4 = objVehiculosIMD.Peso_Tonelada_E4;
            lobjVehiculosIMD.Peso_Tonelada_E5 = objVehiculosIMD.Peso_Tonelada_E5;


            lobjVehiculosIMD.Valor_FVP = objVehiculosIMD.Valor_FVP;
            lobjVehiculosIMD.Valor_EE = objVehiculosIMD.Valor_EE;
            lobjVehiculosIMD.Fecha_Creacion = Convert.ToDouble(DateTime.Now.ToString("yyyyMMdd"));
            lobjVehiculosIMD.Hora_Creacion = Convert.ToDouble(DateTime.Now.ToString("hhmmss").ToString());
            lobjVehiculosIMD.Usr_Creacion = "fvergara";

            lobjVehiculosIMD.Fecha_Actualizacion = 0;
            lobjVehiculosIMD.Hora_Actualizacion = 0;
            lobjVehiculosIMD.Usr_Actualizacion = "";

            lobjVehiculosIMD.Id_Diseno = objVehiculosIMD.Id_Diseno;

            Id_Vehiculos_IMD = objblVehiculosIMD.GuardarVehiculosIMD(lobjVehiculosIMD);


            return Id_Repet_Equivalentes;
        }


        public JsonResult CargarListadoVehiculosIMD(int Id_Repet_Equivalentes)
        {
            BLVehiculosIMD objblVehiculosIMD = new BLVehiculosIMD();
            List<BEVehiculosIMD> lobjVehiculosIMD = new List<BEVehiculosIMD>();
            lobjVehiculosIMD = objblVehiculosIMD.ListarVehiculosIMDByID(Id_Repet_Equivalentes);

            if (lobjVehiculosIMD == null)
                throw new ArgumentException("Rep.Equivalentes " + Id_Repet_Equivalentes + " no es correcto");

            return Json(new { data = lobjVehiculosIMD }, JsonRequestBehavior.AllowGet);
        }


        public int EliminarVehiculosIMD(int Id_Vehiculos_IMD, int Id_Diseno, int Id_Repet_Equivalentes)
        {
            try
            {
                int del = 0;

                BLVehiculosIMD objblVehiculosIMD = new BLVehiculosIMD();
                BEVehiculosIMD lobjVehiculosIMD = new BEVehiculosIMD();
                lobjVehiculosIMD.Id_Vehiculos_IMD = Id_Vehiculos_IMD;
                lobjVehiculosIMD.Id_Diseno = Id_Diseno;
                lobjVehiculosIMD.Id_Repet_Equivalentes = Id_Repet_Equivalentes;

                del = objblVehiculosIMD.EliminarVehiculosIMD(lobjVehiculosIMD);


                return Id_Repet_Equivalentes;
            }
            catch (Exception)
            {

                throw;
            }

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




        public JsonResult CargarTiempoDrenaje(int Id)
        {
            BLTiempoElimAgua objblTiempoElimAgua = new BLTiempoElimAgua();
            List<BETiempoElimAgua> lobjTiempoElimAgua = new List<BETiempoElimAgua>();
            lobjTiempoElimAgua = objblTiempoElimAgua.ListarTiempoElimAguaXID(Id);

            if (lobjTiempoElimAgua == null)
                throw new ArgumentException("Id " + Id + " no es correcto");

            return Json(new { data = lobjTiempoElimAgua }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult CargarPorcentajeDrenaje(int Id)
        {
            BLPorcEstrucPavimento objblPorcEstrucPavimento = new BLPorcEstrucPavimento();
            List<BEPorcEstructPavimento> lobjPorcEstructPavimento = new List<BEPorcEstructPavimento>();
            lobjPorcEstructPavimento = objblPorcEstrucPavimento.ListarPorcEstrucPavimento(Id);

            if (lobjPorcEstructPavimento == null)
                throw new ArgumentException("Id " + Id + " no es correcto");

            return Json(new { data = lobjPorcEstructPavimento }, JsonRequestBehavior.AllowGet);
        }



        public decimal ObtenerCoefDrenaje(int IdCalidadDre, decimal ValorPorcentaje, string IDProyecto)
        {
            decimal coefdrenaje = 0;
            BLCoefDreBaseReg objblCoefDreBaseReg = new BLCoefDreBaseReg();
            List<BECoefDreBaseReg> lobjCoefDreBaseReg = new List<BECoefDreBaseReg>();
            lobjCoefDreBaseReg = objblCoefDreBaseReg.ListarCoefDrenaje(IdCalidadDre, ValorPorcentaje, IDProyecto);


            foreach (BECoefDreBaseReg ce in lobjCoefDreBaseReg)
            {
                coefdrenaje = Convert.ToDecimal(ce.VALOR_CALIDAD_DRENA);
            }

            return coefdrenaje;
        }


        public int GuardarCoefDrenajeCapas(BEVehiculosIMD objVehiculosIMD, BERepeticionesEqui objRepeticionesEqui)
        {
            //EN PRUEBA
            int CoefDrenajeCapas = 0;

            BLProyectos blProyectos = new BLProyectos();
            BECoefEstructura lobjBECoefEstructura = new BECoefEstructura();
            lobjBECoefEstructura.Coeficiente_Drenaje_Calc = Convert.ToDouble("20.00");
            CoefDrenajeCapas = blProyectos.GuardarCoeficientes(lobjBECoefEstructura);


            return CoefDrenajeCapas;
        }


        public JsonResult obtenerFpCalculado(int Espesor, int Presion)
        {

            try
            {
                List<BEPresContacNeum> listadoPresContacNeum = new List<BEPresContacNeum>();
                BLPresContacNeum blBLPresContacNeum = new BLPresContacNeum();
                listadoPresContacNeum = blBLPresContacNeum.ListarValorFP(Espesor, Presion);


                return Json(listadoPresContacNeum);
            }
            catch (Exception)
            {

                throw;
            }

        }




        public decimal LimpiarVariableTiempo(int IdDiseno, decimal NroAnio)
        {

            BLTasaCrecimiento bLTasaCrecimiento = new BLTasaCrecimiento();
            BETasaCrecimiento beTasaCrecimiento = new BETasaCrecimiento();
            beTasaCrecimiento.Id_Diseno = IdDiseno;

            bLTasaCrecimiento.LimpiarVariableTiempo(beTasaCrecimiento);


            for (int i = 1; i <= Convert.ToInt32(NroAnio); i++)
            {
                try
                {
                    GuardarCrecXTiempo(i, "0", IdDiseno);

                }
                catch (Exception)
                {

                    throw;
                }

            }


            //Invocamos el total de Variable x Tiempo
            decimal TotalTasaCrecimiento = 0;
            BLReglas bLReglas = new BLReglas();
            TotalTasaCrecimiento = bLReglas.TotalTasaCrecimiento(IdDiseno);

            //Fin

            return TotalTasaCrecimiento;
        }

        public int GenerarVariableVehiculo(int IdDiseno)
        {
            BLTasaCrecimiento bLTasaCrecimiento = new BLTasaCrecimiento();
            BETasaCrecimiento beTasaCrecimiento = new BETasaCrecimiento();
            beTasaCrecimiento.Id_Diseno = IdDiseno;

            bLTasaCrecimiento.LimpiarVariableVehiculo(beTasaCrecimiento);

            for (int i = 1; i <= 6; i++)
            {
                try
                {
                    GuardarCrecXVehiculo(i, "0", IdDiseno);

                }
                catch (Exception)
                {

                    throw;
                }

            }

            return 1;
        }


        public JsonResult CargarVariableTiempo(int IdDiseno)
        {

            BLTasaCrecimiento objblTasaCrecimiento = new BLTasaCrecimiento();
            List<BETasaCrecimiento> lobjBETasaCrecimiento = new List<BETasaCrecimiento>();
            lobjBETasaCrecimiento = objblTasaCrecimiento.ListarCrecimXTiempo(IdDiseno);


            if (lobjBETasaCrecimiento == null)
                throw new ArgumentException("IdDiseno " + IdDiseno + " no es correcto");

            return Json(new { data = lobjBETasaCrecimiento }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CargarVariableVehiculo(int Id)
        {
            BLTasaCrecimiento objblTasaCrecimiento = new BLTasaCrecimiento();
            List<BETasaCrecimiento> lobjBETasaCrecimiento = new List<BETasaCrecimiento>();
            lobjBETasaCrecimiento = objblTasaCrecimiento.ListarCrecimXVehiculo(Id);

            if (lobjBETasaCrecimiento == null)
                throw new ArgumentException("Id " + Id + " no es correcto");

            return Json(new { data = lobjBETasaCrecimiento }, JsonRequestBehavior.AllowGet);
        }



        public int GuardarCrecXTiempo(int NroAnio, string Valor, int IdDiseno)
        {
            try
            {
                int Id_Tasa_Crec_X_Tiempo = 0;

                BLTasaCrecimiento bLTasaCrecimiento = new BLTasaCrecimiento();
                BETasaCrecimiento beTasaCrecimiento = new BETasaCrecimiento();
                beTasaCrecimiento.NroAnio = NroAnio;
                beTasaCrecimiento.Valor = Convert.ToDecimal(Valor);
                beTasaCrecimiento.Id_Diseno = IdDiseno;

                Id_Tasa_Crec_X_Tiempo = bLTasaCrecimiento.GuardarCrecXTiempo(beTasaCrecimiento);


                return Id_Tasa_Crec_X_Tiempo;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public int GuardarCrecXVehiculo(int Id_Tipo_Vehiculo, string Valor, int IdDiseno)
        {
            try
            {
                int Id_Tasa_Crec_X_Vehiculo = 0;

                BLTasaCrecimiento bLTasaCrecimiento = new BLTasaCrecimiento();
                BETasaCrecimiento beTasaCrecimiento = new BETasaCrecimiento();
                beTasaCrecimiento.Id_Tipo_Vehiculo = Id_Tipo_Vehiculo;
                beTasaCrecimiento.Valor = Convert.ToDecimal(Valor);
                beTasaCrecimiento.Id_Diseno = IdDiseno;

                Id_Tasa_Crec_X_Vehiculo = bLTasaCrecimiento.GuardarCrecXVehiculo(beTasaCrecimiento);


                return Id_Tasa_Crec_X_Vehiculo;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public int GuardarCrecConstante(string Valor, int IdDiseno)
        {
            try
            {
                int Id_Tasa_Crec_Constante = 0;

                BLTasaCrecimiento bLTasaCrecimiento = new BLTasaCrecimiento();
                BETasaCrecimiento beTasaCrecimiento = new BETasaCrecimiento();
                beTasaCrecimiento.Valor = Convert.ToDecimal(Valor);
                beTasaCrecimiento.Id_Diseno = IdDiseno;

                Id_Tasa_Crec_Constante = bLTasaCrecimiento.GuardarCrecConstante(beTasaCrecimiento);


                return Id_Tasa_Crec_Constante;
            }
            catch (Exception)
            {

                throw;
            }

        }



        public decimal ActualizarCrecXTiempo(int NroAnio, string Valor, int IdDiseno, int Id_Tasa_Crec_X_Tiempo)
        {
            try
            {
                int upd = 0;

                BLTasaCrecimiento bLTasaCrecimiento = new BLTasaCrecimiento();
                BETasaCrecimiento beTasaCrecimiento = new BETasaCrecimiento();
                beTasaCrecimiento.NroAnio = NroAnio;
                beTasaCrecimiento.Valor = Convert.ToDecimal(Valor);
                beTasaCrecimiento.Id_Diseno = IdDiseno;
                beTasaCrecimiento.Id_Tasa_Crec_X_Tiempo = Id_Tasa_Crec_X_Tiempo;

                upd = bLTasaCrecimiento.ActualizarCrecXTiempo(beTasaCrecimiento);

                //Invocamos el total de Variable x Tiempo
                decimal TotalTasaCrecimiento = 0;
                BLReglas bLReglas = new BLReglas();
                TotalTasaCrecimiento = bLReglas.TotalTasaCrecimiento(IdDiseno);

                //Fin

                return TotalTasaCrecimiento;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public int ActualizarCrecXVehiculo(int Id_Tipo_Vehiculo, string Valor, int IdDiseno, int Id_Tasa_Crec_X_Vehiculo)
        {
            try
            {
                int upd = 0;

                BLTasaCrecimiento bLTasaCrecimiento = new BLTasaCrecimiento();
                BETasaCrecimiento beTasaCrecimiento = new BETasaCrecimiento();
                beTasaCrecimiento.Id_Tipo_Vehiculo = Id_Tipo_Vehiculo;
                beTasaCrecimiento.Valor = Convert.ToDecimal(Valor);
                beTasaCrecimiento.Id_Diseno = IdDiseno;
                beTasaCrecimiento.Id_Tasa_Crec_X_Vehiculo = Id_Tasa_Crec_X_Vehiculo;

                upd = bLTasaCrecimiento.ActualizarCrecXVehiculo(beTasaCrecimiento);


                return upd;
            }
            catch (Exception)
            {

                throw;
            }

        }






        public decimal CalculoEE(BEMatrizTasaCrecimiento objMatrizTasaCrecimiento, int idTipoTasaCrec, decimal FDxFC, decimal Fp, int Id_Repet_Eq)
        {
            try
            {
                decimal calculoEE = 0;
                //decimal calculoEEXVehi = 0;
                int idDiseno = 0;
                idDiseno = objMatrizTasaCrecimiento.Id_Diseno;
                BLCalculoEE blCalculoEE = new BLCalculoEE();
                BLRepeticionesEqui blRepetEquivalentes = new BLRepeticionesEqui();
                BLVehiculosIMD objBLVehiculosIMD = new BLVehiculosIMD();
                List<BETasaCrecimiento> lobjBETasaCrecimiento = new List<BETasaCrecimiento>();
                List<BEMatrizEE> LstMatrizEEResultado = new List<BEMatrizEE>();

                LstMatrizEEResultado = blCalculoEE.ListaResultadoEE(objMatrizTasaCrecimiento, idTipoTasaCrec, FDxFC, Fp);

                List<BEVehiculosIMD> lobVehiculosIMD = new List<BEVehiculosIMD>();
                lobVehiculosIMD = objBLVehiculosIMD.VehiculosXDiseno(idDiseno);
                decimal deccalculoEE = 0;


                foreach (BEVehiculosIMD item in lobVehiculosIMD)
                {
                    deccalculoEE = 0;
                    var resultadoIMD = from vehiculo in LstMatrizEEResultado
                                       where vehiculo.Id_Vehiculos == item.Id_Vehiculos
                                       select vehiculo;

                    foreach (BEMatrizEE itemv in resultadoIMD)// Recorremos la  lista para obtener los valores IMD y FVP USP_Sel_Info_Matriz_EE
                    {

                        deccalculoEE = deccalculoEE + itemv.valorEEMatriz;

                    }

                    BLVehiculosIMD blVehiculosIMD = new BLVehiculosIMD();
                    blVehiculosIMD.ActualizaVehiculosIMD(idDiseno, deccalculoEE, item.Id_Vehiculos);


                }


                foreach (BEMatrizEE item in LstMatrizEEResultado)
                {
                    calculoEE = calculoEE + item.valorEEMatriz;

                }

                BERepeticionesEqui objBERepeticionesEqui = new BERepeticionesEqui();
                objBERepeticionesEqui.Id_Diseno = idDiseno;
                objBERepeticionesEqui.Valor_EE_Total = calculoEE;

                int i = 0;
                i = blRepetEquivalentes.ActualizarRepeticionesEqui(objBERepeticionesEqui);




                return calculoEE;
            }
            catch (Exception e)
            {

                throw;
            }

        }

        //public decimal CalculoEExVehiculo(BEMatrizTasaCrecimiento objMatrizTasaCrecimiento, int idTipoTasaCrec, decimal FDxFC, decimal Fp, int IdVehiculo, int TipoVehiculo, int strId_Repet_Equivalentes)
        //{
        //    try
        //    {
        //        decimal calculoEEXVehi = 0;

        //        BLCalculoEE blCalculoEE = new BLCalculoEE();
        //        List<BETasaCrecimiento> lobjBETasaCrecimiento = new List<BETasaCrecimiento>();
        //        List<BEMatrizEE> LstMatrizEEResultado = new List<BEMatrizEE>();

        //        LstMatrizEEResultado = blCalculoEE.ListaResultadoEE(objMatrizTasaCrecimiento, idTipoTasaCrec, FDxFC, Fp);

        //        calculoEEXVehi = blCalculoEE.CalculoEExVehi(LstMatrizEEResultado, TipoVehiculo, IdVehiculo);

        //        Version DEMO
        //        BLVehiculosIMD blVehiculosIMD = new BLVehiculosIMD();
        //        BEVehiculosIMD lobjBEBEVehiculosIMD = new BEVehiculosIMD();
        //        lobjBEBEVehiculosIMD.Id_Vehiculos = IdVehiculo;
        //        lobjBEBEVehiculosIMD.Id_Diseno = objMatrizTasaCrecimiento.Id_Diseno;
        //        lobjBEBEVehiculosIMD.Id_Repet_Equivalentes = strId_Repet_Equivalentes;
        //        lobjBEBEVehiculosIMD.Valor_EE = calculoEEXVehi;

        //        blVehiculosIMD.ActualizaVehiculosIMD(lobjBEBEVehiculosIMD);
        //        Version DEMO

        //        return calculoEEXVehi;
        //    }
        //    catch (Exception e)
        //    {

        //        throw;
        //    }

        //}



        public double ModuloRotura(decimal valor, decimal ResisCompre)
        {
            try
            {
                double ModRotura = 0;

                BLReglas bLReglas = new BLReglas();

                ModRotura = bLReglas.ModuloRotura(Convert.ToDouble(valor), Convert.ToDouble(ResisCompre));

                return ModRotura;
            }
            catch (Exception)
            {

                throw;
            }

        }


        public double ModuloElasticidad(decimal ResisCompre)
        {
            try
            {
                double ModElastic = 0;

                BLReglas bLReglas = new BLReglas();

                ModElastic = bLReglas.ModuloElasticidad(Convert.ToDouble(ResisCompre));

                return ModElastic;
            }
            catch (Exception)
            {

                throw;
            }

        }
        


        public double ModuloReaccion_KEquivMpaM(decimal valor)
        {
            try
            {
                double KEquivMpaM = 0;

                BLReglas bLReglas = new BLReglas();

                KEquivMpaM = bLReglas.CalculoKEquivMpaM(Convert.ToDouble(valor));

                return KEquivMpaM;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public double ModuloReaccion_CalculoKgCm3(decimal valor)
        {
            try
            {
                double CalculoKgCm3 = 0;

                BLReglas bLReglas = new BLReglas();

                CalculoKgCm3 = bLReglas.CalculoKgCm3(Convert.ToDouble(valor));

                return CalculoKgCm3;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public double ModuloReaccion_CalcuKeqkgcm3(decimal k1, decimal ko, decimal hCm)
        {
            try
            {
                double CalcuKeqkgcm3 = 0;

                BLReglas bLReglas = new BLReglas();

                CalcuKeqkgcm3 = bLReglas.CalcuKeqkgcm3(Convert.ToDouble(k1), Convert.ToDouble(ko), Convert.ToDouble(hCm));

                return CalcuKeqkgcm3;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public double ModuloReaccion_CalcuKeqMpa(decimal valor)
        {
            try
            {
                double CalcuKeqMpa = 0;

                BLReglas bLReglas = new BLReglas();

                CalcuKeqMpa = bLReglas.CalcuKeqMpa(Convert.ToDouble(valor));

                return CalcuKeqMpa;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //CalcuKeqMpa





    }
}