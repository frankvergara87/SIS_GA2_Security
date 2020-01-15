using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS_Ga2.Entity;
using SIS_Ga2.DataAccess;

namespace SIS_Ga2.Business
{
    public class BLPresContacNeum
    {
        public List<BEPresContacNeum> ListarValorFP(int Id_Espesor, int Id_Presion)
        {
            DACPresContacNeum objDAO = new DACPresContacNeum();
            return objDAO.ListarValorFP(Id_Espesor, Id_Presion);
        }
    }
}

