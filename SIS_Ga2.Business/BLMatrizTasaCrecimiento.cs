using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS_Ga2.Entity;
using SIS_Ga2.DataAccess;

namespace SIS_Ga2.Business
{
    public class BLMatrizTasaCrecimiento
    {
        public List<BEMatrizTasaCrecimiento> ListarTasaCrec1(int Id_Diseno)
        {
            DACMatrizTasaCrecimiento objDAO = new DACMatrizTasaCrecimiento();
            return objDAO.ListarTasaCrec1(Id_Diseno);
        }
        public List<BEMatrizTasaCrecimiento> ListarTasaCrec2(int Id_Diseno)
        {
            DACMatrizTasaCrecimiento objDAO = new DACMatrizTasaCrecimiento();
            return objDAO.ListarTasaCrec2(Id_Diseno);
        }
        public int GuardartasaCrecimiento(BEMatrizTasaCrecimiento objEntidad,int NroMatriz)
        {
            DACMatrizTasaCrecimiento objDAO = new DACMatrizTasaCrecimiento();
            if (NroMatriz==1)
            {

                return objDAO.GuardartasaCrecimiento1(objEntidad);
            }

            else
            {
                return objDAO.GuardartasaCrecimiento2(objEntidad);
            }
                  
            
        }

        public int DelTasaCrecimiento(int Id_Diseno)
        {
            DACMatrizTasaCrecimiento objDAO = new DACMatrizTasaCrecimiento();
            return objDAO.DeletetasaCrecimiento1(Id_Diseno);
        }
    }
}
