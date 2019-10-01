using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS_Ga2.Entity;
using SIS_Ga2.DataAccess;


namespace SIS_Ga2.Business
{
    public class BLusuario
    {

        public List<BEUsuario> ListarUsuariosxPadre(Int32 strUsuarioPadre, String strApellido)
        {
            DACUsuario objDAO = new DACUsuario();
            return objDAO.ListarUsuariosxPadre(strUsuarioPadre, strApellido);
        }

        public List<BEUsuario> ListarUsuario()
        {
            DACUsuario objDAO = new DACUsuario();
            return objDAO.ListarUsuario();
        }
    }
}
