using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS_Ga2.Entity;
using SIS_Ga2.DataAccess;

namespace SIS_Ga2.Business
{
    public class BLPropFactorDistribucion
    {
        public List<BEPropFactorDistribucion> ListarValorFactorDistrib(int Numero_Calzada, int Numero_Sentido, int Numero_Carril_x_Sentido)
        {

            BEPropFactorDistribucion objEntidad = new BEPropFactorDistribucion();
            List<BEPropFactorDistribucion> lobjbeDistrito = new List<BEPropFactorDistribucion>();
            DACPropFactorDistribucion objDAO = new DACPropFactorDistribucion();

            objEntidad.Numero_Calzada = Numero_Calzada;
            objEntidad.Numero_Sentido = Numero_Sentido;
            objEntidad.Numero_Carril_x_Sentido = Numero_Carril_x_Sentido;

            return objDAO.ListarValorFactorDistrib(objEntidad);
            
           
        }

        public List<BEPropFactorDistribucion> ListarFactorDistribucion(int TipoConsulta)
        {

            BEPropFactorDistribucion objEntidad = new BEPropFactorDistribucion();
            List<BEPropFactorDistribucion> lobjbeDistrito = new List<BEPropFactorDistribucion>();
            DACPropFactorDistribucion objDAO = new DACPropFactorDistribucion();

 
            return objDAO.ListarFactorDistribucion(TipoConsulta);

        }

        public int GuardarFactorDistrib(BEPropFactorDistribucion objEntidad)
        {
            DACPropFactorDistribucion objDAO = new DACPropFactorDistribucion();
            return objDAO.GuardarFactorDistrib(objEntidad);
        }
    }
}
