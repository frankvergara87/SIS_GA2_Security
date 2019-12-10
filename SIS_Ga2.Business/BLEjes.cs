using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS_Ga2.Entity;
using SIS_Ga2.DataAccess;


namespace SIS_Ga2.Business
{
    public class BLEjes
    {


        public List<BEEjes> ListarCantidadEjes(int idVehiculo)
        {
            DACEjes objDAO = new DACEjes();
            return objDAO.ListarCantidadEjes(idVehiculo);
        }

        public List<BEEjes> ListarEjesPeso(int idVehiculo, int Id_Eje)
        {
            DACEjes objDAO = new DACEjes();
            return objDAO.ListarEjesPeso(idVehiculo, Id_Eje);
        }
        public List<BEEjes> ListarEjesxVehiculo(int idVehiculo)
        {
            DACEjes objDAO = new DACEjes();
            return objDAO.ListarEjesxVehiculo(idVehiculo);
        }

    }
}