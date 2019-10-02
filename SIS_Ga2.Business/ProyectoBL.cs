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
        public List<BEProyecto> ListarProyectos(int idTipoDiseno, int idUsuario)
        {
            ProyectoDAO objDAO = new ProyectoDAO();
            return objDAO.ListarProyectos(idTipoDiseno, idUsuario);
        }
        public List<BEProyecto> ListarProyectos2(String strProyecto, String strFechaProyecto, String FechaContrato, int Departamento, int Provincia, int Distrito, int IdIngeniero) 
        {
            ProyectoDAO objDAO = new ProyectoDAO();
            return objDAO.ListarProyectos2(strProyecto, strFechaProyecto, FechaContrato, Departamento, Provincia, Distrito, IdIngeniero);
        }

        public int GuardarProyecto(Proyecto DataProyecto)
        {
            ProyectoDAO objDAO = new ProyectoDAO();
            return objDAO.GuardarProyecto(DataProyecto);
        }

    }
}
