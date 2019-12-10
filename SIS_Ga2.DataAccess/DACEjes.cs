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
    public class DACEjes
    {

        public List<BEEjes> ListarCantidadEjes(int idVehiculo)
        {
            try
            {
                Parameter param = new Parameter();
                param.Add("@idVehiculo", idVehiculo);
                SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
                List<BEEjes> lista = objSql.getStatement<BEEjes>("USP_Cantidad_Ejes", param);
                return lista;
            }
            catch (Exception ex)
            {
                //Rutina de Guardado en Log 
                //afilogDAO.Save(0, 0, "CatalogoDAO", "GetCatalogoToCombo", ex);
                throw ex;
            }
        }

        public List<BEEjes> ListarEjesxVehiculo(int idVehiculo)
        {
            try
            {
                Parameter param = new Parameter();
                param.Add("@idVehiculo", idVehiculo);
                SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
                List<BEEjes> lista = objSql.getStatement<BEEjes>("USP_Sel_Eje_x_Vehi", param);
                return lista;
            }
            catch (Exception ex)
            {
                //Rutina de Guardado en Log 
                //afilogDAO.Save(0, 0, "CatalogoDAO", "GetCatalogoToCombo", ex);
                throw ex;
            }
        }
        public List<BEEjes> ListarEjesPeso(int idVehiculo, int Id_Eje)
        {
            try
            {
                Parameter param = new Parameter();
                param.Add("@idVehiculo", idVehiculo);
                param.Add("@Id_Eje", Id_Eje);
                SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
                List<BEEjes> lista = objSql.getStatement<BEEjes>("USP_Sel_Ejes_Peso", param);
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
