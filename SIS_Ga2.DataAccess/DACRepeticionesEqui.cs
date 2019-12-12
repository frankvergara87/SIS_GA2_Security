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
    public class DACRepeticionesEqui
    {


        public int GuardarRepeticionesEqui(BERepeticionesEqui objEntidad)
        {
            SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
            int resultado = 0;

            string val;
             
            Parameter param = new Parameter();
            param.Add("@Id_Tasa_Crecimiento", objEntidad.Id_Tasa_Crecimiento);
            param.Add("@Id_Prop_Factor_Distrib", objEntidad.Id_Prop_Factor_Distrib);
            param.Add("@Dias_Diseno", objEntidad.Dias_Diseno);
            param.Add("@FP", objEntidad.FP);
            param.Add("@Tipo_Diseno", objEntidad.Tipo_Diseno);
            param.Add("@Periodo", objEntidad.Periodo);
            param.Add("@Valor_EE_Total", objEntidad.Valor_EE_Total);
            param.Add("@Id_Parametro", objEntidad.Id_Parametro);
            param.Add("@Fecha_Creacion", objEntidad.Fecha_Creacion);
            param.Add("@Hora_Creacion", objEntidad.Hora_Creacion);
            param.Add("@Usr_Creacion", objEntidad.Usr_Creacion);


            //param.Add("@Id_Repet_Equivalentes", 0, System.Data.ParameterDirection.Output);

            try
            {
                //objSql.ExecuteNoQuery("USP_Ins_Repetic_Equivalentes", param);
                val = objSql.ExecuteScalar("USP_Ins_Repetic_Equivalentes", param);


                resultado = Convert.ToInt32(val);
            }
            catch (Exception ex)
            {
                //Rutina de Guardado en Log 
                //afilogDAO.Save(0, 0, "CatalogoDAO", "GetCatalogoToCombo", ex);
                throw ex;
            }
            return resultado;
        }
    }
}
