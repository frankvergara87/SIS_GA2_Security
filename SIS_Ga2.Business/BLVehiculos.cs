using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS_Ga2.Entity;
using SIS_Ga2.DataAccess;


namespace SIS_Ga2.Business
{
    public class BLVehiculos 
    {

        public List<BEVehiculos> ListarVehiculos(int Id_Tipo_Vehiculo)
        {
            DACVehiculos objDAO = new DACVehiculos();
            return objDAO.ListarVehiculos(Id_Tipo_Vehiculo);
        }


    }
}
