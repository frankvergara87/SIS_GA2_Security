using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS_Ga2.Entity;
using SIS_Ga2.DataAccess;


namespace SIS_Ga2.Business
{
    public class BLPorcEstrucPavimento
    {

        public List<BEPorcEstructPavimento> ListarPorcEstrucPavimento(int Id_Porc_Estruc_Pavimen)
        {
            DACPorcEstrucPavimento objDAO = new DACPorcEstrucPavimento();
            return objDAO.ListarPorcEstrucPavimento(Id_Porc_Estruc_Pavimen);
        }


    }
}
