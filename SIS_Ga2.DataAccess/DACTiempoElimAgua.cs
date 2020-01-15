using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS_Ga2.Entity;
using DbManager.DataObjects;
using System;
namespace SIS_Ga2.DataAccess
{
    public class DACTiempoElimAgua
    {
        public List<BETiempoElimAgua> ListarTiempoElimAguaXID(int IDTiempoElimAgua)
        {
            try
            {
                Parameter param = new Parameter();
                param.Add("@Id_Tiempo_Elim_Agua", IDTiempoElimAgua);
                SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
                List<BETiempoElimAgua> lista = objSql.getStatement<BETiempoElimAgua>("USP_Sel_Tiempo_ElimAgua", param);
                return lista;
            }
            catch (Exception ex)
            {
                //Rutina de Guardado en Log 
                //afilogDAO.Save(0, 0, "CatalogoDAO", "GetCatalogoToCombo", ex);
                throw ex;
            }
        }
    }
}
