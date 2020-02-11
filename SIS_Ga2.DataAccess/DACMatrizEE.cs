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
 public   class DACMatrizEE
    {
        public List<BEMatrizEE> ListarInfoMatrizEE(int id_Diseno)
        {
            try
            {
                Parameter param = new Parameter();
                param.Add("@id_Diseno", id_Diseno);
                SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
                List<BEMatrizEE> lista = objSql.getStatement<BEMatrizEE>("USP_Sel_Info_Matriz_EE", param);
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
