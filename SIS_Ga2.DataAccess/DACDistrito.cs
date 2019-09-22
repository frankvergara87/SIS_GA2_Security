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
    public class DACDistrito
    {
        public List<BEDistrito> ListarDistritos(int idProvincia)
        {
            try
            {
                Parameter param = new Parameter();
                param.Add("@IdProvincia", idProvincia);
                SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
                List<BEDistrito> lista = objSql.getStatement<BEDistrito>("[USP_Sel_Distrito]", param);
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
