using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS_Ga2.Entity;
using SIS_Ga2.DataAccess;


namespace SIS_Ga2.Business
{
    public class BLTasaCrecimiento
    {

        public List<BETasaCrecimiento> ListarTasaCrecimiento(int idTasaCrecimiento)
        {
            DACTasaCrecimiento objDAO = new DACTasaCrecimiento();
            return objDAO.ListarTasaCrecimiento(idTasaCrecimiento);
        }

        public List<BETasaCrecimiento> ListarCrecimXTiempo(int Id_Diseno)
        {
            DACTasaCrecimiento objDAO = new DACTasaCrecimiento();
            return objDAO.ListarCrecimXTiempo(Id_Diseno);
        }
        public List<BETasaCrecimiento> ListarCrecimXVehiculo(int Id_Diseno)
        {
            DACTasaCrecimiento objDAO = new DACTasaCrecimiento();
            return objDAO.ListarCrecimXVehiculo(Id_Diseno);
        }

        public List<BETasaCrecimiento> ListarCrecimConstante(int Id_Diseno)
        {
            DACTasaCrecimiento objDAO = new DACTasaCrecimiento();
            return objDAO.ListarCrecimConstante(Id_Diseno);
        }

        public int GuardarCrecXTiempo(BETasaCrecimiento objEntidad)
        {
            DACTasaCrecimiento objDAO = new DACTasaCrecimiento();
            return objDAO.GuardarCrecXTiempo(objEntidad);
        }
        
        public int GuardarCrecConstante(BETasaCrecimiento objEntidad)
        {
            DACTasaCrecimiento objDAO = new DACTasaCrecimiento();
            return objDAO.GuardarCrecConstante(objEntidad);
        }

        public int ActualizarCrecXTiempo(BETasaCrecimiento objEntidad)
        {
            DACTasaCrecimiento objDAO = new DACTasaCrecimiento();
            return objDAO.ActualizarCrecXTiempo(objEntidad);
        }

        public int LimpiarVariableTiempo(BETasaCrecimiento objEntidad)
        {
            DACTasaCrecimiento objDAO = new DACTasaCrecimiento();
            return objDAO.LimpiarVariableTiempo(objEntidad);
        }

        public int LimpiarVariableVehiculo(BETasaCrecimiento objEntidad)
        {
            DACTasaCrecimiento objDAO = new DACTasaCrecimiento();
            return objDAO.LimpiarVariableVehiculo(objEntidad);
        }

        public int GuardarCrecXVehiculo(BETasaCrecimiento objEntidad)
        {
            DACTasaCrecimiento objDAO = new DACTasaCrecimiento();
            return objDAO.GuardarCrecXVehiculo(objEntidad);
        }

        public int ActualizarCrecXVehiculo(BETasaCrecimiento objEntidad)
        {
            DACTasaCrecimiento objDAO = new DACTasaCrecimiento();
            return objDAO.ActualizarCrecXVehiculo(objEntidad);
        }
    }
}
