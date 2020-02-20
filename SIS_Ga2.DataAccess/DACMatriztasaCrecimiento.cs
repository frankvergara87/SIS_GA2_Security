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
    public class DACMatrizTasaCrecimiento
    {
        public int GuardartasaCrecimiento1(BEMatrizTasaCrecimiento objEntidad)
        {
            SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
            int resultado = 0;
            Parameter param = new Parameter();
            param.Add("@Id_Diseno", objEntidad.Id_Diseno);
            param.Add("@Nro_Anio", objEntidad.Nro_Anio);
            param.Add("@Id_Tipo_Vehiculo", objEntidad.Id_Tipo_Vehiculo);
            param.Add("@Valor", objEntidad.Valor);

            try
            {
                objSql.ExecuteNonQuery("USP_Ins_Tasa_Crecimi1", param);
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

        public int GuardartasaCrecimiento2(BEMatrizTasaCrecimiento objEntidad)
        {
            SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
            int resultado = 0;
            Parameter param = new Parameter();
            param.Add("@Id_Diseno", objEntidad.Id_Diseno);
            param.Add("@Nro_Anio", objEntidad.Nro_Anio);
            param.Add("@Id_Tipo_Vehiculo", objEntidad.Id_Tipo_Vehiculo);
            param.Add("@Valor", objEntidad.Valor);

            try
            {
                objSql.ExecuteNonQuery("USP_Ins_Tasa_Crecimi2", param);
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

        public int DeletetasaCrecimiento1(int IdDiseno)
        {
            SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
            int resultado = 0;
            Parameter param = new Parameter();
            param.Add("@Id_Diseno", IdDiseno);
  

            try
            {
                objSql.ExecuteNonQuery("USP_del_TasasCrecimiento1", param);
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

        public List<BEMatrizTasaCrecimiento> ListarTasaCrec1(int Id_Diseno)
        {
            try
            {
                Parameter param = new Parameter();
                param.Add("@Id_Diseno", Id_Diseno);
                SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
                List<BEMatrizTasaCrecimiento> lista = objSql.getStatement<BEMatrizTasaCrecimiento>("USP_Sel_TasasCrecimiento1", param);
                return lista;
            }
            catch (Exception ex)
            {
                //Rutina de Guardado en Log 
                //afilogDAO.Save(0, 0, "CatalogoDAO", "GetCatalogoToCombo", ex);
                throw ex;
            }

        }

        public List<BEMatrizTasaCrecimiento> ListarTasaCrec2(int Id_Diseno)
        {
            try
            {
                Parameter param = new Parameter();
                param.Add("@Id_Diseno", Id_Diseno);
                SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
                List<BEMatrizTasaCrecimiento> lista = objSql.getStatement<BEMatrizTasaCrecimiento>("USP_Sel_TasasCrecimiento2", param);
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
