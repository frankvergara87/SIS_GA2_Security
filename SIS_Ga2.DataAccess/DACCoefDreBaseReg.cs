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
    public class DACCoefDreBaseReg

    {
        public List<BECoefDreBaseReg> ListarCoefDrenaje1(int IdCalidadDre, decimal ValorPorcentaje)
        {
            try
            {
                Parameter param = new Parameter();
                param.Add("@ID_CALIDAD_DRENA", IdCalidadDre);
                param.Add("@VALOR_PORCENTAJE", ValorPorcentaje);
                SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
                List<BECoefDreBaseReg> lista = objSql.getStatement<BECoefDreBaseReg>("USP_Sel_CSBG1", param);
                return lista;
            }
            catch (Exception ex)
            {
                //Rutina de Guardado en Log 
                //afilogDAO.Save(0, 0, "CatalogoDAO", "GetCatalogoToCombo", ex);
                throw ex;
            }
        }

        public List<BECoefDreBaseReg> ListarCoefDrenaje2(int IdCalidadDre, decimal ValorPorcentaje)
        {
            try
            {
                Parameter param = new Parameter();
                param.Add("@ID_CALIDAD_DRENA", IdCalidadDre);
                param.Add("@VALOR_PORCENTAJE", ValorPorcentaje);
                SqlManager objSql = new SqlManager(ConfigurationManager.AppSettings["ASOCEM"].ToString());
                List<BECoefDreBaseReg> lista = objSql.getStatement<BECoefDreBaseReg>("USP_Sel_CSBG2", param);
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
