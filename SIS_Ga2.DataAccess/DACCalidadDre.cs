using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS_Ga2.Entity;
using DbManager.DataObjects;
using System;
namespace SIS_Ga2.DataAccess
{
  public   class DACCalidadDre
    {
        public List<BECalidadDre> ListarCaliDrenajesXID(int IdCalidadDre)
        {
            try
            {
                Parameter param = new Parameter();
                param.Add("@Id_Calidad_Drena", IdCalidadDre  );
                SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
                List<BECalidadDre> lista = objSql.getStatement<BECalidadDre>("USP_Sel_Cal_Drenaje", param);
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
