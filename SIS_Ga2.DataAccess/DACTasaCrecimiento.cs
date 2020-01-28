﻿using DbManager.DataObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS_Ga2.Entity;

namespace SIS_Ga2.DataAccess
{
    public class DACTasaCrecimiento
    {
        public List<BETasaCrecimiento> ListarTasaCrecimiento(int idTasaCrecimiento)
        {
            try
            {
                Parameter param = new Parameter();
                param.Add("@idTasaCrecimiento", idTasaCrecimiento);
                SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
                List<BETasaCrecimiento> lista = objSql.getStatement<BETasaCrecimiento>("[USP_Sel_TasaCrecimiento]", param);
                return lista;
            }
            catch (Exception ex)
            {
                //Rutina de Guardado en Log 
                //afilogDAO.Save(0, 0, "CatalogoDAO", "GetCatalogoToCombo", ex);
                throw ex;
            }
        }
        public List<BETasaCrecimiento> ListarCrecimXVehiculo(int Id_Diseno)
        {
            try
            {
                Parameter param = new Parameter();
                param.Add("@Id_Diseno", Id_Diseno);
                SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
                List<BETasaCrecimiento> lista = objSql.getStatement<BETasaCrecimiento>("USP_Sel_Tasa_Crec_X_Vehiculo", param);
                return lista;
            }
            catch (Exception ex)
            {
                //Rutina de Guardado en Log 
                //afilogDAO.Save(0, 0, "CatalogoDAO", "GetCatalogoToCombo", ex);
                throw ex;
            }
        }

        public List<BETasaCrecimiento> ListarCrecimXTiempo(int Id_Diseno)
        {
            try
            {
                Parameter param = new Parameter();
                param.Add("@Id_Diseno", Id_Diseno);
                SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
                List<BETasaCrecimiento> lista = objSql.getStatement<BETasaCrecimiento>("USP_Sel_Tasa_Crec_X_Tiempo", param);
                return lista;
            }
            catch (Exception ex)
            {
                //Rutina de Guardado en Log 
                //afilogDAO.Save(0, 0, "CatalogoDAO", "GetCatalogoToCombo", ex);
                throw ex;
            }
        }

        public List<BETasaCrecimiento> ListarCrecimConstante(int Id_Diseno)
        {
            try
            {
                Parameter param = new Parameter();
                param.Add("@Id_Diseno", Id_Diseno);
                SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
                List<BETasaCrecimiento> lista = objSql.getStatement<BETasaCrecimiento>("USP_Sel_Tasa_Crec_Constante", param);
                return lista;
            }
            catch (Exception ex)
            {
                //Rutina de Guardado en Log 
                //afilogDAO.Save(0, 0, "CatalogoDAO", "GetCatalogoToCombo", ex);
                throw ex;
            }
        }

        public int GuardarCrecXTiempo(BETasaCrecimiento objEntidad)
        {
            SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
            int resultado = 0;
            Parameter param = new Parameter();
            param.Add("@Id_Diseno", objEntidad.Id_Parametro);
            param.Add("@Nro_Anio", objEntidad.NroAnio);        
            param.Add("@Valor", objEntidad.Valor);

            try
            {
                objSql.ExecuteNonQuery("USP_Ins_Tasa_Crec_X_Tiempo", param);
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
        public int GuardarCrecXVehiculo(BETasaCrecimiento objEntidad)
        {
            SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
            int resultado = 0;
            Parameter param = new Parameter();
            param.Add("@Id_Diseno", objEntidad.Id_Parametro);
            param.Add("@Id_Tipo_Vehiculo", objEntidad.Id_Tipo_Vehiculo);
            param.Add("@Valor", objEntidad.Valor);

            try
            {
                objSql.ExecuteNonQuery("USP_Ins_Tasa_Crec_X_Vehiculo", param);
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

        public int GuardarCrecConstante(BETasaCrecimiento objEntidad)
        {
            SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
            int resultado = 0;
            Parameter param = new Parameter();
            param.Add("@Id_Diseno", objEntidad.Id_Parametro);
             param.Add("@Valor", objEntidad.Valor);

            try
            {
                objSql.ExecuteNonQuery("USP_Ins_Tasa_Crec_Constante", param);
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
