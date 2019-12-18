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
    public class DACVehiculosIMD
    {


        public int GuardarVehiculosIMD(BEVehiculosIMD objEntidad)
        {
            SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
            int resultado = 0;
            Parameter param = new Parameter();
            param.Add("@Id_Vehiculos", objEntidad.Id_Vehiculos);
            param.Add("@Id_Repet_Equivalentes", objEntidad.Id_Repet_Equivalentes);
            param.Add("@IMD_Base", objEntidad.IMD_Base);
            param.Add("@Estado", objEntidad.Estado);
            param.Add("@Tipo_Eje_E1", objEntidad.Tipo_Eje_E1);
            param.Add("@Peso_Tonelada_E1", objEntidad.Peso_Tonelada_E1);
            param.Add("@Tipo_Eje_E2", objEntidad.Tipo_Eje_E2);
            param.Add("@Peso_Tonelada_E2", objEntidad.Peso_Tonelada_E2);
            param.Add("@Tipo_Eje_E3", objEntidad.Tipo_Eje_E3);
            param.Add("@Peso_Tonelada_E3", objEntidad.Peso_Tonelada_E3);
            param.Add("@Tipo_Eje_E4", objEntidad.Tipo_Eje_E4);
            param.Add("@Peso_Tonelada_E4", objEntidad.Peso_Tonelada_E4);
            param.Add("@Tipo_Eje_E5", objEntidad.Tipo_Eje_E5);
            param.Add("@Peso_Tonelada_E5", objEntidad.Peso_Tonelada_E5);

            param.Add("@Valor_FVP", objEntidad.Valor_FVP);
            param.Add("@Valor_EE", objEntidad.Valor_EE);
            param.Add("@Fecha_Creacion", objEntidad.Fecha_Creacion);
            param.Add("@Hora_Creacion", objEntidad.Hora_Creacion);
            param.Add("@Usr_Creacion", objEntidad.Usr_Creacion);

            param.Add("@Fecha_Actualizacion", objEntidad.Fecha_Actualizacion);
            param.Add("@Hora_Actualizacion", objEntidad.Hora_Actualizacion);
            param.Add("@Usr_Actualizacion", objEntidad.Usr_Actualizacion);

            param.Add("@Id_Vehiculos_IMD", 0, System.Data.ParameterDirection.Output);
            try
            {
                objSql.ExecuteNonQuery("USP_Ins_Vehiculos_IMD", param);
                resultado = 1;
            }
            catch (Exception ex)
            {
                //Rutina de Guardado en Log 
                //afilogDAO.Save(0, 0, "CatalogoDAO", "GetCatalogoToCombo", ex);
                throw ex;
            }
            return resultado;
        }
        public List<BEVehiculosIMD> ListarVehiculosIMDByID(int Id_Repet_Equivalentes)
        {
            try
            {
                Parameter param = new Parameter();
                param.Add("@Id_Repet_Equivalentes", Id_Repet_Equivalentes);
                SqlManager objSql = new SqlManager();
                List<BEVehiculosIMD> lista = objSql.getStatement<BEVehiculosIMD>("USP_Sel_Vehiculos_IMD", param);
                return lista;
            }
            catch (Exception ex)
            {
                //Rutina de Guardado en Log 
                //afilogDAO.Save(0, 0, "CatalogoDAO", "GetCatalogoToCombo", ex);
                throw ex;
            }
        }


    }
}
