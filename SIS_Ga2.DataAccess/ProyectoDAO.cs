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
        public List<BEProyecto> ListarProyectos(string NumProyecto, string FechaProyecto, string FechaContrato, int IdUsuario, int IdDistrito, int IdProvincia, int IdDepartamento)
        {
            try
            {
                Parameter param = new Parameter();
                param.Add("@Num_Proyecto", NumProyecto);
                param.Add("@Fecha_Proyecto", FechaProyecto);
                param.Add("@Fecha_Contrato", FechaContrato);
                param.Add("@Id_Usuario", IdUsuario);
                param.Add("@Id_Distrito", IdDistrito);
                param.Add("@Id_Provincia", IdProvincia);
                param.Add("@Id_Departamento", IdDepartamento);
                SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
                List<BEProyecto> lista = objSql.getStatement<BEProyecto>("USP_ListaProyDiseno_Lst", param);
                return lista;
            }
            catch (Exception ex)
            {
                //Rutina de Guardado en Log 
                //afilogDAO.Save(0, 0, "CatalogoDAO", "GetCatalogoToCombo", ex);
                throw ex;
            }
        }


        public List<BEProyecto> ListarProyectos2(string strNumProyecto, string strFechaProyecto)
        {
            try
            {
                Parameter param = new Parameter();
                param.Add("@Num_Proyecto", strNumProyecto);
                param.Add("@Fecha_Proyecto", strFechaProyecto);
                //param.Add("@Fecha_Contrato", strFechaContrato);
                //param.Add("@Id_Usuario", strIdUsuario);
                //param.Add("@Id_Distrito", strIdDistrito);
                //param.Add("@Id_Provincia", strIdProvincia);
                //param.Add("@Id_Departamento", strIdDepartamento);

                SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
                List<BEProyecto> lista = objSql.getStatement<BEProyecto>("USP_ListaProyDiseno_Lst", param);
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
