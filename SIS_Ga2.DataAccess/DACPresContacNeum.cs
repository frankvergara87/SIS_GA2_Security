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
    public class DACPresContacNeum
    {
        public List<BEPresContacNeum> ListarValorFP(int Id_Espesor,int Id_Presion)
        {
            try
            {
                Parameter param = new Parameter();
                param.Add("@Id_Espesor", Id_Espesor);
                param.Add("@Id_Presion", Id_Presion);
                SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
                List<BEPresContacNeum> lista = objSql.getStatement<BEPresContacNeum>("USP_Sel_Pres_Contac_Neum", param);
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
