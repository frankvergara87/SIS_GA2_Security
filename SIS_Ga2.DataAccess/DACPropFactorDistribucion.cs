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
    public class DACPropFactorDistribucion
    {
        public List<BEPropFactorDistribucion> ListarValorFactorDistrib(BEPropFactorDistribucion objEntidad)
        {
            try
            {
                Parameter param = new Parameter();
                param.Add("@Numero_calzada", objEntidad.Numero_Calzada);
                param.Add("@Numero_Sentido", objEntidad.Numero_Sentido);
                param.Add("@Numero_Carril_x_Sentido", objEntidad.Numero_Carril_x_Sentido);
                SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
                List<BEPropFactorDistribucion> lista = objSql.getStatement<BEPropFactorDistribucion>("USP_Sel_Valor_Factor_Distrib", param);
                return lista;
            }
            catch (Exception ex)
            {
                //Rutina de Guardado en Log 
                //afilogDAO.Save(0, 0, "CatalogoDAO", "GetCatalogoToCombo", ex);
                throw ex;
            }
        }

        public List<BEPropFactorDistribucion> ListarFactorDistribucion(int TipoConsulta)
        {
            try
            {
                //1 =numero_calzada; 2= Numero_Sentidos; 3=Numero_Carril_x_Sentido
                Parameter param = new Parameter();
                param.Add("@TipoConsulta", TipoConsulta);
                SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
                List<BEPropFactorDistribucion> lista = objSql.getStatement<BEPropFactorDistribucion>("USP_Sel_Factores_Distrib", param);
                return lista;
            }
            catch (Exception ex)
            {
                //Rutina de Guardado en Log 
                //afilogDAO.Save(0, 0, "CatalogoDAO", "GetCatalogoToCombo", ex);
                throw ex;
            }
        }

        public int GuardarFactorDistrib(BEPropFactorDistribucion objEntidad)
        {
            SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
            int resultado = 0;
            Parameter param = new Parameter();
            param.Add("@Id_Factor_Distribucion", objEntidad.Id_Factor_Distribucion);
            param.Add("@Numero_Calzada", objEntidad.Numero_Calzada);
            param.Add("@Numero_Sentido", objEntidad.Numero_Sentido);
            param.Add("@Numero_Carril_x_Sentido", objEntidad.Numero_Carril_x_Sentido);
            param.Add("@Valor_Distrib_Calculado", objEntidad.Valor_Distrib_Calculado);
            param.Add("@@Valor_Distrib_Ingresado", objEntidad.Valor_Distrib_Ingresado);
            param.Add("@Fecha_Creacion", objEntidad.Fecha_Creacion);
            param.Add("@Hora_Creacion", objEntidad.Hora_Creacion);
            param.Add("@Usr_Creacion", objEntidad.Usr_Creacion);
            param.Add("@Id_Prop_Factor_Distrib", 0, System.Data.ParameterDirection.Output);

            try
            {
                objSql.ExecuteNonQuery("USP_Ins_Prop_Factor_Distrib", param);
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
    }
}
