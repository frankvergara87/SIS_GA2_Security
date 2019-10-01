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
    public class DACUsuario
    {
        public List<BEUsuario> ListarUsuariosxPadre(Int32 strUsuarioPadre, String strApellido)
        {
            try
            {
                Parameter param = new Parameter();
                param.Add("@IDUsuarioPadre", strUsuarioPadre);
                param.Add("@Apellido", strApellido);
                SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
                List<BEUsuario> lista = objSql.getStatement<BEUsuario>("USP_Sel_UsuarioxPadre", param);
                return lista;
            }
            catch (Exception ex)
            {
                //Rutina de Guardado en Log 
                //afilogDAO.Save(0, 0, "CatalogoDAO", "GetCatalogoToCombo", ex);
                throw ex;
            }
        }

        public List<BEUsuario> ListarUsuario()
        {


            try
            {
                Parameter param = new Parameter();
                SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
                List<BEUsuario> lista = objSql.getStatement<BEUsuario>("USP_Usuarios_Lst", param);
                param = null;
                objSql.Dispose();
                objSql = null;
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
