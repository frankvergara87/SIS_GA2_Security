using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS_Ga2.Entity;
using SIS_Ga2.DataAccess;
using System.Configuration;
using System.Reflection;
using System.Data;
namespace SIS_Ga2.Business
{
    public class BLCalculoEE
    {
        public List<BEMatrizEE> ListaResultadoEE  (BEMatrizTasaCrecimiento objEntidad, int idTipoTasaCrec, decimal FDxFC, decimal Fp)
        {
            int idTipoTasaCreci1 = 0;
            int idTipoTasaCreci2 = 0;
            int idTipoTasaCreci3 = 0;

            //decimal ValorEE = 0;
            BLMatrizTasaCrecimiento objMatriz = new BLMatrizTasaCrecimiento();
            BEMatrizTasaCrecimiento objBEMatriz = new BEMatrizTasaCrecimiento();
            int Resultado1 = 0;
            int del = 0;
                del = objMatriz.DelTasaCrecimiento(objEntidad.Id_Diseno);
            List<BEMatrizTasaCrecimiento> LstBLMatriz1 = new List<BEMatrizTasaCrecimiento>();
            List<BETipoVehiculos> LstBETipoVehiculos = new List<BETipoVehiculos>();
            List<BETasaCrecimiento> LstCrecimXTiempo = new List<BETasaCrecimiento>();
            List<BETasaCrecimiento> LstCrecimXVehiculo = new List<BETasaCrecimiento>();
            List<BETasaCrecimiento> LstCrecimConstante = new List<BETasaCrecimiento>();         
            List<BEMatrizEE> LstMatrizEE = new List<BEMatrizEE>();
            List<BEVehiculos> LstVehiculos = new List<BEVehiculos>();         
            List<BEMatrizEE> LstMatrizEEResultado1 = new List<BEMatrizEE>();
            List<BEMatrizEERes> LstMatrizEEResultado2 = new List<BEMatrizEERes>();
            List<BEMatrizEE> LstMatrizEEResultado3 = new List<BEMatrizEE>();

            BLTipoVehiculo objTipoVehiculo = new BLTipoVehiculo();
            BLTasaCrecimiento oBJBLTasaCrecimiento = new BLTasaCrecimiento();
            BLMatrizTasaCrecimiento oBJBLMatrizTasaCrecimiento = new BLMatrizTasaCrecimiento();
            BLMatrizEE oBJBLMatrizEE = new BLMatrizEE();
            BLVehiculos ObjBLVehiculos = new BLVehiculos();
            BLMatrizTasaCrecimiento ObjBLMatrizTasaCrec = new BLMatrizTasaCrecimiento();


            LstBETipoVehiculos = objTipoVehiculo.ListarTipoVehiculos(0);
            LstCrecimXTiempo = oBJBLTasaCrecimiento.ListarCrecimXTiempo(objEntidad.Id_Diseno);
            LstCrecimXVehiculo = oBJBLTasaCrecimiento.ListarCrecimXVehiculo(objEntidad.Id_Diseno);
            LstCrecimConstante = oBJBLTasaCrecimiento.ListarCrecimConstante(objEntidad.Id_Diseno);

            LstMatrizEE = oBJBLMatrizEE.ListarInfoMatrizEE(objEntidad.Id_Diseno);
            LstVehiculos = ObjBLVehiculos.ListarVehiculos(0);
          
            decimal ValorCrecConstate = 0;
            decimal ValorCrecVeh = 0;


            idTipoTasaCreci1 = Convert.ToInt32(ConfigurationManager.AppSettings["TipoTasaCreciTI"].ToString());//IdVariable por Tiempo;
            idTipoTasaCreci2 = Convert.ToInt32(ConfigurationManager.AppSettings["TipoTasaCreciVE"].ToString());//IdVariable por Vehiculo;
            idTipoTasaCreci3 = Convert.ToInt32(ConfigurationManager.AppSettings["TipoTasaCreciCO"].ToString());//IdVariable Constante;

            //Registro de Variables por Crecimiento de Tiempo

            if (idTipoTasaCrec == idTipoTasaCreci1)
            {

                foreach (BETipoVehiculos point in LstBETipoVehiculos)
                {
                    objBEMatriz = new BEMatrizTasaCrecimiento();
                    objBEMatriz.Nro_Anio = 0;
                    objBEMatriz.Id_Diseno = objEntidad.Id_Diseno;
                    objBEMatriz.Id_Tipo_Vehiculo = point.Id_Tipo_Vehiculo;
                    objBEMatriz.Valor = 0;
                    Resultado1 = objMatriz.GuardartasaCrecimiento(objBEMatriz, 1);
                }

                foreach (BETasaCrecimiento item in LstCrecimXTiempo)
                {
                    objBEMatriz = new BEMatrizTasaCrecimiento();

                    foreach (BETipoVehiculos point in LstBETipoVehiculos)
                    {

                        objBEMatriz.Nro_Anio = item.NroAnio;
                        objBEMatriz.Id_Diseno = objEntidad.Id_Diseno;
                        objBEMatriz.Id_Tipo_Vehiculo = point.Id_Tipo_Vehiculo;
                        objBEMatriz.Valor = item.Valor;
                        Resultado1 = objMatriz.GuardartasaCrecimiento(objBEMatriz, 1);
                    }


                }

            }





            if (idTipoTasaCrec == idTipoTasaCreci2)
            {

                //Registro de Variables por Crecimiento de Vehiculo

                for (int j = 0; j <= objEntidad.Nro_Anio; j++)
                {
                    foreach (BETipoVehiculos point in LstBETipoVehiculos)
                    {

                        //Ubicar el valor de crecimiento de vehiculo x id tipo de vehiculo
                        foreach (BETasaCrecimiento item in LstCrecimXVehiculo)
                        {
                            if (item.Id_Tipo_Vehiculo == point.Id_Tipo_Vehiculo)
                            {
                                ValorCrecVeh = item.Valor;
                                objBEMatriz = new BEMatrizTasaCrecimiento();
                                objBEMatriz.Nro_Anio = j;
                                objBEMatriz.Id_Diseno = objEntidad.Id_Diseno;
                                objBEMatriz.Id_Tipo_Vehiculo = point.Id_Tipo_Vehiculo;
                                if (j == 0)
                                {

                                    objBEMatriz.Valor = j;
                                }
                                else
                                {
                                    objBEMatriz.Valor = ValorCrecVeh;

                                }

                                Resultado1 = objMatriz.GuardartasaCrecimiento(objBEMatriz, 1);

                            }

                        }


                    }


                }

            }


            if (idTipoTasaCrec == idTipoTasaCreci3)
            {

                //Registro de Variables por Constante

                for (int j = 0; j <= objEntidad.Nro_Anio; j++)
                {
                    foreach (BETipoVehiculos point in LstBETipoVehiculos)
                    {

                        //Ubicar el valor de crecimiento constante que se obtiene de la Lista que trae las constante asociadas por Id Diseño
                        foreach (BETasaCrecimiento item in LstCrecimConstante)
                        {

                            ValorCrecConstate = item.Valor;
                            objBEMatriz = new BEMatrizTasaCrecimiento();
                            objBEMatriz.Nro_Anio = j;
                            objBEMatriz.Id_Diseno = objEntidad.Id_Diseno;
                            objBEMatriz.Id_Tipo_Vehiculo = point.Id_Tipo_Vehiculo;
                            if (j == 0)
                            {
                                objBEMatriz.Valor = 0;
                            }
                            else
                            {

                                objBEMatriz.Valor = ValorCrecConstate;
                            }

                            Resultado1 = objMatriz.GuardartasaCrecimiento(objBEMatriz, 1);




                        }


                        //   Resultado2 = objMatriz.GuardartasaCrecimiento(objBEMatriz, 2);
                    }


                }

            }


            decimal CalculoEE1 = 0;
            decimal CalculoEE2 = 0;
            decimal ValorMatriz1 = 0;
            //seleccionamos la matriz de tasa de crecimiento registrada por año y vehiculo//[USP_Sel_TasasCrecimiento1]
            LstBLMatriz1 = ObjBLMatrizTasaCrec.ListarTasaCrec1(objEntidad.Id_Diseno);

            
            // Logica Matriz

            for (int i = 0; i <= objEntidad.Nro_Anio; i++)

            {
                foreach (BETipoVehiculos Veh in LstBETipoVehiculos)// Recorremos los tipos de vehiculos
                {


                    var resultadoIMD = from Matriz1 in LstMatrizEE
                                       where Matriz1.Id_Tipo_Vehiculo == Veh.Id_Tipo_Vehiculo
                                       select Matriz1;



                   foreach (BEMatrizEE item in resultadoIMD)// Recorremos la  lista para obtener los valores IMD y FVP USP_Sel_Info_Matriz_EE
                    {

                        if (i == 0)
                        {
                            BEMatrizEE itemEE = new BEMatrizEE();
                            itemEE.Id_Vehiculos = item.Id_Vehiculos;
                            itemEE.Id_Tipo_Vehiculo = item.Id_Tipo_Vehiculo;
                            itemEE.valorEEMatriz = item.IMD_Base;
                            itemEE.NroAnio = i;
                            LstMatrizEEResultado1.Add(itemEE);

                            BEMatrizEERes itemEERes = new BEMatrizEERes();
                            itemEERes.Id_Vehiculos = item.Id_Vehiculos;
                            itemEERes.Id_Tipo_Vehiculo = item.Id_Tipo_Vehiculo;
                            itemEERes.valorEEMatriz = item.IMD_Base;
                            itemEERes.NroAnio = i;
                            LstMatrizEEResultado2.Add(itemEERes);


                        }
                        else

                        {

                            if (LstMatrizEEResultado1.Count > 0)

                            {//Obtenemos el IMD del año anterior del vehiculo
                             // debe de retornar 1 solo valor
                                var resultado = from Matriz1 in LstMatrizEEResultado1
                                                where Matriz1.Id_Vehiculos == item.Id_Vehiculos && Matriz1.NroAnio == (i - 1)
                                                select Matriz1;
                                //obtengo por el numero de año y id de Tipo vehiculo los valores de la matriz por vehiculo (TASA de crecimiento)
                                // retorna 1 solo valor
                                var resultadoM = from Matriz1 in LstBLMatriz1
                                                 where (Matriz1.Id_Tipo_Vehiculo == item.Id_Tipo_Vehiculo)
                                                 && (Matriz1.Nro_Anio == i)
                                                 //&& (Matriz1.Id_Vehiculos == item.Id_Vehiculos)
                                                 select Matriz1;

                                foreach (BEMatrizEE itemR in resultado)
                                {


                                    ValorMatriz1 = itemR.valorEEMatriz;//Valor Anterior IMD BASE
                                    foreach (BEMatrizTasaCrecimiento itemM in resultadoM)
                                    {
                                        if (itemM.Id_Tipo_Vehiculo == item.Id_Tipo_Vehiculo)
                                        {
                                            // CalculoEE1 = itemM.Valor* (1 + (ValorMatriz1 / 100));
                                            CalculoEE1 = itemR.valorEEMatriz * (1 + itemM.Valor / 100);

                                            BEMatrizEERes itemEE = new BEMatrizEERes();
                                            itemEE.Id_Vehiculos = item.Id_Vehiculos;
                                            //itemEE.valorEEMatriz = Math.Round(CalculoEE1,2);
                                            itemEE.valorEEMatriz = CalculoEE1;
                                            itemEE.NroAnio = i;
                                            itemEE.Id_Tipo_Vehiculo = item.Id_Tipo_Vehiculo;
                                            LstMatrizEEResultado2.Add(itemEE);
                                        }
                                    }

                                }

                                LstMatrizEEResultado1.Clear();
                               foreach (BEMatrizEERes res in LstMatrizEEResultado2)
                                {
                                    BEMatrizEE itemEE = new BEMatrizEE();
                                    itemEE.Id_Vehiculos = res.Id_Vehiculos;
                                    itemEE.valorEEMatriz = res.valorEEMatriz;
                                    itemEE.NroAnio = res.NroAnio;
                                    itemEE.Id_Tipo_Vehiculo = res.Id_Tipo_Vehiculo;
                                    LstMatrizEEResultado1.Add(itemEE);

                                }

                            }
                        }
                    }
                        
                    }

                }

       /*     DataTable tabla1 = new DataTable();


            PropertyInfo[] propiedades1 = LstMatrizEEResultado1[0].GetType().GetProperties();
            for (int i = 0; i < propiedades1.Length; i++)
            {
                tabla1.Columns.Add(propiedades1[i].Name, propiedades1[i].PropertyType);
            }
            //Llenar la Tabla desde la Lista de Objetos
            DataRow fila1 = null;
            for (int i = 0; i < LstMatrizEEResultado1.Count; i++)
            {
                propiedades1 = LstMatrizEEResultado1[i].GetType().GetProperties();
                fila1 = tabla1.NewRow();
                for (int j = 0; j < propiedades1.Length; j++)
                {
                    fila1[j] = propiedades1[j].GetValue(LstMatrizEEResultado1[i], null);
                }
                tabla1.Rows.Add(fila1);
            }

            */
            //en base a la informacion calculamos el EE 

            for (int j = 0; j <= objEntidad.Nro_Anio; j++)
            {

                foreach (BEVehiculos Vehi in LstVehiculos)// Recorremos los vehiculos
                {
                    //Obtenemos el valor del FVP por id de vehiculo
                    var LstMatrizEExVeh = LstMatrizEE.Where(x => x.Id_Vehiculos == Vehi.Id_Vehiculos).ToList();

                    foreach (BEMatrizEE item in LstMatrizEExVeh)//recorremos para obrener el FVP - debe ser un solo resultado
                    {

                        
                        // En base al ID de vehiculo y el numero del año recorremos la lista LstMatrizEEResultado1

                        var resultado = from Matriz1 in LstMatrizEEResultado1
                                        where Matriz1.Id_Vehiculos == Vehi.Id_Vehiculos && Matriz1.NroAnio == (j)
                                        select Matriz1;
                        foreach (BEMatrizEE itemR in resultado)//recorremos para obrener el FVP - debe ser un solo resultado
                        {
                            BEMatrizEE itemEE = new BEMatrizEE();
                          
                            CalculoEE2 = item.Valor_FVP * itemR.valorEEMatriz  * FDxFC * Fp * 365;
                            itemEE.Id_Vehiculos = item.Id_Vehiculos;
                            itemEE.Id_Tipo_Vehiculo = item.Id_Tipo_Vehiculo;
                            // itemEE.valorEEMatriz =Math.Round( CalculoEE2,0);
                            

                            itemEE.valorEEMatriz = CalculoEE2;
                            itemEE.NroAnio = j;
                            LstMatrizEEResultado3.Add(itemEE);

                        }
                    }
                }

            }

            LstBLMatriz1.Clear();
            LstBETipoVehiculos.Clear();
            LstCrecimXTiempo.Clear();
            LstCrecimXVehiculo.Clear();
            LstCrecimConstante.Clear();
            LstMatrizEE.Clear();
            LstVehiculos.Clear();
            LstMatrizEEResultado1.Clear();
            LstMatrizEEResultado2.Clear();

           /* DataTable tabla = new DataTable();

            
            PropertyInfo[] propiedades = LstMatrizEEResultado3[0].GetType().GetProperties();
            for (int i = 0; i < propiedades.Length; i++)
            {
                tabla.Columns.Add(propiedades[i].Name, propiedades[i].PropertyType);
            }
            //Llenar la Tabla desde la Lista de Objetos
            DataRow fila = null;
            for (int i = 0; i < LstMatrizEEResultado3.Count; i++)
            {
                propiedades = LstMatrizEEResultado3[i].GetType().GetProperties();
                fila = tabla.NewRow();
                for (int j = 0; j < propiedades.Length; j++)
                {
                    fila[j] = propiedades[j].GetValue(LstMatrizEEResultado3[i], null);
                }
                tabla.Rows.Add(fila);
            }*/


            return LstMatrizEEResultado3;

       /*    foreach (BEMatrizEE item in LstMatrizEEResultado3)
            {
                ValorEE = ValorEE + item.valorEEMatriz;

            }

           // decimal a = 0;
            return Math.Round(ValorEE, 0);*/

            

        }




    public decimal CalculoEExVehi(List<BEMatrizEE> LstMatrizEEResultado, int TipoVehiculo,int idVehiculo )
        {
            decimal ValorEExVeh = 0;
            var resultado = from Matriz in LstMatrizEEResultado
                            where Matriz.Id_Vehiculos == idVehiculo && Matriz.Id_Tipo_Vehiculo == TipoVehiculo
                            select Matriz;
            foreach (BEMatrizEE item in resultado)//recorremos para obrener el FVP - debe ser un solo resultado
            {
                ValorEExVeh = ValorEExVeh + item.valorEEMatriz;
            }

               return ValorEExVeh;
    }
    }
}
