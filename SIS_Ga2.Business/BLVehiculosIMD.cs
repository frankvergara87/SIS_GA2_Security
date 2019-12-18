using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS_Ga2.Entity;
using SIS_Ga2.DataAccess;

namespace SIS_Ga2.Business
{
    public class BLVehiculosIMD
    {

        public int GuardarVehiculosIMD(BEVehiculosIMD objEntidad)
        {
            DACVehiculosIMD objDAO = new DACVehiculosIMD();
            return objDAO.GuardarVehiculosIMD(objEntidad);
        }
        public List<BEVehiculosIMD> ListarVehiculosIMDByID(int Id_Repet_Equivalentes)
        {
            DACVehiculosIMD objDAO = new DACVehiculosIMD();
            return objDAO.ListarVehiculosIMDByID(Id_Repet_Equivalentes);
        }

    }
}
