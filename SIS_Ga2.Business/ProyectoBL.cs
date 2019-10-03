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
            ProyectoDAO objDAO = new ProyectoDAO();
            return objDAO.ListarProyectos(NumProyecto, FechaProyecto, FechaContrato, IdUsuario, IdDistrito, Provincia, Departamento);
        }
        public List<BEProyecto> ListarProyectos2(string strNumProyecto, string strFechaProyecto)
        {
            ProyectoDAO objDAO = new ProyectoDAO();
            return objDAO.ListarProyectos2(strNumProyecto, strFechaProyecto);
        }

        public int GuardarProyecto(Proyecto DataProyecto)
        {
            ProyectoDAO objDAO = new ProyectoDAO();
            return objDAO.GuardarProyecto(DataProyecto);
        }

    }
}
