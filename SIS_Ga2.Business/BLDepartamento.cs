using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS_Ga2.Entity;
using SIS_Ga2.DataAccess;


namespace SIS_Ga2.Business
{
    public class BLDepartamento
    {

        public List<BeDepartamento> ListarDepartamentos(int idDepartamento)
        {

            BeDepartamento objbeDepartamento = new BeDepartamento();
            List<BeDepartamento> lobjbeDepartamento = new List<BeDepartamento>();
            DACDepartamento objDAO = new DACDepartamento();

            objbeDepartamento.Id_Departamento = 0;
            objbeDepartamento.Departamento = "TODOS";

            lobjbeDepartamento.Add(objbeDepartamento);

            foreach (BeDepartamento temp in objDAO.ListarDepartamentos(idDepartamento))
            {
                lobjbeDepartamento.Add(temp);
            }

            return lobjbeDepartamento;
                     }
    }
}
