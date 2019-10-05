using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS_Ga2.Entity;
using SIS_Ga2.DataAccess;


namespace SIS_Ga2.Business
{
    public class BLDistrito
    {

        public List<BEDistrito> ListarDistrito(int idProvincia)
        {

            BEDistrito objbeDistrito= new BEDistrito();
            List<BEDistrito> lobjbeDistrito = new List<BEDistrito>();
            DACDistrito objDAO = new DACDistrito();

            objbeDistrito.id_Distrito = 0;
            objbeDistrito.Distrito = "TODOS";
            lobjbeDistrito.Add(objbeDistrito);
            if (idProvincia > 0)
            {
                foreach (BEDistrito temp in objDAO.ListarDistritos(idProvincia))
                {
                    lobjbeDistrito.Add(temp);
                }
            }
            return lobjbeDistrito;
        }
    }
}
