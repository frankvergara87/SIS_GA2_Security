using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS_Ga2.Entity;

using System.Configuration;
using System.Web.UI.DataVisualization.Charting;

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
        public double calcularSNReq(BECalculos objEntidad)
        {
            double resultadoN18Calc = 0;

            //double n18nom = 0;           
            int encontrado = 0;
            int calculo = 0;
            double ResultadoSNReq = 0;
            string valor = "";
            //  calcular el sn req
            for (double i = 0; i <= 100; i++)
            {
                if (encontrado == 0)
                {
                    for (double j = 0; j <= 9; j++)
                    {
                        if (encontrado == 0)
                        {
                            for (double k = 0; k <= 9; k++)
                            {
                                for (double l = 0; l <= 9; l++)
                                {
                                    for (double m = 0; m <= 9; m++)
                                    {
                                        if (encontrado == 0)
                                        {

                                            valor = i.ToString() + "." + j.ToString() + k.ToString() + l.ToString() + m.ToString();
                                            objEntidad.SNReq = Convert.ToDouble(valor);

                                            resultadoN18Calc = Math.Round(calcularN18Calc1(objEntidad), 5);

                                            //calculo = Math.Round(objEntidad.N18Nom - resultadoN18Calc, 3);
                                            //listBox1.ClearSelected(); 

                                            //if ((calculo<=0.01) && (calculo>0) )
                                            if ((Math.Round(objEntidad.N18Nom, 3) == Math.Round(resultadoN18Calc, 3)))
                                            {
                                                // textn18calc.Text = resultadoN18Calc.ToString();
                                                ResultadoSNReq = Math.Round(objEntidad.SNReq, 2);
                                                calculo = 1;
                                                encontrado = 1;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (calculo == 0)
            {
                return 0;
            }
            else
            {
                return ResultadoSNReq;

            }
        }


        public double calcularFVP(BECalculos objEntidad)
        {
            try
            {
                string TipoDiseno, Id_TipoVehiculo;
                TipoDiseno = ConfigurationManager.AppSettings["TipoAsfalto"].ToString();
                Id_TipoVehiculo = ConfigurationManager.AppSettings["Id_TipoVehiculo1"].ToString();
                double constanteVehiculos = Convert.ToDouble(ConfigurationManager.AppSettings["constanteVehi"].ToString());// 6.6
                double constantePotencia1 = Convert.ToDouble(ConfigurationManager.AppSettings["constantePotencia1"].ToString());// 4
                double constantePotencia2 = Convert.ToDouble(ConfigurationManager.AppSettings["constantePotencia2"].ToString());// 4.4
                double resultE1 = 0;
                double resultE2 = 0;
                double PotenciaE1 = 0;
                double PotenciaE2 = 0;
                resultE1 = objEntidad.PesoE1 / constanteVehiculos;
                resultE2 = objEntidad.PesoE2 / constanteVehiculos;

                if (objEntidad.TipoDiseno == TipoDiseno)// si es ASFALTO
                {

                    PotenciaE1 = Math.Pow(resultE1, 4);
                    PotenciaE2 = Math.Pow(resultE2, 4);
                }
                else
                {
                    PotenciaE1 = Math.Pow(resultE1, 4.1);
                    PotenciaE2 = Math.Pow(resultE2, 4.1);
                }



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

    }
}