using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS_Ga2.Entity;
using SIS_Ga2.Entity;
using SIS_Ga2.DataAccess;
using System.Configuration;
using System.Web.UI.DataVisualization.Charting;
using Microsoft.SolverFoundation.Services;

namespace SIS_Ga2.Business
{
    public class BLReglas


    {

        //Parametro de Diseño
        //DESVIACIÓN ESTÁNDAR NORMAL (ZR)
        public double calcularDesvEstandZR(BECalculos objEntidad)
        {
            try
            {
                Chart Chart1 = new Chart();
                double resultadoMR = 0;
                double constanteZR = Convert.ToDouble(ConfigurationManager.AppSettings["constanteZR"].ToString());//100               
                //resultadoMR = (Chart1.DataManipulator.Statistics.InverseNormalDistribution(objEntidad.valorConfiabR / constanteZR)) * -1;
                resultadoMR = Math.Round((Chart1.DataManipulator.Statistics.InverseNormalDistribution(objEntidad.valorConfiabR / constanteZR)) * -1, 2);
                return resultadoMR;
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Parametro de Diseño
        //DIFERENCIA DE SERVICIABILIDAD (∆PSI)
        public double calcularPSI(BECalculos objEntidad)
        {
            try
            {

                double resultadoPSI = 0;

                resultadoPSI = objEntidad.ServIniPI - objEntidad.ServFinPT;
                return resultadoPSI;
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Parametro de Diseño
        //MÓDULO DE RESILENCIA (SUBRASANTE) ASFALTO
        public double calcularModResilenciaAsf(BECalculos objEntidad)
        {
            try
            {

                double resultadoModResi_ASF = 0;
                double potencia_asf = Convert.ToDouble(ConfigurationManager.AppSettings["potencia_ASF"].ToString());//0.64
                double constanteCBR_ASF = Convert.ToDouble(ConfigurationManager.AppSettings["constanteCBR_ASF"].ToString());//2.555
                //resultadoModResi_ASF = Math.Pow(objEntidad.valorCBR, potencia_asf) * constanteCBR_ASF;
                resultadoModResi_ASF = Math.Round(Math.Pow(objEntidad.valorCBR, potencia_asf) * constanteCBR_ASF, 0);
                return resultadoModResi_ASF;
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Capas de Pavimento
        //N18 Nom - primer valor
        public double calcularN18Nom(BECalculos objEntidad)
        {
            try
            {

                double resultadoN18Nomi = 0;

                resultadoN18Nomi = Math.Log10(objEntidad.CantESAL);
                return resultadoN18Nomi;
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Capas de Pavimento
        //N18 Calc - primer valor
        public double calcularN18Calc1(BECalculos objEntidad)
        {
            try
            {

                double resultadoN18Calc1 = 0;
                double resultadoN18Calc2 = 0;
                double resultadoN18Calc3 = 0;
                double resultadoN18Calc4 = 0;
                double resultadoN18Calc5 = 0;

                double constanteN18_3 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteN18_3"].ToString());//9.36
                double constanteN18_4 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteN18_4"].ToString());//0.2
                double constanteN18_5 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteN18_5"].ToString());//0.4
                double constanteN18_6 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteN18_6"].ToString());//1094
                double constanteN18_7 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteN18_7"].ToString());//5.19
                double constanteN18_8 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteN18_8"].ToString());//2.32
                double constanteN18_9 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteN18_9"].ToString());//8.07

                resultadoN18Calc1 = objEntidad.DesviEstandar * objEntidad.ErrorCombiEstandar;
                resultadoN18Calc2 = constanteN18_3 * Math.Log10(objEntidad.SNReq + 1) - constanteN18_4;
                resultadoN18Calc3 = objEntidad.N18Calc2 / (constanteN18_5 + constanteN18_6 / (Math.Pow((objEntidad.SNReq + 1), constanteN18_7)));
                resultadoN18Calc4 = constanteN18_8 * Math.Log10(objEntidad.valorMR) - constanteN18_9;

                resultadoN18Calc5 = resultadoN18Calc1 + resultadoN18Calc2 + resultadoN18Calc3 + resultadoN18Calc4;


                return resultadoN18Calc5;

            }

            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Capas de Pavimento
        //N18 Calc - Segundo valor
        public double calcularN18Calc2(BECalculos objEntidad)
        {
            try
            {

                //double resultadoN18calc2 = 0;
                double DifServiciabilidad = 0;
                double resultadoN18calcLog = 0;

                double constanteN18_1 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteN18_1"].ToString());//4.2
                double constanteN18_2 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteN18_2"].ToString());//1.15
                DifServiciabilidad = Convert.ToDouble(objEntidad.DifServiciabilidad);
                resultadoN18calcLog = Math.Log10(DifServiciabilidad / (constanteN18_1 - constanteN18_2));
                return resultadoN18calcLog;
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }


        //Capas de Pavimento
        //SN req
        //public double calcularSNReq(BECalculos objEntidad)
        //{
        //    double resultadoN18Calc = 0;

        //    //double n18nom = 0;           
        //    int encontrado = 0;
        //    int calculo = 0;
        //    double ResultadoSNReq = 0;
        //    string valor = "";
        //    //  calcular el sn req
        //    for (double i = 0; i <= 100; i++)
        //    {
        //        if (encontrado == 0)
        //        {
        //            for (double j = 0; j <= 9; j++)
        //            {
        //                if (encontrado == 0)
        //                {
        //                    for (double k = 0; k <= 9; k++)
        //                    {
        //                        for (double l = 0; l <= 9; l++)
        //                        {
        //                            for (double m = 0; m <= 9; m++)
        //                            {
        //                                if (encontrado == 0)
        //                                {

        //                                    valor = i.ToString() + "." + j.ToString() + k.ToString() + l.ToString() + m.ToString();
        //                                    objEntidad.SNReq = Convert.ToDouble(valor);

        //                                    resultadoN18Calc = Math.Round(calcularN18Calc1(objEntidad), 5);

        //                                    //calculo = Math.Round(objEntidad.N18Nom - resultadoN18Calc, 3);
        //                                    //listBox1.ClearSelected(); 

        //                                    //if ((calculo<=0.01) && (calculo>0) )
        //                                    if ((Math.Round(objEntidad.N18Nom, 3) == Math.Round(resultadoN18Calc, 3)))
        //                                    {
        //                                        // textn18calc.Text = resultadoN18Calc.ToString();
        //                                        ResultadoSNReq = Math.Round(objEntidad.SNReq, 2);
        //                                        calculo = 1;
        //                                        encontrado = 1;
        //                                        break;
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    if (calculo == 0)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return ResultadoSNReq;

        //    }
        //}

        //Calculo del SN REq
        public double calcularSNReq(BECalculos objEntidad)
        {
            double resultadoN18Calc = 0;

            double constanteN18_3 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteN18_3"].ToString());//9.36
            double constanteN18_4 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteN18_4"].ToString());//0.2
            double constanteN18_5 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteN18_5"].ToString());//0.4
            double constanteN18_6 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteN18_6"].ToString());//1094
            double constanteN18_7 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteN18_7"].ToString());//5.19
            double constanteN18_8 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteN18_8"].ToString());//2.32
            double constanteN18_9 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteN18_9"].ToString());//8.07

            // Define el modelo
            SolverContext context = SolverContext.GetContext();
            context.ClearModel();
            Model model = context.CreateModel();
            //Crea las variables
            Decision x = new Decision(Domain.RealNonnegative, "SNREQ");
            model.AddDecisions(x);
            model.AddConstraints("N18Calc",
            //objEntidad.N18Calc == objEntidad.DesviEstandar * objEntidad.ErrorCombiEstandar + constanteN18_3 * Model.Log10(x + 1) - constanteN18_4 + objEntidad.N18Calc2 / (constanteN18_5 + constanteN18_6 / Model.Power((x + 1), constanteN18_7)) + constanteN18_8 * Math.Log10(objEntidad.valorMR) - constanteN18_9);
            objEntidad.N18Nom == objEntidad.DesviEstandar * objEntidad.ErrorCombiEstandar + constanteN18_3 * Model.Log10(x + 1) - constanteN18_4 + objEntidad.N18Calc2 / (constanteN18_5 + constanteN18_6 / Model.Power((x + 1), constanteN18_7)) + constanteN18_8 * Math.Log10(objEntidad.valorMR) - constanteN18_9);
            // Add non-negative variables
            model.AddConstraints("nonnegative", x >= 0);

            // Add goal - what we want to maximize
            model.AddGoal("cost", GoalKind.Maximize, objEntidad.N18Calc);

            Solution solution = context.Solve();
            resultadoN18Calc = x.ToDouble();
            return resultadoN18Calc;
        }



        public double calcularFVP(BECalculos objEntidad)
        {
            try
            {
                string TipoDiseno, Id_TipoVehiculo, Id_Vehiculo;
                double resultadoFVP = 0;
                TipoDiseno = ConfigurationManager.AppSettings["TipoAsfalto"].ToString();//ASFALTO (MAYUSCULA)
                Id_TipoVehiculo = ConfigurationManager.AppSettings["Id_TipoVehiculo"].ToString();//1,2,3,4,5,6 (id de tipo vehiculo tabla Tipo_Vehiculo)
                Id_Vehiculo = ConfigurationManager.AppSettings["Id_Vehiculo"].ToString();//1,2,3,4,5,6..hasta el ultimo que es 22 (id de vehiculo tabla [Tipo_Vehiculo])

                //Constantes para Vehiculos
                double constanteVehiculos = Convert.ToDouble(ConfigurationManager.AppSettings["constanteVehiculos"].ToString());// 6.6
                double constantePotVehi1 = Convert.ToDouble(ConfigurationManager.AppSettings["constantePotVehi1"].ToString());// 4
                double constantePotVehi2 = Convert.ToDouble(ConfigurationManager.AppSettings["constantePotVehi2"].ToString());// 4.1

                //Constantes para Camionetas
                double constanteCamionetas = Convert.ToDouble(ConfigurationManager.AppSettings["constanteCamionetas"].ToString());// 6.6
                double constantePotCam1 = Convert.ToDouble(ConfigurationManager.AppSettings["constantePotCam1"].ToString());// 4
                double constantePotCam2 = Convert.ToDouble(ConfigurationManager.AppSettings["constantePotCam2"].ToString());// 4.1

                //Constantes para Buses
                double constanteBuses1 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteBuses1"].ToString());// 6.6
                double constanteBuses2 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteBuses2"].ToString());// 8.2
                double constantePot1 = Convert.ToDouble(ConfigurationManager.AppSettings["constantePot1"].ToString());// 4
                double constantePot2 = Convert.ToDouble(ConfigurationManager.AppSettings["constantePot2"].ToString());// 4.1
                double constantePot3 = Convert.ToDouble(ConfigurationManager.AppSettings["constantePot3"].ToString());// 3.9
                //Buses - Vehiculo=B3

                double constanteBuses3 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteBuses3"].ToString());// 15.1
                double constanteBuses4 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteBuses4"].ToString());// 13.3

                //Constante para camiones
                double constantecamiones1 = Convert.ToDouble(ConfigurationManager.AppSettings["constantecamiones1"].ToString());// 6.6
                double constantecamiones2 = Convert.ToDouble(ConfigurationManager.AppSettings["constantecamiones2"].ToString());// 8.2
                double constantecamiones3 = Convert.ToDouble(ConfigurationManager.AppSettings["constantecamiones3"].ToString());// 15.1
                double constantecamiones4 = Convert.ToDouble(ConfigurationManager.AppSettings["constantecamiones4"].ToString());// 13.3
                double constantecamiones5 = Convert.ToDouble(ConfigurationManager.AppSettings["constantecamiones5"].ToString());// 21.8
                double constantecamiones6 = Convert.ToDouble(ConfigurationManager.AppSettings["constantecamiones6"].ToString());// 17.5


                //Constante para Semi Trailers
                double constanteSemiTrailer1 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteSemiTrailer1"].ToString());// 6.6
                double constanteSemiTrailer2 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteSemiTrailer2"].ToString());// 8.2
                double constanteSemiTrailer3 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteSemiTrailer3"].ToString());// 15.1
                double constanteSemiTrailer4 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteSemiTrailer4"].ToString());// 13.3
                double constanteSemiTrailer5 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteSemiTrailer5"].ToString());// 21.8
                double constanteSemiTrailer6 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteSemiTrailer6"].ToString());// 17.5

                //Constante para  Trailers
                double constanteTrailer1 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteTrailer1"].ToString());// 6.6
                double constanteTrailer2 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteTrailer2"].ToString());// 8.2
                double constanteTrailer3 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteTrailer3"].ToString());// 15.1
                double constanteTrailer4 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteTrailer4"].ToString());// 13.3
                double constanteTrailer5 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteTrailer5"].ToString());// 21.8
                double constanteTrailer6 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteTrailer6"].ToString());// 17.5

                double resultE1 = 0;
                double resultE2 = 0;
                double resultE3 = 0;
                double resultE4 = 0;
                double resultE5 = 0;

                double PotenciaE1 = 0;
                double PotenciaE2 = 0;
                double PotenciaE3 = 0;
                double PotenciaE4 = 0;
                double PotenciaE5 = 0;

                //Vehiculos
                if (objEntidad.Id_TipoVehiculo.ToString() == Id_TipoVehiculo.Substring(0, 1))
                {
                    string a = Id_TipoVehiculo.Substring(0, 1);
                    resultE1 = objEntidad.PesoE1 / constanteVehiculos;
                    resultE2 = objEntidad.PesoE2 / constanteVehiculos;

                }

                //Camionetas
                if (objEntidad.Id_TipoVehiculo.ToString() == Id_TipoVehiculo.Substring(2, 1))
                {

                    resultE1 = objEntidad.PesoE1 / constanteCamionetas;
                    resultE2 = objEntidad.PesoE2 / constanteCamionetas;

                }


                //CALCULO DE POTENCIAS
                //============================

                //1 - Vehiculos
                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_TipoVehiculo.ToString() == Id_TipoVehiculo.Substring(0, 1)))// si es ASFALTO y si es Vehiculos (Id_Tipo_Vehiculo=1)
                {

                    PotenciaE1 = Math.Pow(resultE1, constantePotVehi1);
                    PotenciaE2 = Math.Pow(resultE2, constantePotVehi1);
                }
                else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_TipoVehiculo.ToString() == Id_TipoVehiculo.Substring(0, 1)))
                {
                    PotenciaE1 = Math.Pow(resultE1, constantePotVehi2);
                    PotenciaE2 = Math.Pow(resultE2, constantePotVehi2);
                }

                //2- Camionetas
                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_TipoVehiculo.ToString() == Id_TipoVehiculo.Substring(2, 1)))// si es ASFALTO y si es Camioneta (Id_Tipo_Vehiculo=2)
                {

                    PotenciaE1 = Math.Pow(resultE1, constantePotCam1);
                    PotenciaE2 = Math.Pow(resultE2, constantePotCam1);
                }
                else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_TipoVehiculo.ToString() == Id_TipoVehiculo.Substring(2, 1)))
                {
                    PotenciaE1 = Math.Pow(resultE1, constantePotCam2);
                    PotenciaE2 = Math.Pow(resultE2, constantePotCam2);
                }




                //Buses Y TIPO DE vehiculo "B2" = id_vehiculo=7
                if (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(12, 1))
                {
                    resultE1 = objEntidad.PesoE1 / constanteBuses1;
                    resultE2 = objEntidad.PesoE2 / constanteBuses2;
                }

                //Tipo diseño ASFALTO Buses Y TIPO DE vehiculo "B3" = id_vehiculo=8
                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(14, 1)))
                {
                    resultE1 = objEntidad.PesoE1 / constanteBuses1;
                    resultE2 = objEntidad.PesoE2 / constanteBuses3;
                }
                else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(14, 1)))

                {
                    resultE1 = objEntidad.PesoE1 / constanteBuses1;
                    resultE2 = objEntidad.PesoE2 / constanteBuses4;

                }

                //Tipo diseño ASFALTO  Y TIPO DE vehiculo "B4" = id_vehiculo=9
                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(16, 1)))
                {
                    resultE1 = objEntidad.PesoE1 / constanteBuses1;
                    resultE2 = objEntidad.PesoE2 / constanteBuses1;
                    resultE3 = objEntidad.PesoE3 / constanteBuses3;
                }
                else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(16, 1)))

                {
                    resultE1 = objEntidad.PesoE1 / constanteBuses1;
                    resultE2 = objEntidad.PesoE2 / constanteBuses1;
                    resultE3 = objEntidad.PesoE3 / constanteBuses4;

                }




                //SI ES ASFALTO Y B2 id_vehiculo=7

                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(12, 1)))
                {

                    PotenciaE1 = Math.Pow(resultE1, constantePot1);
                    PotenciaE2 = Math.Pow(resultE2, constantePot1);
                }
                else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(12, 1)))
                {
                    PotenciaE1 = Math.Pow(resultE1, constantePot2);
                    PotenciaE2 = Math.Pow(resultE2, constantePot2);
                }

                //Buses Y TIPO DE vehiculo "B3" = id_vehiculo=8
                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(14, 1)))//SI ES ASFALTO Y B3
                {

                    PotenciaE1 = Math.Pow(resultE1, constantePot1);
                    PotenciaE2 = Math.Pow(resultE2, constantePot1);
                }
                else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(14, 1)))//SI NO ES ASFALTO Y B3
                {
                    PotenciaE1 = Math.Pow(resultE1, constantePot2);
                    PotenciaE2 = Math.Pow(resultE2, constantePot2);
                }


                //Buses Y TIPO DE vehiculo "B4" = id_vehiculo=9
                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(16, 1)))//SI ES ASFALTO Y B4
                {

                    PotenciaE1 = Math.Pow(resultE1, constantePot1);
                    PotenciaE2 = Math.Pow(resultE2, constantePot1);
                    PotenciaE3 = Math.Pow(resultE3, constantePot1);
                }
                else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(16, 1)))//SI NO ES ASFALTO Y B4
                {
                    PotenciaE1 = Math.Pow(resultE1, constantePot2);
                    PotenciaE2 = Math.Pow(resultE2, constantePot2);
                    PotenciaE3 = Math.Pow(resultE3, constantePot2);
                }



                //tIPO DE vehiculo "C2" = id_vehiculo=10
                if (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(18, 2))
                {
                    resultE1 = objEntidad.PesoE1 / constantecamiones1;
                    resultE2 = objEntidad.PesoE2 / constantecamiones2;

                }

                //Tipo diseño ASFALTO  Y TIPO DE vehiculo "C3" = id_vehiculo=11
                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(21, 2)))

                {
                    resultE1 = objEntidad.PesoE1 / constantecamiones1;
                    resultE2 = objEntidad.PesoE2 / constantecamiones3;


                }
                else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(21, 2)))

                {
                    resultE1 = objEntidad.PesoE1 / constantecamiones1;
                    resultE2 = objEntidad.PesoE2 / constantecamiones4;

                }



                //Tipo diseño ASFALTO  Y TIPO DE vehiculo "C4" = id_vehiculo=12
                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(24, 2)))

                {
                    resultE1 = objEntidad.PesoE1 / constantecamiones1;
                    resultE2 = objEntidad.PesoE2 / constantecamiones5;


                }
                else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(24, 2)))

                {
                    resultE1 = objEntidad.PesoE1 / constantecamiones1;
                    resultE2 = objEntidad.PesoE2 / constantecamiones6;

                }


                //Tipo diseño ASFALTO  Y TIPO DE vehiculo "2S1" = id_vehiculo=13
                if (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(27, 2))
                {
                    resultE1 = objEntidad.PesoE1 / constanteSemiTrailer1;
                    resultE2 = objEntidad.PesoE2 / constanteSemiTrailer2;
                    resultE3 = objEntidad.PesoE3 / constanteSemiTrailer2;

                }

                //Tipo diseño ASFALTO  Y TIPO DE vehiculo "2S2" = id_vehiculo=14
                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(30, 2)))
                {
                    resultE1 = objEntidad.PesoE1 / constanteSemiTrailer1;
                    resultE2 = objEntidad.PesoE2 / constanteSemiTrailer2;
                    resultE3 = objEntidad.PesoE3 / constanteSemiTrailer3;


                }
                else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(30, 2)))
                {
                    resultE1 = objEntidad.PesoE1 / constanteSemiTrailer1;
                    resultE2 = objEntidad.PesoE2 / constanteSemiTrailer2;
                    resultE3 = objEntidad.PesoE3 / constanteSemiTrailer4;

                }

                //Tipo diseño ASFALTO  Y TIPO DE vehiculo "2S3" = id_vehiculo=15
                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(33, 2)))
                {
                    resultE1 = objEntidad.PesoE1 / constanteSemiTrailer1;
                    resultE2 = objEntidad.PesoE2 / constanteSemiTrailer2;
                    resultE3 = objEntidad.PesoE3 / constanteSemiTrailer5;


                }
                else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(33, 2)))
                {
                    resultE1 = objEntidad.PesoE1 / constanteSemiTrailer1;
                    resultE2 = objEntidad.PesoE2 / constanteSemiTrailer2;
                    resultE3 = objEntidad.PesoE3 / constanteSemiTrailer6;

                }


                //Tipo diseño ASFALTO  Y TIPO DE vehiculo "3S1" = id_vehiculo=16
                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(36, 2)))
                {
                    resultE1 = objEntidad.PesoE1 / constanteSemiTrailer1;
                    resultE2 = objEntidad.PesoE2 / constanteSemiTrailer3;
                    resultE3 = objEntidad.PesoE3 / constanteSemiTrailer2;


                }
                else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(36, 2)))
                {
                    resultE1 = objEntidad.PesoE1 / constanteSemiTrailer1;
                    resultE2 = objEntidad.PesoE2 / constanteSemiTrailer4;
                    resultE3 = objEntidad.PesoE3 / constanteSemiTrailer2;

                }

                //Tipo diseño ASFALTO  Y TIPO DE vehiculo "3S2" = id_vehiculo=17
                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(39, 2)))
                {
                    resultE1 = objEntidad.PesoE1 / constanteSemiTrailer1;
                    resultE2 = objEntidad.PesoE2 / constanteSemiTrailer3;
                    resultE3 = objEntidad.PesoE3 / constanteSemiTrailer3;


                }
                else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(39, 2)))
                {
                    resultE1 = objEntidad.PesoE1 / constanteSemiTrailer1;
                    resultE2 = objEntidad.PesoE2 / constanteSemiTrailer4;
                    resultE3 = objEntidad.PesoE3 / constanteSemiTrailer4;

                }

                //Tipo diseño ASFALTO  Y TIPO DE vehiculo "3S3" = id_vehiculo=18
                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(42, 2)))
                {
                    resultE1 = objEntidad.PesoE1 / constanteSemiTrailer1;
                    resultE2 = objEntidad.PesoE2 / constanteSemiTrailer3;
                    resultE3 = objEntidad.PesoE3 / constanteSemiTrailer5;


                }
                else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(42, 2)))
                {
                    resultE1 = objEntidad.PesoE1 / constanteSemiTrailer1;
                    resultE2 = objEntidad.PesoE2 / constanteSemiTrailer4;
                    resultE3 = objEntidad.PesoE3 / constanteSemiTrailer6;

                }

                // TIPO DE vehiculo "C2" = id_vehiculo=10
                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(18, 2)))//SI ES ASFALTO Y B4
                {

                    PotenciaE1 = Math.Pow(resultE1, constantePot1);
                    PotenciaE2 = Math.Pow(resultE2, constantePot1);

                }
                else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(18, 2)))//SI NO ES ASFALTO Y B4
                {
                    PotenciaE1 = Math.Pow(resultE1, constantePot2);
                    PotenciaE2 = Math.Pow(resultE2, constantePot2);

                }

                // TIPO DE vehiculo "C3" = id_vehiculo=11
                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(21, 2)))//SI ES ASFALTO Y B4
                {

                    PotenciaE1 = Math.Pow(resultE1, constantePot1);
                    PotenciaE2 = Math.Pow(resultE2, constantePot1);

                }
                else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(21, 2)))//SI NO ES ASFALTO Y B4
                {
                    PotenciaE1 = Math.Pow(resultE1, constantePot2);
                    PotenciaE2 = Math.Pow(resultE2, constantePot2);

                }


                // TIPO DE vehiculo "C4" = id_vehiculo=12
                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(24, 2)))//SI ES ASFALTO Y B4
                {

                    PotenciaE1 = Math.Pow(resultE1, constantePot1);
                    PotenciaE2 = Math.Pow(resultE2, constantePot3);

                }
                else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(24, 2)))//SI NO ES ASFALTO Y B4
                {
                    PotenciaE1 = Math.Pow(resultE1, constantePot2);
                    PotenciaE2 = Math.Pow(resultE2, constantePot1);

                }

                // TIPO DE vehiculo "2s1" = id_vehiculo=13
                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(27, 2)))//SI ES ASFALTO Y 2s1
                {

                    PotenciaE1 = Math.Pow(resultE1, constantePot1);
                    PotenciaE2 = Math.Pow(resultE2, constantePot1);
                    PotenciaE3 = Math.Pow(resultE2, constantePot1);

                }
                else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(27, 2)))//SI NO ES ASFALTO Y 2s1
                {
                    PotenciaE1 = Math.Pow(resultE1, constantePot2);
                    PotenciaE2 = Math.Pow(resultE2, constantePot2);
                    PotenciaE3 = Math.Pow(resultE2, constantePot2);

                }

                // TIPO DE vehiculo "2s2" = id_vehiculo=14
                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(30, 2)))//SI ES ASFALTO Y 2s2
                {

                    PotenciaE1 = Math.Pow(resultE1, constantePot1);
                    PotenciaE2 = Math.Pow(resultE2, constantePot1);
                    PotenciaE3 = Math.Pow(resultE3, constantePot1);

                }
                else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(30, 2)))//SI NO ES ASFALTO Y 2s2
                {
                    PotenciaE1 = Math.Pow(resultE1, constantePot2);
                    PotenciaE2 = Math.Pow(resultE2, constantePot2);
                    PotenciaE3 = Math.Pow(resultE3, constantePot2);

                }
                // TIPO DE vehiculo "2s3" = id_vehiculo=15
                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(33, 2)))//SI ES ASFALTO Y 2s3
                {

                    PotenciaE1 = Math.Pow(resultE1, constantePot1);
                    PotenciaE2 = Math.Pow(resultE2, constantePot1);
                    PotenciaE3 = Math.Pow(resultE3, constantePot3);

                }
                else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(33, 2)))//SI NO ES ASFALTO Y 2s3
                {
                    PotenciaE1 = Math.Pow(resultE1, constantePot2);
                    PotenciaE2 = Math.Pow(resultE2, constantePot2);
                    PotenciaE3 = Math.Pow(resultE3, constantePot1);

                }
                // TIPO DE vehiculo "3s1" = id_vehiculo=16
                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(36, 2)))//SI ES ASFALTO Y 3s1
                {

                    PotenciaE1 = Math.Pow(resultE1, constantePot1);
                    PotenciaE2 = Math.Pow(resultE2, constantePot1);
                    PotenciaE3 = Math.Pow(resultE3, constantePot1);

                }
                else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(36, 2)))//SI NO ES ASFALTO Y B4
                {
                    PotenciaE1 = Math.Pow(resultE1, constantePot2);
                    PotenciaE2 = Math.Pow(resultE2, constantePot2);
                    PotenciaE3 = Math.Pow(resultE3, constantePot2);

                }

                // TIPO DE vehiculo "3s2" = id_vehiculo=17
                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(39, 2)))//SI ES ASFALTO Y B4
                {

                    PotenciaE1 = Math.Pow(resultE1, constantePot1);
                    PotenciaE2 = Math.Pow(resultE2, constantePot1);
                    PotenciaE3 = Math.Pow(resultE2, constantePot1);

                }
                else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(39, 2)))//SI NO ES ASFALTO Y B4
                {
                    PotenciaE1 = Math.Pow(resultE1, constantePot2);
                    PotenciaE2 = Math.Pow(resultE2, constantePot2);
                    PotenciaE3 = Math.Pow(resultE2, constantePot2);

                }

                // TIPO DE vehiculo "3s3" = id_vehiculo=18
                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(42, 2)))//SI ES ASFALTO Y B4
                {

                    PotenciaE1 = Math.Pow(resultE1, constantePot1);
                    PotenciaE2 = Math.Pow(resultE2, constantePot1);
                    PotenciaE3 = Math.Pow(resultE3, constantePot3);

                }
                else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(42, 2)))//SI NO ES ASFALTO Y B4
                {
                    PotenciaE1 = Math.Pow(resultE1, constantePot2);
                    PotenciaE2 = Math.Pow(resultE2, constantePot2);
                    PotenciaE3 = Math.Pow(resultE3, constantePot1);

                }



                //Tipo diseño ASFALTO  Y TIPO DE vehiculo "2T2" = id_vehiculo=19
                if (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(45, 2))

                {
                    resultE1 = objEntidad.PesoE1 / constanteTrailer1;
                    resultE2 = objEntidad.PesoE2 / constanteTrailer2;
                    resultE3 = objEntidad.PesoE3 / constanteTrailer2;
                    resultE4 = objEntidad.PesoE4 / constanteTrailer2;

                }



                //Tipo diseño ASFALTO  Y TIPO DE vehiculo "2T3" = id_vehiculo=20
                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(48, 2)))

                {
                    resultE1 = objEntidad.PesoE1 / constanteTrailer1;
                    resultE2 = objEntidad.PesoE2 / constanteTrailer3;
                    resultE3 = objEntidad.PesoE3 / constanteTrailer2;
                    resultE4 = objEntidad.PesoE4 / constanteTrailer3;


                }
                else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(48, 2)))

                {
                    resultE1 = objEntidad.PesoE1 / constanteTrailer1;
                    resultE2 = objEntidad.PesoE2 / constanteTrailer4;
                    resultE3 = objEntidad.PesoE3 / constanteTrailer2;
                    resultE4 = objEntidad.PesoE4 / constanteTrailer4;

                }


                //Tipo diseño ASFALTO  Y TIPO DE vehiculo "3T2" = id_vehiculo=21
                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(51, 2)))

                {
                    resultE1 = objEntidad.PesoE1 / constanteTrailer1;
                    resultE2 = objEntidad.PesoE2 / constanteTrailer3;
                    resultE3 = objEntidad.PesoE3 / constanteTrailer2;
                    resultE4 = objEntidad.PesoE4 / constanteTrailer2;


                }
                else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(51, 2)))

                {

                    resultE1 = objEntidad.PesoE1 / constanteTrailer1;
                    resultE2 = objEntidad.PesoE2 / constanteTrailer4;
                    resultE3 = objEntidad.PesoE3 / constanteTrailer2;
                    resultE4 = objEntidad.PesoE4 / constanteTrailer2;

                }

                //Tipo diseño ASFALTO  Y TIPO DE vehiculo ">3T3" = id_vehiculo=22
                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(54, 2)))

                {
                    resultE1 = objEntidad.PesoE1 / constanteTrailer1;
                    resultE2 = objEntidad.PesoE2 / constanteTrailer3;
                    resultE3 = objEntidad.PesoE3 / constanteTrailer3;
                    resultE4 = objEntidad.PesoE4 / constanteTrailer3;
                    resultE5 = objEntidad.PesoE5 / constanteTrailer3;

                }
                else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(54, 2)))

                {

                    resultE1 = objEntidad.PesoE1 / constanteTrailer1;
                    resultE2 = objEntidad.PesoE2 / constanteTrailer4;
                    resultE3 = objEntidad.PesoE3 / constanteTrailer4;
                    resultE4 = objEntidad.PesoE4 / constanteTrailer4;
                    resultE5 = objEntidad.PesoE5 / constanteTrailer4;

                }





                //3- Buses



                // TIPO DE vehiculo "2t2" = id_vehiculo=19
                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(45, 2)))//SI ES ASFALTO Y B4
                {

                    PotenciaE1 = Math.Pow(resultE1, constantePot1);
                    PotenciaE2 = Math.Pow(resultE2, constantePot1);
                    PotenciaE3 = Math.Pow(resultE3, constantePot1);
                    PotenciaE4 = Math.Pow(resultE4, constantePot1);

                }
                else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(45, 2)))//SI NO ES ASFALTO Y B4
                {
                    PotenciaE1 = Math.Pow(resultE1, constantePot2);
                    PotenciaE2 = Math.Pow(resultE2, constantePot2);
                    PotenciaE3 = Math.Pow(resultE3, constantePot2);
                    PotenciaE4 = Math.Pow(resultE4, constantePot2);
                }

                // TIPO DE vehiculo "2t3" = id_vehiculo=20
                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(48, 2)))//SI ES ASFALTO Y B4
                {

                    PotenciaE1 = Math.Pow(resultE1, constantePot1);
                    PotenciaE2 = Math.Pow(resultE2, constantePot1);
                    PotenciaE3 = Math.Pow(resultE3, constantePot1);
                    PotenciaE4 = Math.Pow(resultE4, constantePot1);

                }
                else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(48, 2)))//SI NO ES ASFALTO Y B4
                {
                    PotenciaE1 = Math.Pow(resultE1, constantePot2);
                    PotenciaE2 = Math.Pow(resultE2, constantePot2);
                    PotenciaE3 = Math.Pow(resultE3, constantePot2);
                    PotenciaE4 = Math.Pow(resultE4, constantePot2);
                }

                // TIPO DE vehiculo "3t2" = id_vehiculo=21
                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(51, 2)))//SI ES ASFALTO Y 3t2
                {

                    PotenciaE1 = Math.Pow(resultE1, constantePot1);
                    PotenciaE2 = Math.Pow(resultE2, constantePot1);
                    PotenciaE3 = Math.Pow(resultE3, constantePot1);
                    PotenciaE4 = Math.Pow(resultE4, constantePot1);

                }
                else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(51, 2)))//SI NO ES ASFALTO Y B4
                {
                    PotenciaE1 = Math.Pow(resultE1, constantePot2);
                    PotenciaE2 = Math.Pow(resultE2, constantePot2);
                    PotenciaE3 = Math.Pow(resultE3, constantePot2);
                    PotenciaE4 = Math.Pow(resultE4, constantePot2);
                }


                // TIPO DE vehiculo ">3T3" = id_vehiculo=22
                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(54, 2)))//SI ES ASFALTO Y >3T3
                {

                    PotenciaE1 = Math.Pow(resultE1, constantePot1);
                    PotenciaE2 = Math.Pow(resultE2, constantePot1);
                    PotenciaE3 = Math.Pow(resultE3, constantePot1);
                    PotenciaE4 = Math.Pow(resultE4, constantePot1);
                    PotenciaE5 = Math.Pow(resultE5, constantePot1);

                }
                else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(54, 2)))//SI NO ES ASFALTO Y B4
                {
                    PotenciaE1 = Math.Pow(resultE1, constantePot2);
                    PotenciaE2 = Math.Pow(resultE2, constantePot2);
                    PotenciaE3 = Math.Pow(resultE3, constantePot2);
                    PotenciaE4 = Math.Pow(resultE4, constantePot2);
                    PotenciaE5 = Math.Pow(resultE5, constantePot2);
                }
                //Buses enviado el ID VEhiculo
                return resultadoFVP = PotenciaE1 + PotenciaE2 + PotenciaE3 + PotenciaE4 + PotenciaE5;
                //double resultadoN18calc2 = 0;

            }

            catch (Exception ex)
            {

                throw ex;
            }
        }



        //public double calcularFVP(BECalculos objEntidad)
        //{
        //    try
        //    {
        //        string TipoDiseno, Id_TipoVehiculo, Id_Vehiculo;
        //        double resultadoFVP = 0;
        //        TipoDiseno = ConfigurationManager.AppSettings["TipoAsfalto"].ToString();//ASFALTO (MAYUSCULA)
        //        Id_TipoVehiculo = ConfigurationManager.AppSettings["Id_TipoVehiculo"].ToString();//1,2,3,4,5,6 (id de tipo vehiculo tabla Tipo_Vehiculo)
        //        Id_Vehiculo = ConfigurationManager.AppSettings["Id_Vehiculo"].ToString();//1,2,3,4,5,6..hasta el ultimo que es 22 (id de vehiculo tabla [Tipo_Vehiculo])

        //        //Constantes para Vehiculos
        //        double constanteVehiculos = Convert.ToDouble(ConfigurationManager.AppSettings["constanteVehiculos"].ToString());// 6.6
        //        double constantePotVehi1 = Convert.ToDouble(ConfigurationManager.AppSettings["constantePotVehi1"].ToString());// 4
        //        double constantePotVehi2 = Convert.ToDouble(ConfigurationManager.AppSettings["constantePotVehi2"].ToString());// 4.1

        //        //Constantes para Camionetas
        //        double constanteCamionetas = Convert.ToDouble(ConfigurationManager.AppSettings["constanteCamionetas"].ToString());// 6.6
        //        double constantePotCam1 = Convert.ToDouble(ConfigurationManager.AppSettings["constantePotCam1"].ToString());// 4
        //        double constantePotCam2 = Convert.ToDouble(ConfigurationManager.AppSettings["constantePotCam2"].ToString());// 4.1

        //        //Constantes para Buses
        //        double constanteBuses1 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteBuses1"].ToString());// 6.6
        //        double constanteBuses2 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteBuses2"].ToString());// 8.2
        //        double constantePot1 = Convert.ToDouble(ConfigurationManager.AppSettings["constantePot1"].ToString());// 4
        //        double constantePot2 = Convert.ToDouble(ConfigurationManager.AppSettings["constantePot2"].ToString());// 4.1
        //        double constantePot3 = Convert.ToDouble(ConfigurationManager.AppSettings["constantePot3"].ToString());// 3.9
        //        //Buses - Vehiculo=B3

        //        double constanteBuses3 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteBuses3"].ToString());// 15.1
        //        double constanteBuses4 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteBuses4"].ToString());// 13.3

        //        //Constante para camiones
        //        double constantecamiones1 = Convert.ToDouble(ConfigurationManager.AppSettings["constantecamiones1"].ToString());// 6.6
        //        double constantecamiones2 = Convert.ToDouble(ConfigurationManager.AppSettings["constantecamiones2"].ToString());// 8.2
        //        double constantecamiones3 = Convert.ToDouble(ConfigurationManager.AppSettings["constantecamiones3"].ToString());// 15.1
        //        double constantecamiones4 = Convert.ToDouble(ConfigurationManager.AppSettings["constantecamiones4"].ToString());// 13.3
        //        double constantecamiones5 = Convert.ToDouble(ConfigurationManager.AppSettings["constantecamiones5"].ToString());// 21.8
        //        double constantecamiones6 = Convert.ToDouble(ConfigurationManager.AppSettings["constantecamiones6"].ToString());// 17.5


        //        //Constante para Semi Trailers
        //        double constanteSemiTrailer1 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteSemiTrailer1"].ToString());// 6.6
        //        double constanteSemiTrailer2 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteSemiTrailer2"].ToString());// 8.2
        //        double constanteSemiTrailer3 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteSemiTrailer3"].ToString());// 15.1
        //        double constanteSemiTrailer4 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteSemiTrailer4"].ToString());// 13.3
        //        double constanteSemiTrailer5 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteSemiTrailer5"].ToString());// 21.8
        //        double constanteSemiTrailer6 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteSemiTrailer6"].ToString());// 17.5

        //        //Constante para  Trailers
        //        double constanteTrailer1 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteTrailer1"].ToString());// 6.6
        //        double constanteTrailer2 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteTrailer2"].ToString());// 8.2
        //        double constanteTrailer3 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteTrailer3"].ToString());// 15.1
        //        double constanteTrailer4 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteTrailer4"].ToString());// 13.3
        //        double constanteTrailer5 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteTrailer5"].ToString());// 21.8
        //        double constanteTrailer6 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteTrailer6"].ToString());// 17.5

        //        double resultE1 = 0;
        //        double resultE2 = 0;
        //        double resultE3 = 0;
        //        double resultE4 = 0;
        //        double resultE5 = 0;

        //        double PotenciaE1 = 0;
        //        double PotenciaE2 = 0;
        //        double PotenciaE3 = 0;
        //        double PotenciaE4 = 0;
        //        double PotenciaE5 = 0;

        //        //Vehiculos
        //        if (objEntidad.Id_TipoVehiculo.ToString() == Id_TipoVehiculo.Substring(0, 1))
        //        {

        //            resultE1 = objEntidad.PesoE1 / constanteVehiculos;
        //            resultE2 = objEntidad.PesoE2 / constanteVehiculos;

        //        }
        //        //Camionetas
        //        if (objEntidad.Id_TipoVehiculo.ToString() == Id_TipoVehiculo.Substring(2, 1))
        //        {

        //            resultE1 = objEntidad.PesoE1 / constanteCamionetas;
        //            resultE2 = objEntidad.PesoE2 / constanteCamionetas;

        //        }


        //        //Buses Y TIPO DE vehiculo "B2" = id_vehiculo=7
        //        if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(12, 1)))
        //        {
        //            resultE1 = objEntidad.PesoE1 / constanteBuses1;
        //            resultE2 = objEntidad.PesoE2 / constanteBuses2;
        //        }




        //        //Tipo diseño ASFALTO Buses Y TIPO DE vehiculo "B3" = id_vehiculo=8
        //        if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(14, 1)))
        //        {
        //            resultE1 = objEntidad.PesoE1 / constanteBuses1;
        //            resultE2 = objEntidad.PesoE2 / constanteBuses3;
        //        }
        //        else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(14, 1)))

        //        {
        //            resultE1 = objEntidad.PesoE1 / constanteBuses1;
        //            resultE2 = objEntidad.PesoE2 / constanteBuses4;

        //        }

        //        //Tipo diseño ASFALTO  Y TIPO DE vehiculo "B4" = id_vehiculo=9
        //        if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(16, 1)))
        //        {
        //            resultE1 = objEntidad.PesoE1 / constanteBuses1;
        //            resultE2 = objEntidad.PesoE2 / constanteBuses1;
        //            resultE3 = objEntidad.PesoE3 / constanteBuses3;
        //        }
        //        else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(16, 1)))

        //        {
        //            resultE1 = objEntidad.PesoE1 / constanteBuses1;
        //            resultE2 = objEntidad.PesoE2 / constanteBuses1;
        //            resultE3 = objEntidad.PesoE3 / constanteBuses4;

        //        }

        //        //tIPO DE vehiculo "C2" = id_vehiculo=10
        //        if (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(18, 2))
        //        {
        //            resultE1 = objEntidad.PesoE1 / constantecamiones1;
        //            resultE2 = objEntidad.PesoE2 / constantecamiones2;

        //        }

        //        //Tipo diseño ASFALTO  Y TIPO DE vehiculo "C3" = id_vehiculo=11
        //        if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(21, 2)))

        //        {
        //            resultE1 = objEntidad.PesoE1 / constantecamiones1;
        //            resultE2 = objEntidad.PesoE2 / constantecamiones3;


        //        }
        //        else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(21, 2)))

        //        {
        //            resultE1 = objEntidad.PesoE1 / constantecamiones1;
        //            resultE2 = objEntidad.PesoE2 / constantecamiones4;

        //        }



        //        //Tipo diseño ASFALTO  Y TIPO DE vehiculo "C4" = id_vehiculo=12
        //        if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(24, 2)))

        //        {
        //            resultE1 = objEntidad.PesoE1 / constantecamiones1;
        //            resultE2 = objEntidad.PesoE2 / constantecamiones5;


        //        }
        //        else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(24, 2)))

        //        {
        //            resultE1 = objEntidad.PesoE1 / constantecamiones1;
        //            resultE2 = objEntidad.PesoE2 / constantecamiones6;

        //        }


        //        //Tipo diseño ASFALTO  Y TIPO DE vehiculo "2S1" = id_vehiculo=13
        //        if (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(27, 2))

        //        {
        //            resultE1 = objEntidad.PesoE1 / constanteSemiTrailer1;
        //            resultE2 = objEntidad.PesoE2 / constanteSemiTrailer2;
        //            resultE3 = objEntidad.PesoE3 / constanteSemiTrailer2;



        //        }


        //        //Tipo diseño ASFALTO  Y TIPO DE vehiculo "2S2" = id_vehiculo=14
        //        if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(30, 2)))

        //        {
        //            resultE1 = objEntidad.PesoE1 / constanteSemiTrailer1;
        //            resultE2 = objEntidad.PesoE2 / constanteSemiTrailer2;
        //            resultE3 = objEntidad.PesoE3 / constanteSemiTrailer3;


        //        }
        //        else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(30, 2)))

        //        {
        //            resultE1 = objEntidad.PesoE1 / constanteSemiTrailer1;
        //            resultE2 = objEntidad.PesoE2 / constanteSemiTrailer2;
        //            resultE3 = objEntidad.PesoE3 / constanteSemiTrailer4;

        //        }

        //        //Tipo diseño ASFALTO  Y TIPO DE vehiculo "2S3" = id_vehiculo=15
        //        if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(33, 2)))

        //        {
        //            resultE1 = objEntidad.PesoE1 / constanteSemiTrailer1;
        //            resultE2 = objEntidad.PesoE2 / constanteSemiTrailer2;
        //            resultE3 = objEntidad.PesoE3 / constanteSemiTrailer5;


        //        }
        //        else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(33, 2)))

        //        {
        //            resultE1 = objEntidad.PesoE1 / constanteSemiTrailer1;
        //            resultE2 = objEntidad.PesoE2 / constanteSemiTrailer3;
        //            resultE3 = objEntidad.PesoE3 / constanteSemiTrailer2;

        //        }


        //        //Tipo diseño ASFALTO  Y TIPO DE vehiculo "3S1" = id_vehiculo=16
        //        if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(36, 2)))

        //        {
        //            resultE1 = objEntidad.PesoE1 / constanteSemiTrailer1;
        //            resultE2 = objEntidad.PesoE2 / constanteSemiTrailer3;
        //            resultE3 = objEntidad.PesoE3 / constanteSemiTrailer2;


        //        }
        //        else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(36, 2)))

        //        {
        //            resultE1 = objEntidad.PesoE1 / constanteSemiTrailer1;
        //            resultE2 = objEntidad.PesoE2 / constanteSemiTrailer4;
        //            resultE3 = objEntidad.PesoE3 / constanteSemiTrailer2;

        //        }

        //        //Tipo diseño ASFALTO  Y TIPO DE vehiculo "3S2" = id_vehiculo=17
        //        if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(39, 2)))

        //        {
        //            resultE1 = objEntidad.PesoE1 / constanteSemiTrailer1;
        //            resultE2 = objEntidad.PesoE2 / constanteSemiTrailer3;
        //            resultE3 = objEntidad.PesoE3 / constanteSemiTrailer3;


        //        }
        //        else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(39, 2)))

        //        {
        //            resultE1 = objEntidad.PesoE1 / constanteSemiTrailer1;
        //            resultE2 = objEntidad.PesoE2 / constanteSemiTrailer4;
        //            resultE3 = objEntidad.PesoE3 / constanteSemiTrailer4;

        //        }

        //        //Tipo diseño ASFALTO  Y TIPO DE vehiculo "3S3" = id_vehiculo=18
        //        if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(42, 2)))

        //        {
        //            resultE1 = objEntidad.PesoE1 / constanteSemiTrailer1;
        //            resultE2 = objEntidad.PesoE2 / constanteSemiTrailer3;
        //            resultE3 = objEntidad.PesoE3 / constanteSemiTrailer5;


        //        }
        //        else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(42, 2)))

        //        {
        //            resultE1 = objEntidad.PesoE1 / constanteSemiTrailer1;
        //            resultE2 = objEntidad.PesoE2 / constanteSemiTrailer4;
        //            resultE3 = objEntidad.PesoE3 / constanteSemiTrailer6;

        //        }



        //        //Tipo diseño ASFALTO  Y TIPO DE vehiculo "2T2" = id_vehiculo=19
        //        if (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(45, 2))

        //        {
        //            resultE1 = objEntidad.PesoE1 / constanteTrailer1;
        //            resultE2 = objEntidad.PesoE2 / constanteTrailer2;
        //            resultE3 = objEntidad.PesoE3 / constanteTrailer2;
        //            resultE4 = objEntidad.PesoE3 / constanteTrailer2;

        //        }



        //        //Tipo diseño ASFALTO  Y TIPO DE vehiculo "2T3" = id_vehiculo=20
        //        if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(48, 2)))

        //        {
        //            resultE1 = objEntidad.PesoE1 / constanteTrailer1;
        //            resultE2 = objEntidad.PesoE2 / constanteTrailer3;
        //            resultE3 = objEntidad.PesoE3 / constanteTrailer2;
        //            resultE4 = objEntidad.PesoE3 / constanteTrailer3;


        //        }
        //        else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(48, 2)))

        //        {
        //            resultE1 = objEntidad.PesoE1 / constanteTrailer1;
        //            resultE2 = objEntidad.PesoE2 / constanteTrailer4;
        //            resultE3 = objEntidad.PesoE3 / constanteTrailer2;
        //            resultE4 = objEntidad.PesoE3 / constanteTrailer4;

        //        }


        //        //Tipo diseño ASFALTO  Y TIPO DE vehiculo "3T2" = id_vehiculo=21
        //        if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(51, 2)))

        //        {
        //            resultE1 = objEntidad.PesoE1 / constanteTrailer1;
        //            resultE2 = objEntidad.PesoE2 / constanteTrailer3;
        //            resultE3 = objEntidad.PesoE3 / constanteTrailer2;
        //            resultE4 = objEntidad.PesoE3 / constanteTrailer2;


        //        }
        //        else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(51, 2)))

        //        {

        //            resultE1 = objEntidad.PesoE1 / constanteTrailer1;
        //            resultE2 = objEntidad.PesoE2 / constanteTrailer4;
        //            resultE3 = objEntidad.PesoE3 / constanteTrailer2;
        //            resultE4 = objEntidad.PesoE3 / constanteTrailer2;

        //        }

        //        //Tipo diseño ASFALTO  Y TIPO DE vehiculo ">3T3" = id_vehiculo=22
        //        if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(54, 2)))

        //        {
        //            resultE1 = objEntidad.PesoE1 / constanteTrailer1;
        //            resultE2 = objEntidad.PesoE2 / constanteTrailer3;
        //            resultE3 = objEntidad.PesoE3 / constanteTrailer3;
        //            resultE4 = objEntidad.PesoE3 / constanteTrailer3;
        //            resultE5 = objEntidad.PesoE3 / constanteTrailer3;

        //        }
        //        else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(54, 2)))

        //        {

        //            resultE1 = objEntidad.PesoE1 / constanteTrailer1;
        //            resultE2 = objEntidad.PesoE2 / constanteTrailer4;
        //            resultE3 = objEntidad.PesoE3 / constanteTrailer4;
        //            resultE4 = objEntidad.PesoE3 / constanteTrailer4;
        //            resultE5 = objEntidad.PesoE3 / constanteTrailer4;

        //        }

        //        //CALCULO DE POTENCIAS
        //        //============================

        //        //1 - Vehiculos
        //        if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_TipoVehiculo.ToString() == Id_TipoVehiculo.Substring(0,1)))// si es ASFALTO y si es Vehiculos (Id_Tipo_Vehiculo=1)
        //        {

        //            PotenciaE1 = Math.Pow(resultE1, constantePotVehi1);
        //            PotenciaE2 = Math.Pow(resultE2, constantePotVehi1);
        //        }
        //        else
        //        {
        //            PotenciaE1 = Math.Pow(resultE1, constantePotVehi2);
        //            PotenciaE2 = Math.Pow(resultE2, constantePotVehi2);
        //        }

        //        //2- Camionetas
        //        if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_TipoVehiculo.ToString() == Id_TipoVehiculo.Substring(2, 1)))// si es ASFALTO y si es Camioneta (Id_Tipo_Vehiculo=2)
        //        {

        //            PotenciaE1 = Math.Pow(resultE1, constantePotCam1);
        //            PotenciaE2 = Math.Pow(resultE2, constantePotCam1);
        //        }
        //        else
        //        {
        //            PotenciaE1 = Math.Pow(resultE1, constantePotCam2);
        //            PotenciaE2 = Math.Pow(resultE2, constantePotCam2);
        //        }

        //        //3- Buses
        //        //SI ES ASFALTO Y B2

        //        if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(12, 1)))
        //        {

        //            PotenciaE1 = Math.Pow(resultE1, constantePot1);
        //            PotenciaE2 = Math.Pow(resultE2, constantePot1);
        //        }
        //        else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(12, 1)))
        //        {
        //            PotenciaE1 = Math.Pow(resultE1, constantePot2);
        //            PotenciaE2 = Math.Pow(resultE2, constantePot2);
        //        }

        //        //Buses Y TIPO DE vehiculo "B3" = id_vehiculo=8
        //        if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(14, 1)))//SI ES ASFALTO Y B3
        //        {

        //            PotenciaE1 = Math.Pow(resultE1, constantePot1);
        //            PotenciaE2 = Math.Pow(resultE2, constantePot1);
        //        }
        //        else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(14, 1)))//SI NO ES ASFALTO Y B3
        //        {
        //            PotenciaE1 = Math.Pow(resultE1, constantePot2);
        //            PotenciaE2 = Math.Pow(resultE2, constantePot2);
        //        }


        //        //Buses Y TIPO DE vehiculo "B4" = id_vehiculo=9
        //        if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(16, 1)))//SI ES ASFALTO Y B4
        //        {

        //            PotenciaE1 = Math.Pow(resultE1, constantePot1);
        //            PotenciaE2 = Math.Pow(resultE2, constantePot1);
        //            PotenciaE3 = Math.Pow(resultE3, constantePot1);
        //        }
        //        else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(16, 1)))//SI NO ES ASFALTO Y B4
        //        {
        //            PotenciaE1 = Math.Pow(resultE1, constantePot2);
        //            PotenciaE2 = Math.Pow(resultE2, constantePot2);
        //            PotenciaE3 = Math.Pow(resultE3, constantePot2);
        //        }


        //        // TIPO DE vehiculo "C2" = id_vehiculo=10
        //        if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(18, 2)))//SI ES ASFALTO Y B4
        //        {

        //            PotenciaE1 = Math.Pow(resultE1, constantePot1);
        //            PotenciaE2 = Math.Pow(resultE2, constantePot1);

        //        }
        //        else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(18, 2)))//SI NO ES ASFALTO Y B4
        //        {
        //            PotenciaE1 = Math.Pow(resultE1, constantePot2);
        //            PotenciaE2 = Math.Pow(resultE2, constantePot2);

        //        }

        //        // TIPO DE vehiculo "C3" = id_vehiculo=11
        //        if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(21, 2)))//SI ES ASFALTO Y B4
        //        {

        //            PotenciaE1 = Math.Pow(resultE1, constantePot1);
        //            PotenciaE2 = Math.Pow(resultE2, constantePot1);

        //        }
        //        else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(21, 2)))//SI NO ES ASFALTO Y B4
        //        {
        //            PotenciaE1 = Math.Pow(resultE1, constantePot2);
        //            PotenciaE2 = Math.Pow(resultE2, constantePot2);

        //        }


        //        // TIPO DE vehiculo "C4" = id_vehiculo=12
        //        if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(24, 2)))//SI ES ASFALTO Y B4
        //        {

        //            PotenciaE1 = Math.Pow(resultE1, constantePot1);
        //            PotenciaE2 = Math.Pow(resultE2, constantePot3);

        //        }
        //        else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(24, 2)))//SI NO ES ASFALTO Y B4
        //        {
        //            PotenciaE1 = Math.Pow(resultE1, constantePot2);
        //            PotenciaE2 = Math.Pow(resultE2, constantePot1);

        //        }

        //        // TIPO DE vehiculo "2s1" = id_vehiculo=13
        //        if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(27, 2)))//SI ES ASFALTO Y B4
        //        {

        //            PotenciaE1 = Math.Pow(resultE1, constantePot1);
        //            PotenciaE2 = Math.Pow(resultE2, constantePot1);
        //            PotenciaE3 = Math.Pow(resultE2, constantePot1);

        //        }
        //        else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(27, 2)))//SI NO ES ASFALTO Y B4
        //        {
        //            PotenciaE1 = Math.Pow(resultE1, constantePot2);
        //            PotenciaE2 = Math.Pow(resultE2, constantePot2);
        //            PotenciaE3 = Math.Pow(resultE2, constantePot2);

        //        }

        //        // TIPO DE vehiculo "2s2" = id_vehiculo=14
        //        if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(30, 2)))//SI ES ASFALTO Y B4
        //        {

        //            PotenciaE1 = Math.Pow(resultE1, constantePot1);
        //            PotenciaE2 = Math.Pow(resultE2, constantePot1);
        //            PotenciaE3 = Math.Pow(resultE2, constantePot1);

        //        }
        //        else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(30, 2)))//SI NO ES ASFALTO Y B4
        //        {
        //            PotenciaE1 = Math.Pow(resultE1, constantePot2);
        //            PotenciaE2 = Math.Pow(resultE2, constantePot2);
        //            PotenciaE3 = Math.Pow(resultE2, constantePot2);

        //        }
        //        // TIPO DE vehiculo "2s3" = id_vehiculo=15
        //        if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(33, 2)))//SI ES ASFALTO Y B4
        //        {

        //            PotenciaE1 = Math.Pow(resultE1, constantePot1);
        //            PotenciaE2 = Math.Pow(resultE2, constantePot1);
        //            PotenciaE3 = Math.Pow(resultE2, constantePot3);

        //        }
        //        else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(33, 2)))//SI NO ES ASFALTO Y B4
        //        {
        //            PotenciaE1 = Math.Pow(resultE1, constantePot2);
        //            PotenciaE2 = Math.Pow(resultE2, constantePot2);
        //            PotenciaE3 = Math.Pow(resultE2, constantePot1);

        //        }
        //        // TIPO DE vehiculo "3s1" = id_vehiculo=16
        //        if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(36, 2)))//SI ES ASFALTO Y B4
        //        {

        //            PotenciaE1 = Math.Pow(resultE1, constantePot1);
        //            PotenciaE2 = Math.Pow(resultE2, constantePot1);
        //            PotenciaE3 = Math.Pow(resultE2, constantePot1);

        //        }
        //        else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(36, 2)))//SI NO ES ASFALTO Y B4
        //        {
        //            PotenciaE1 = Math.Pow(resultE1, constantePot2);
        //            PotenciaE2 = Math.Pow(resultE2, constantePot2);
        //            PotenciaE3 = Math.Pow(resultE2, constantePot2);

        //        }

        //        // TIPO DE vehiculo "3s2" = id_vehiculo=17
        //        if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(39, 2)))//SI ES ASFALTO Y B4
        //        {

        //            PotenciaE1 = Math.Pow(resultE1, constantePot1);
        //            PotenciaE2 = Math.Pow(resultE2, constantePot1);
        //            PotenciaE3 = Math.Pow(resultE2, constantePot1);

        //        }
        //        else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(39, 2)))//SI NO ES ASFALTO Y B4
        //        {
        //            PotenciaE1 = Math.Pow(resultE1, constantePot2);
        //            PotenciaE2 = Math.Pow(resultE2, constantePot2);
        //            PotenciaE3 = Math.Pow(resultE2, constantePot2);

        //        }

        //        // TIPO DE vehiculo "3s3" = id_vehiculo=18
        //        if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(42, 2)))//SI ES ASFALTO Y B4
        //        {

        //            PotenciaE1 = Math.Pow(resultE1, constantePot1);
        //            PotenciaE2 = Math.Pow(resultE2, constantePot1);
        //            PotenciaE3 = Math.Pow(resultE2, constantePot3);

        //        }
        //        else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(42, 2)))//SI NO ES ASFALTO Y B4
        //        {
        //            PotenciaE1 = Math.Pow(resultE1, constantePot2);
        //            PotenciaE2 = Math.Pow(resultE2, constantePot2);
        //            PotenciaE3 = Math.Pow(resultE2, constantePot1);

        //        }

        //        // TIPO DE vehiculo "2t2" = id_vehiculo=19
        //        if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(45, 2)))//SI ES ASFALTO Y B4
        //        {

        //            PotenciaE1 = Math.Pow(resultE1, constantePot1);
        //            PotenciaE2 = Math.Pow(resultE2, constantePot1);
        //            PotenciaE3 = Math.Pow(resultE2, constantePot1);
        //            PotenciaE4 = Math.Pow(resultE2, constantePot1);

        //        }
        //        else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(45, 2)))//SI NO ES ASFALTO Y B4
        //        {
        //            PotenciaE1 = Math.Pow(resultE1, constantePot2);
        //            PotenciaE2 = Math.Pow(resultE2, constantePot2);
        //            PotenciaE3 = Math.Pow(resultE2, constantePot2);
        //            PotenciaE4 = Math.Pow(resultE2, constantePot2);
        //        }

        //        // TIPO DE vehiculo "2t3" = id_vehiculo=20
        //        if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(48, 2)))//SI ES ASFALTO Y B4
        //        {

        //            PotenciaE1 = Math.Pow(resultE1, constantePot1);
        //            PotenciaE2 = Math.Pow(resultE2, constantePot1);
        //            PotenciaE3 = Math.Pow(resultE2, constantePot1);
        //            PotenciaE4 = Math.Pow(resultE2, constantePot1);

        //        }
        //        else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(48, 2)))//SI NO ES ASFALTO Y B4
        //        {
        //            PotenciaE1 = Math.Pow(resultE1, constantePot2);
        //            PotenciaE2 = Math.Pow(resultE2, constantePot2);
        //            PotenciaE3 = Math.Pow(resultE2, constantePot2);
        //            PotenciaE4 = Math.Pow(resultE2, constantePot2);
        //        }

        //        // TIPO DE vehiculo "3t2" = id_vehiculo=21
        //        if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(51, 2)))//SI ES ASFALTO Y B4
        //        {

        //            PotenciaE1 = Math.Pow(resultE1, constantePot1);
        //            PotenciaE2 = Math.Pow(resultE2, constantePot1);
        //            PotenciaE3 = Math.Pow(resultE2, constantePot1);
        //            PotenciaE4 = Math.Pow(resultE2, constantePot1);

        //        }
        //        else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(51, 2)))//SI NO ES ASFALTO Y B4
        //        {
        //            PotenciaE1 = Math.Pow(resultE1, constantePot2);
        //            PotenciaE2 = Math.Pow(resultE2, constantePot2);
        //            PotenciaE3 = Math.Pow(resultE2, constantePot2);
        //            PotenciaE4 = Math.Pow(resultE2, constantePot2);
        //        }


        //        // TIPO DE vehiculo ">3T3" = id_vehiculo=22
        //        if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(54, 2)))//SI ES ASFALTO Y B4
        //        {

        //            PotenciaE1 = Math.Pow(resultE1, constantePot1);
        //            PotenciaE2 = Math.Pow(resultE2, constantePot1);
        //            PotenciaE3 = Math.Pow(resultE2, constantePot1);
        //            PotenciaE4 = Math.Pow(resultE2, constantePot1);
        //            PotenciaE5 = Math.Pow(resultE2, constantePot1);

        //        }
        //        else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(54, 2)))//SI NO ES ASFALTO Y B4
        //        {
        //            PotenciaE1 = Math.Pow(resultE1, constantePot2);
        //            PotenciaE2 = Math.Pow(resultE2, constantePot2);
        //            PotenciaE3 = Math.Pow(resultE2, constantePot2);
        //            PotenciaE4 = Math.Pow(resultE2, constantePot2);
        //            PotenciaE5 = Math.Pow(resultE2, constantePot1);
        //        }
        //        //Buses enviado el ID VEhiculo
        //        return resultadoFVP = PotenciaE1 + PotenciaE2+ PotenciaE3+ PotenciaE4+ PotenciaE5;
        //        //double resultadoN18calc2 = 0;

        //    }

        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}


        public double CoeficienteA2(BECalculos objEntidad)
        {

            //constante1_A2=2555 
            //constante2_A2=0.64
            //constante3_A2=0.249
            //constante4_A2=0.977
            //constante5_A2=0.15
            double CoeficienteA2 = 0;
            double CalculoMR = (Convert.ToDouble(ConfigurationManager.AppSettings["constante1_A2"].ToString())) * Math.Pow(objEntidad.valorCBRBase, Convert.ToDouble(ConfigurationManager.AppSettings["constante2_A2"].ToString()));
            double Valor = Math.Round((Convert.ToDouble(ConfigurationManager.AppSettings["constante3_A2"].ToString()) * Math.Log10(CalculoMR)) - Convert.ToDouble(ConfigurationManager.AppSettings["constante4_A2"].ToString()), 2);

            if (Valor >= Convert.ToDouble(ConfigurationManager.AppSettings["constante5_A2"].ToString()))
            {
                CoeficienteA2 = Convert.ToDouble(ConfigurationManager.AppSettings["constante5_A2"].ToString());
            }
         else
            {
                CoeficienteA2 = Valor;
            }

            return CoeficienteA2;

        }

        public double CoeficienteA3(BECalculos objEntidad)
        {

            //constante1_A3=2555 
            //constante2_A3=0.64

            //constante3_A3=0.227
            //constante4_A3=0.839
            //constante5_A3=0.13
            double CoeficienteA2 = 0;
            double CalculoMR = (Convert.ToDouble(ConfigurationManager.AppSettings["constante1_A3"].ToString())) * Math.Pow(objEntidad.valorCBRSubBase, Convert.ToDouble(ConfigurationManager.AppSettings["constante2_A3"].ToString()));
            double Valor = Math.Round((Convert.ToDouble(ConfigurationManager.AppSettings["constante3_A3"].ToString()) * Math.Log10(CalculoMR)) - Convert.ToDouble(ConfigurationManager.AppSettings["constante4_A3"].ToString()), 2);

            if (Valor >= Convert.ToDouble(ConfigurationManager.AppSettings["constante5_A3"].ToString()))
            {
                CoeficienteA2 = Convert.ToDouble(ConfigurationManager.AppSettings["constante5_A3"].ToString());
            }
            else
            {
                CoeficienteA2 = Valor;
            }

            return CoeficienteA2;

        }

        //MEJORA 06/05.2020
        public decimal TotalTasaCrecimiento(int IdDiseno)
        {
            decimal total = 1;
            decimal TotalTasa = 0;


            List<BETasaCrecimiento> LstTasaCrecim = new List<BETasaCrecimiento>();
            BLTasaCrecimiento objjTasaCrecimiento = new BLTasaCrecimiento();
            LstTasaCrecim = objjTasaCrecimiento.ListarVarTiempoXDiseno(IdDiseno);

            foreach (BETasaCrecimiento item in LstTasaCrecim)
            {

                total = total * (1 + (item.Valor / 100));

            }

            TotalTasa = (total - 1) * 100;
            return Math.Round(TotalTasa, 2);

        }

        public double ModuloRotura(double valor,double ResisCompre)
        {
            double consModRotura1 = Convert.ToDouble(ConfigurationManager.AppSettings["consModRotura1"].ToString());// 0.0981
            double consModRotura2 = Convert.ToDouble(ConfigurationManager.AppSettings["consModRotura2"].ToString());// 0.5

            double MR = 0;
            double ModRotura = 0;
            MR = valor * Math.Pow(ResisCompre, consModRotura2);
            ModRotura = MR * consModRotura1;
            return ModRotura;

        }

        public double ModuloElasticidad(double ResisCompre)
        {
            double consModElastic1 = Convert.ToDouble(ConfigurationManager.AppSettings["consModElastic1"].ToString());// 57000
            double consModElastic2 = Convert.ToDouble(ConfigurationManager.AppSettings["consModElastic2"].ToString());// 14.194
            double consModElastic3 = Convert.ToDouble(ConfigurationManager.AppSettings["consModElastic3"].ToString());// 0.5
            double consModElastic4 = Convert.ToDouble(ConfigurationManager.AppSettings["consModElastic4"].ToString());// 0.00689476
            double ModElastic = 0;
            // = +(57000 * (G11 * 14.194) ^ 0.5) *             
            ModElastic = consModElastic1 * Math.Pow((ResisCompre* consModElastic2), consModElastic3)* consModElastic4;

            return ModElastic;

        }

        public double CalculoKEquivMpaM(double variable)
        {
            double consCalcK1Equi1 = Convert.ToDouble(ConfigurationManager.AppSettings["consCalcK1Equi1"].ToString());// 10
            double consCalcK1Equi2 = Convert.ToDouble(ConfigurationManager.AppSettings["consCalcK1Equi2"].ToString());// 46
            double consCalcK1Equi3 = Convert.ToDouble(ConfigurationManager.AppSettings["consCalcK1Equi3"].ToString());// 9.08
            double consCalcK1Equi4 = Convert.ToDouble(ConfigurationManager.AppSettings["consCalcK1Equi4"].ToString());// 4.34
            double consCalcK1Equi5 = Convert.ToDouble(ConfigurationManager.AppSettings["consCalcK1Equi5"].ToString());// 2.55
            double consCalcK1Equi6 = Convert.ToDouble(ConfigurationManager.AppSettings["consCalcK1Equi6"].ToString());// 52.5

            double K1Equiv = 0;
            double potencia = 0;

            if (variable > consCalcK1Equi1)
            {
                potencia = Math.Pow(Math.Log10(variable), consCalcK1Equi4);

                K1Equiv = consCalcK1Equi2 + (consCalcK1Equi3 * potencia);
             }

            else
            {
                K1Equiv = (Math.Log10(variable) * consCalcK1Equi6) + consCalcK1Equi5;


            }
           

            return K1Equiv;

        }

        //despues de calcular el Mpa/m
        public double CalculoKgCm3(double variable)

        {
            double consKgCm3 = Convert.ToDouble(ConfigurationManager.AppSettings["consKgCm3"].ToString());// 0.101972

            double KgCm3 = 0;

            KgCm3 = variable * consKgCm3;
            return KgCm3;
        }

        public double CalcuKeqMpa(double variable)

        {
            double ConsKeqMpa = Convert.ToDouble(ConfigurationManager.AppSettings["ConsKeqMpa"].ToString());// 0.101972

            double KgCm3 = 0;
            KgCm3 = variable / ConsKeqMpa;
            return KgCm3;
        }

        public double CalcuKeqkgcm3(double k1,double k0,double hCm)

        {
            double contantekG1 = Convert.ToDouble(ConfigurationManager.AppSettings["contantekG1"].ToString()); //38
            double contantekG2 = Convert.ToDouble(ConfigurationManager.AppSettings["contantekG2"].ToString()); //0.666666666666667
            double contantekG3 = Convert.ToDouble(ConfigurationManager.AppSettings["contantekG3"].ToString()); //2
            double contantekG4 = Convert.ToDouble(ConfigurationManager.AppSettings["contantekG4"].ToString()); //0.5
            double calculo1 = 0;
            double calculo2 = 0;
            double calculo3 = 0;
            double calculo4 = 0;
            double calculo5 = 0;
            calculo1 = Math.Pow(hCm / contantekG1, contantekG3);
            calculo2 = Math.Pow( k1 / k0, contantekG2);
            calculo3 = calculo1 * calculo2 + 1;
            calculo4 = Math.Pow(calculo3, contantekG4);
            calculo5 = calculo4 * hCm;
            return calculo5;
        }


    }
}