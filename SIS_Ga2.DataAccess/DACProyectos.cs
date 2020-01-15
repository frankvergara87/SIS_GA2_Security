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
    public class DACProyectos
    {

        public List<BEProyecto> ListarProyectosxId(int idProyecto)
        {
            try
            {
                Parameter param = new Parameter();
                param.Add("@idProyecto", idProyecto);
                SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
                List<BEProyecto> lista = objSql.getStatement<BEProyecto>("USP_ListarProyectosXId_Lst", param);
                return lista;
            }
            catch (Exception ex)
            {
                //Rutina de Guardado en Log 
                //afilogDAO.Save(0, 0, "CatalogoDAO", "GetCatalogoToCombo", ex);
                throw ex;
            }
        }

        public List<BEProyecto> ListarProyectos()
        {
            try
            {
                Parameter param = new Parameter();
                SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
                List<BEProyecto> lista = objSql.getStatement<BEProyecto>("USP_Proyectos_Lst", param);
                param = null;
                objSql.Dispose();
                objSql = null;
                return lista;
            }
            catch (Exception ex)
            {
                //Rutina de Guardado en Log 
                //afilogDAO.Save(0, 0, "CatalogoDAO", "GetCatalogoToCombo", ex);
                throw ex;
            }
        }




        public int GuardarCoeficientes(BECoefEstructura objEntidad)
        {
            SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
            int resultado = 0;
            Parameter param = new Parameter();
            param.Add("@Id_Diseno", objEntidad.idDiseno);
            param.Add("@Id_TipoPavimento", objEntidad.idTipoPavimento);
            param.Add("@Coeficiente_Drenaje_Calc", objEntidad.Coeficiente_Drenaje_Calc);
            param.Add("@Coeficiente_Drenaje_Ingresado", objEntidad.Coeficiente_Drenaje_Ingresado);
            param.Add("@Coeficiente_Estructural_Calc", objEntidad.Coeficiente_Estructural_Calc);
            param.Add("@Coeficiente_Estructural_Ingresado", objEntidad.Coeficiente_Estructural_Ingresado);
            param.Add("@Fecha_Creacion", objEntidad.FechaCreacion);
            param.Add("@Hora_Creacion", objEntidad.HoraCreacion);
            param.Add("@Usr_Creacion", objEntidad.UsrCreacion);
         
            try
            {
                objSql.ExecuteNonQuery("USP_Ins_Coeficientes", param);
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
