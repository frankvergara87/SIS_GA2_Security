using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS_Ga2.DataAccess;
using SIS_Ga2.Entity;

namespace SIS_Ga2.Business
{
    public class ProyectoBL
    {
        public List<BEProyecto> ListarProyectos(string NumProyecto, string FechaProyecto, string FechaContrato, int IdUsuario, int IdDistrito, int Provincia, int Departamento)
        {
            BEProyecto objbeDistrito = new BEProyecto();
            List<BEProyecto> lobjbeProyecto = new List<BEProyecto>();
            ProyectoDAO objDAO = new ProyectoDAO();

            foreach (BEProyecto temp in objDAO.ListarProyectos(NumProyecto, FechaProyecto, FechaContrato, IdUsuario, IdDistrito, Provincia, Departamento))
            {
                temp.Fecha_Proyecto_Date = HelpClass.CNumero_a_Fecha(temp.Fecha_Proyecto);
                temp.Fecha_Contrato_Date = HelpClass.CNumero_a_Fecha(temp.Fecha_Contrato);
                lobjbeProyecto.Add(temp);

            }

            return lobjbeProyecto;


        }
        public List<BEProyecto> ListarProyectos2(string strNumProyecto, string strFechaProyecto)
        {
            ProyectoDAO objDAO = new ProyectoDAO();
            return objDAO.ListarProyectos2(strNumProyecto, strFechaProyecto);
        }

        public int GuardarProyecto(BEProyecto DataProyecto)
        {
            ProyectoDAO objDAO = new ProyectoDAO();
            return objDAO.GuardarProyecto(DataProyecto);
        }

    }
}
