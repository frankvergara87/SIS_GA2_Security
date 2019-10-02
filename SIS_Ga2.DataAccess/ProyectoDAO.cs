using DbManager.DataObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS_Ga2.Entity;

namespace SIS_Ga2.DataAccess
{
    public class ProyectoDAO
    {
        public List<BEProyecto> ListarProyectos(int idTipoDiseno, int idUsuario)
        {
            try
            {
                Parameter param = new Parameter();
                param.Add("@idTipoDiseno", idTipoDiseno);
                param.Add("@IdUsuario", idUsuario);
                SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
                List<BEProyecto> lista = objSql.getStatement<BEProyecto>("USP_ListaProyecto_Lst", param);
                return lista;
            }
            catch (Exception ex)
            {
                //Rutina de Guardado en Log 
                //afilogDAO.Save(0, 0, "CatalogoDAO", "GetCatalogoToCombo", ex);
                throw ex;
            }
        }


        public List<BEProyecto> ListarProyectos2(String strProyecto, String strFechaProyecto, String FechaContrato, int Departamento, int Provincia, int Distrito, int IdIngeniero)
        {
            try
            {
                Parameter param = new Parameter();
                param.Add("@Num_Proyecto", strProyecto);
                param.Add("@Fecha_Proyecto", Int32.Parse(strFechaProyecto));
                param.Add("@Fecha_Contrato", Int32.Parse(FechaContrato));
                param.Add("@Id_Usuario", Departamento);
                param.Add("@Id_Provincia", Provincia);
                param.Add("@Id_Departamento", IdIngeniero);

                SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
                List<BEProyecto> lista = objSql.getStatement<BEProyecto>("USP_ListaProyDiseno_Lst2", param);
                return lista;
            }
            catch (Exception ex)
            {
                //Rutina de Guardado en Log 
                //afilogDAO.Save(0, 0, "CatalogoDAO", "GetCatalogoToCombo", ex);
                throw ex;
            }
        }

        public int GuardarProyecto(Proyecto DataProyecto)
        {
            int resultado = 0;

            try
            {
                Parameter param = new Parameter();
                param.Add("@CodProyecto", DataProyecto.CodProyecto);
                param.Add("@IdUsuario", DataProyecto.idUsuario);
                param.Add("@idReglamento", DataProyecto.idReglamento);
                param.Add("@idTipoDiseno", DataProyecto.idTipoDiseno);
                param.Add("@FecProyecto", DataProyecto.FecProyecto);
                param.Add("@Ubicacion", DataProyecto.Ubicacion);
                param.Add("@NumDiseno", DataProyecto.NumDiseno);
                param.Add("@Tramo", DataProyecto.Tramo);
                SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());

                resultado = Convert.ToInt32(objSql.ExecuteNoQuery("USP_InsProyecto", param));
                

            }
            catch (Exception ex)
            {
                //Rutina de Guardado en Log 
                //afilogDAO.Save(0, 0, "CatalogoDAO", "GetCatalogoToCombo", ex);
                throw ex;
            }
            return resultado;
        }
    }
}
