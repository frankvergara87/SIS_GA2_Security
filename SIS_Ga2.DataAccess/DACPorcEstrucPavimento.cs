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
  public  class DACPorcEstrucPavimento
    {
        public List<BEPorcEstructPavimento> ListarPorcEstrucPavimento(int IdPorcEstrucPavi)
        {
            try
            {
                Parameter param = new Parameter();
                param.Add("@Id_Porc_Estruc_Pavimen", IdPorcEstrucPavi);
                SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
                List<BEPorcEstructPavimento> lista = objSql.getStatement<BEPorcEstructPavimento>("USP_Sel_Porc_EstrucPav", param);
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
