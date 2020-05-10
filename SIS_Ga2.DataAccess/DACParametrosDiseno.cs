using DbManager.DataObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS_Ga2.Entity;

namespace SIS_Ga2.DataAccess
{
    public class DACParametrosDiseno
    {
        public int Registrar(BEParametroDiseno objEntidad)
        {
            SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
            int resultado = 0;
            Parameter param = new Parameter();
            param.Add("@Id_Periodo", objEntidad.idPeriodo);
            param.Add("@Id_Diseno", objEntidad.idDiseno);
            param.Add("@ESAL", objEntidad.ESAL);
            param.Add("@Confiabilidad", objEntidad.Confiabilidad);
            param.Add("@Error_Combinacion", objEntidad.ErrorCombinac);
            param.Add("@Modulo_Resilencia", objEntidad.ModuloResilencia);
            param.Add("@Serviciabilidad_Inicial", objEntidad.ServInicial);
            param.Add("@Serviciabilidad_Final", objEntidad.ServFinal);
            param.Add("@Dif_Serviciabilidad", objEntidad.DiferenciaServ);
            param.Add("@Desviacion_Estandar", objEntidad.DesvEstandar);
            param.Add("@Resistencia_Comprencion", objEntidad.ResCompresion);
            param.Add("@Modulo_Rotura", objEntidad.ModuloRotura);
            param.Add("@Modulo_Elasticidad", objEntidad.ModuloElasticidad);
            param.Add("@Coeficiente_Transferencia", objEntidad.CoefTransfe);

            param.Add("@C_Asfaltica_Ingresado", objEntidad.C_Asfaltica_Ingresado);
            param.Add("@Base_Ingresado", objEntidad.Base_Ingresado);
            param.Add("@Sub_Base_Ingresado", objEntidad.Sub_Base_Ingresado);
            param.Add("@Sub_Rasante_Ingresado", objEntidad.Sub_Rasante_Ingresado);
            param.Add("@Capacidad_Elastica_Ingresado", objEntidad.Capacidad_Elastica_Ingresado);
            param.Add("@Concreto_Ingresado", objEntidad.Concreto_Ingresado);

            param.Add("@C_Asfaltica_Calculado", objEntidad.C_Asfaltica_Calculado);
            param.Add("@Base_Ingresado_Calculado", objEntidad.Base_Ingresado_Calculado);
            param.Add("@Sub_Base_Calculado", objEntidad.Sub_Base_Calculado);
            param.Add("@Sub_Rasante_Calculado", objEntidad.Sub_Rasante_Calculado);
            param.Add("@Capacidad_Elastica_Calculado", objEntidad.Capacidad_Elastica_Calculado);
            param.Add("@Concreto_Calculado", objEntidad.Concreto_Calculado);


            param.Add("@SN_Requerido", objEntidad.SN_Requerido);
            //param.Add("@SN_Prop", objEntidad.SN_Prop);
            param.Add("@D_Requerido", objEntidad.D_Requerido);
            param.Add("@N18_CALC1", objEntidad.N18_CALC1);
            param.Add("@N18_CALC2", objEntidad.N18_CALC2);
            param.Add("@N18_NOM1", objEntidad.N18_NOM1);
            param.Add("@N18_NOM2", objEntidad.N18_NOM2);
            param.Add("@Estado", objEntidad.Estado);

            param.Add("@Id_parametro", 0, System.Data.ParameterDirection.Output);

            try
            {
                objSql.ExecuteNonQuery("USP_Ins_Parametro_Diseno", param);
                resultado = Convert.ToInt32(param.get_Item(34).Value.ToString());
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultado;
        }

        public int Actualizar(BEParametroDiseno objEntidad)
        {
            SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
            int resultado = 0;
            Parameter param = new Parameter();
            param.Add("@Id_Diseno", objEntidad.idDiseno);
            param.Add("@Id_Parametro", objEntidad.idParametro);
            param.Add("@C_Asfaltica_Ingresado", objEntidad.C_Asfaltica_Ingresado);
            param.Add("@Base_Ingresado", objEntidad.Base_Ingresado);
            param.Add("@Sub_Base_Ingresado", objEntidad.Sub_Base_Ingresado);
            param.Add("@Sub_Rasante_Ingresado", objEntidad.Sub_Rasante_Ingresado);
            param.Add("@Capacidad_Elastica_Ingresado", objEntidad.Capacidad_Elastica_Ingresado);
            param.Add("@Concreto_Ingresado", objEntidad.Concreto_Ingresado);
            param.Add("@C_Asfaltica_Calculado", objEntidad.C_Asfaltica_Calculado);
            param.Add("@Base_Ingresado_Calculado", objEntidad.Base_Ingresado_Calculado);
            param.Add("@Sub_Base_Calculado", objEntidad.Sub_Base_Calculado);
            param.Add("@Sub_Rasante_Calculado", objEntidad.Sub_Rasante_Calculado);
            param.Add("@Capacidad_Elastica_Calculado", objEntidad.Capacidad_Elastica_Calculado);
            param.Add("@Concreto_Calculado", objEntidad.Concreto_Calculado);

            param.Add("@SN_Requerido", objEntidad.SN_Requerido);
            param.Add("@SN_Prop", objEntidad.SN_Prop);
            param.Add("@D_Requerido", objEntidad.D_Requerido);
            param.Add("@N18_CALC1", objEntidad.N18_CALC1);
            param.Add("@N18_CALC2", objEntidad.N18_CALC2);
            param.Add("@N18_NOM1", objEntidad.N18_NOM1);
            param.Add("@N18_NOM2", objEntidad.N18_NOM2);

                        
            try
            {
                objSql.ExecuteNonQuery("USP_Upd_Parametro_Diseno", param);
                resultado = 1;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultado;
        }
    }
}
