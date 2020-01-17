using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS_Ga2.Entity;
using SIS_Ga2.DataAccess;

using System.Configuration;
using System.Web.UI.DataVisualization.Charting;

namespace SIS_Ga2.Business
{
    public class BLCoefDreBaseReg
    {

        public List<BECoefDreBaseReg> ListarCoefDrenaje(int IdCalidadDre, decimal ValorPorcentaje, string IDProyecto)
        {
            List<BECoefDreBaseReg> lista = new List<BECoefDreBaseReg>();
            DACCoefDreBaseReg objDAO = new DACCoefDreBaseReg();
            decimal ValorPorcCalc = 0;
            int IntValorPorcentaje = 0;
            string strValorPorc = "";
            string strValorPorcSubs = "";
            string strValorPorcRemo = "";
            string strValorResultado = "";
            int pos = 0;
            string CodProyecto = Convert.ToString(ConfigurationManager.AppSettings["CodProyecto"].ToString());// Valor defecto es id de CONCRETO 
            decimal valorTopePorc = Convert.ToDecimal(ConfigurationManager.AppSettings["valorTopePorc"].ToString());// Valor tope= 25%
            string separadorDecimal = Convert.ToString(ConfigurationManager.AppSettings["separadorDecimal"].ToString());// Separador Decimal=.
            strValorPorc = ValorPorcentaje.ToString();
            pos= strValorPorc.IndexOf(separadorDecimal);
            if (pos>0)
            {
            strValorPorcSubs = strValorPorc.Substring(pos, 2);
            strValorPorcRemo = strValorPorc.Remove(pos);
            strValorResultado = strValorPorcRemo + strValorPorcSubs;

                ValorPorcCalc = Convert.ToDecimal(strValorResultado);

            }
            else

            {
                ValorPorcCalc = ValorPorcentaje;

            }



            if ((ValorPorcCalc >= 1)  && (ValorPorcCalc >= valorTopePorc))

             {
                IntValorPorcentaje = (int)ValorPorcCalc;
                if (CodProyecto == IDProyecto) // Si es CONCRETO
                {

                    lista= objDAO.ListarCoefDrenaje2(IdCalidadDre, valorTopePorc);

                }

                else 
                {
                    lista= objDAO.ListarCoefDrenaje1(IdCalidadDre, valorTopePorc);
                }

               
            }

          
            if (ValorPorcCalc < 1)

            { 
                if (CodProyecto == IDProyecto) // Si es CONCRETO

                {
                    lista =  objDAO.ListarCoefDrenaje2(IdCalidadDre, ValorPorcCalc);

                }

                else

                {
                    lista =   objDAO.ListarCoefDrenaje1(IdCalidadDre, ValorPorcCalc);

                }
            }



            if ((ValorPorcCalc >= 1) && (ValorPorcCalc < (decimal)1.5))
            {

                IntValorPorcentaje = (int)ValorPorcCalc;
                if (CodProyecto == IDProyecto) // Si es CONCRETO
                {

                    lista = objDAO.ListarCoefDrenaje2(IdCalidadDre, IntValorPorcentaje);

                }

                else
                {
                    lista = objDAO.ListarCoefDrenaje1(IdCalidadDre, IntValorPorcentaje);
                }
            }


            if ((ValorPorcCalc >= (decimal)1.5) && (ValorPorcCalc < 2))
            {

                ValorPorcCalc = (decimal)1.5;
                if (CodProyecto == IDProyecto) // Si es CONCRETO
                {

                    lista = objDAO.ListarCoefDrenaje2(IdCalidadDre, ValorPorcCalc);

                }

                else
                {
                    lista = objDAO.ListarCoefDrenaje1(IdCalidadDre, ValorPorcCalc);
                }
            }

            if ((ValorPorcCalc >= 2) && (ValorPorcCalc < valorTopePorc))
            {
 
                IntValorPorcentaje = (int)ValorPorcCalc;
                if (CodProyecto == IDProyecto) // Si es CONCRETO
                {

                    lista = objDAO.ListarCoefDrenaje2(IdCalidadDre, IntValorPorcentaje);

                }

                else
                {
                    lista = objDAO.ListarCoefDrenaje1(IdCalidadDre, IntValorPorcentaje);
                }
            }
            return lista;


        }
    }
}
