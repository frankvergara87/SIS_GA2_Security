using DbManager.DataObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS_Ga2.Entity;
using DbManager;

namespace SIS_Ga2.DataAccess
{
    public class ProyectoDAO
    {
        public List<BEProyecto> ListarProyectos(string NumProyecto, double FechaProyecto, double FechaContrato, int IdUsuario, int IdDistrito, int IdProvincia, int IdDepartamento, int idTipoDiseno)
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
                param.Add("@Id_TipoDiseno", idTipoDiseno);
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

        public int GuardarProyecto(BEProyecto DataProyecto, BEDiseno DataDiseno)
        {
            SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
            int resultado = 0;

            Parameter param = new Parameter();
            param.Add("@Num_Proyecto", DataProyecto.Num_Proyecto);
            param.Add("@Proyecto", DataProyecto.Proyecto);
            param.Add("@Fecha_Proyecto", DataProyecto.Fecha_Proyecto);
            param.Add("@Estado", DataProyecto.Estado);
            param.Add("@Id_Usuario", DataProyecto.id_Usuario);
            param.Add("@Fecha_Creacion", DataProyecto.FechaCreacion);
            param.Add("@Fecha_Contrato", DataProyecto.Fecha_Contrato);
            param.Add("@Hora_Creacion", DataProyecto.HoraCreacion);
            param.Add("@Usr_Creacion", DataProyecto.UsrCreacion);
            param.Add("@Fecha_Actualizacion", DataProyecto.FechaActualizacion);
            param.Add("@Hora_Actualizacion", DataProyecto.HoraActualizacion);
            param.Add("@Usr_Actualizacion", DataProyecto.UsrActualizacion);
            param.Add("@Num_Diseno", DataDiseno.NumeroDiseno);
            param.Add("@Id_Tramo", DataDiseno.idTramo);
            param.Add("@Id_Reglamento", DataDiseno.idReglamento);
            param.Add("@Id_TipoDiseno", DataDiseno.IdTipoDiseno);
            param.Add("@Id_Distrito", DataDiseno.idDistrito);
            param.Add("@IdProyecto", 0, System.Data.ParameterDirection.Output);
            param.Add("@IdDiseno", 0, System.Data.ParameterDirection.Output);

            try
            {
                objSql.ExecuteNonQuery("USP_Ins_Proyecto", param);
                resultado = Convert.ToInt32(param.get_Item(19).Value.ToString());
            }
            catch (Exception ex)
            {
                //Rutina de Guardado en Log 
                //afilogDAO.Save(0, 0, "CatalogoDAO", "GetCatalogoToCombo", ex);
                throw ex;
            }
            return resultado;
        }

        public int EliminarProyecto(Int32 Id_Proyecto, Int32 Id_Diseno, Int32 Id_Usuario)
        {
            SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
            int resultado = 0;
            Parameter param = new Parameter();
            param.Add("@Id_Proyecto", Id_Proyecto);
            param.Add("@Id_Diseno", Id_Diseno);
            param.Add("@Id_Usuario", Id_Usuario);
            param.Add("@Fecha_Actualizacion", 0);
            param.Add("@Hora_Actualizacion", 0);
            param.Add("@Usr_Actualizacion", "");
            try
            {
                objSql.ExecuteNonQuery("USP_Del_ProyDiseno", param);
                resultado = 1;
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
