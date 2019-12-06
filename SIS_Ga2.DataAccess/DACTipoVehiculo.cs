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
    public class DACTipoVehiculo
    {
        public List<BETipoVehiculos> ListarTipoVehiculos(int IdTipoVehiculos)
        {
            try
            {
                Parameter param = new Parameter();
                param.Add("@Id_Tipo_Vehiculo", IdTipoVehiculos);
                SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
                List<BETipoVehiculos> lista = objSql.getStatement<BETipoVehiculos>("[USP_Sel_Tipo_Vehiculos]", param);
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
