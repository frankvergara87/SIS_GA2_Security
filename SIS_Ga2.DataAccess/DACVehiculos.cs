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
    public class DACVehiculos 
    {
        public List<BEVehiculos> ListarVehiculos(int Id_Tipo_Vehiculo)
        {
            try
            {
                Parameter param = new Parameter();
                param.Add("@Id_Tipo_Vehiculo", Id_Tipo_Vehiculo);
                SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
                List<BEVehiculos> lista = objSql.getStatement<BEVehiculos>("USP_Sel_Vehiculos", param);
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
