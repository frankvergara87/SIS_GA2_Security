using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS_Ga2.Entity;
using SIS_Ga2.DataAccess;


namespace SIS_Ga2.Business
{
 

        public class BLProvincia
        {

            public List<BEProvincia> ListarProvincia(int idDepartamento)
            {

            DACProvincia objDAO = new DACProvincia();
            BEProvincia objbeProvincia = new BEProvincia();
            objbeProvincia.Id_Provincia = 0;
            objbeProvincia.Provincia = "TODOS";


            List<BEProvincia> lobjProvincia = new List<BEProvincia>();
            lobjProvincia.Add(objbeProvincia);

            if (idDepartamento > 0)
            {
                foreach (BEProvincia temp in objDAO.ListarProvincias(idDepartamento))
                {
                    lobjProvincia.Add(temp);
                }
            }
            return lobjProvincia;
            }
        }
    }

