using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS_Ga2.Entity;
using SIS_Ga2.DataAccess;

namespace SIS_Ga2.Business
{
    public class BLRepeticionesEqui
    {

        public int GuardarRepeticionesEqui(BERepeticionesEqui objEntidad)
        {
            DACRepeticionesEqui objDAO = new DACRepeticionesEqui();
            return objDAO.GuardarRepeticionesEqui(objEntidad);
        }

        public int ActualizarRepeticionesEqui(BERepeticionesEqui objEntidad)

        {
            DACRepeticionesEqui objDAO = new DACRepeticionesEqui();
            return objDAO.ActualizarRepeticionesEqui(objEntidad);
        }
    }
}
