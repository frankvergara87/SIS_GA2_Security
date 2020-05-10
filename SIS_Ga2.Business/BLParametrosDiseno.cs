using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS_Ga2.Entity;
using SIS_Ga2.DataAccess;



namespace SIS_Ga2.Business
{
    public class BLParametrosDiseno
    {
        public int Guardar(BEParametroDiseno objEntidad)
        {
            DACParametrosDiseno objDAO = new DACParametrosDiseno();
            return objDAO.Registrar(objEntidad);
        }

        public int Actualizar(BEParametroDiseno objEntidad)
        {
            DACParametrosDiseno objDAO = new DACParametrosDiseno();
            return objDAO.Actualizar(objEntidad);
        }
    }
}
