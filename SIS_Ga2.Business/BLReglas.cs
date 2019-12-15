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
                double constantePotBus1 = Convert.ToDouble(ConfigurationManager.AppSettings["constantePotBus1"].ToString());// 4
                double constantePotBus2 = Convert.ToDouble(ConfigurationManager.AppSettings["constantePotBus2"].ToString());// 4.1
                //Buses - Vehiculo=B3

                double constanteBuses3 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteBuses3"].ToString());// 15.1
                double constanteBuses4 = Convert.ToDouble(ConfigurationManager.AppSettings["constanteBuses4"].ToString());// 13.3

                double resultE1 = 0;
                double resultE2 = 0;
                double PotenciaE1 = 0;
                double PotenciaE2 = 0;

                //Vehiculos
                if (objEntidad.Id_TipoVehiculo.ToString() == Id_TipoVehiculo.Substring(0, 1))
                {

                    resultE1 = objEntidad.PesoE1 / constanteVehiculos;
                    resultE2 = objEntidad.PesoE2 / constanteVehiculos;

                }
                //Camionetas
                if (objEntidad.Id_TipoVehiculo.ToString() == Id_TipoVehiculo.Substring(2, 1))
                {

                    resultE1 = objEntidad.PesoE1 / constanteCamionetas;
                    resultE2 = objEntidad.PesoE2 / constanteCamionetas;

                }


                //Buses Y TIPO DE vehiculo "B2" = id_vehiculo=7
                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(12, 1)))
                {
                    resultE1 = objEntidad.PesoE1 / constanteBuses1;
                    resultE2 = objEntidad.PesoE2 / constanteBuses2;
                }




                //Buses Y TIPO DE vehiculo "B3" = id_vehiculo=8
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

                //CALCULO DE POTENCIAS
                //============================

                //1 - Vehiculos
                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_TipoVehiculo.ToString() == Id_TipoVehiculo.Substring(0, 1)))// si es ASFALTO y si es Vehiculos (Id_Tipo_Vehiculo=1)
                {

                    PotenciaE1 = Math.Pow(resultE1, constantePotVehi1);
                    PotenciaE2 = Math.Pow(resultE2, constantePotVehi1);
                }
                else
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
                else
                {
                    PotenciaE1 = Math.Pow(resultE1, constantePotCam2);
                    PotenciaE2 = Math.Pow(resultE2, constantePotCam2);
                }

                //3- Buses


                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(12, 1)))//SI ES ASFALTO Y B2
                {

                    PotenciaE1 = Math.Pow(resultE1, constantePotBus1);
                    PotenciaE2 = Math.Pow(resultE2, constantePotBus1);
                }
                else
                {
                    PotenciaE1 = Math.Pow(resultE1, constantePotBus2);
                    PotenciaE2 = Math.Pow(resultE2, constantePotBus2);
                }

                //Buses Y TIPO DE vehiculo "B3" = id_vehiculo=8
                if ((objEntidad.TipoDiseno.ToUpper() == TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(14, 1)))//SI ES ASFALTO Y B3
                {

                    PotenciaE1 = Math.Pow(resultE1, constantePotBus1);
                    PotenciaE2 = Math.Pow(resultE2, constantePotBus1);
                }
                else if ((objEntidad.TipoDiseno.ToUpper() != TipoDiseno) && (objEntidad.Id_Vehiculo.ToString() == Id_Vehiculo.Substring(14, 1)))//SI NO ES ASFALTO Y B3
                {
                    PotenciaE1 = Math.Pow(resultE1, constantePotBus2);
                    PotenciaE2 = Math.Pow(resultE2, constantePotBus2);
                }

                //Buses enviado el ID VEhiculo
                return resultadoFVP = PotenciaE1 + PotenciaE2;
                //double resultadoN18calc2 = 0;

            }

            catch (Exception ex)
            {

                throw ex;
            }
        }


        public double CoeficienteA2(BECalculos objEntidad)
        {

            //constante1_A2=2555 
            //constante2_A2=0.64
            //constante3_A2=0.249
            //constante4_A2=0.977
            //constante5_A2=0.15
            double CoeficienteA2 = 0;
            double CalculoMR = (Convert.ToDouble(ConfigurationManager.AppSettings["constante1_A2"].ToString())) * Math.Pow(objEntidad.valorCBRBase, Convert.ToDouble(ConfigurationManager.AppSettings["constante2_A2"].ToString()));
            double Valor = Math.Round((Convert.ToDouble(ConfigurationManager.AppSettings["constante3_A2"].ToString()) * Math.Log10(CalculoMR)) - Convert.ToDouble(ConfigurationManager.AppSettings["constante4_A2"].ToString()),2);

         if (Valor>= Convert.ToDouble(ConfigurationManager.AppSettings["constante5_A2"].ToString()))
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

    }
}