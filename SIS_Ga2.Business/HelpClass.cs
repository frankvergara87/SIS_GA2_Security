using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Ga2.Business
{
    public static class HelpClass
    {
        public static string CNumero_a_Fecha(decimal oFecha)
        {
            string objDate;
            if (oFecha > 0)
            {
                string y;
                string m;
                string d;
            y = oFecha.ToString().Substring(0, 4);         
            m = oFecha.ToString().Substring(0, 6).Substring(4, 2);
            d = oFecha.ToString().Substring(oFecha.ToString().Length - 2, 2);

                objDate = string.Format("{0}/{1}/{2}", d, m, y); 
            }
            else
            {
                objDate = "00/00/0000";
            }
            return objDate;
        }

        public static Double CFecha_a_Numero(string oFecha)
        {
            Double objDate;
            if  (  oFecha.Equals( "0") ||   oFecha.Equals (""))
            {
                objDate = 0;
              
            }
            else
            {
                string y;
                string m;
                string d;
                d = oFecha.ToString().Substring(0, 2);
                m = oFecha.ToString().Substring(0, 5).Substring(3, 2);
                y = oFecha.ToString().Substring(oFecha.ToString().Length - 4, 4);

                objDate = double.Parse(string.Format("{0}{1}{2}", y, m, d));

            }
            return objDate;
        }

        public static string CNumero_a_Hora(double oHora)
        {
            if (oHora.ToString().Length == 6)
                return oHora.ToString().Substring(0, 2) + ":" + oHora.ToString().Substring(2, 2);
            else if (oHora.ToString().Length == 4)
                return "00:" + oHora.ToString().Substring(0, 2);
            else if (oHora.ToString().Length == 5)
                return "0" + oHora.ToString().Substring(0, 1) + ":" + oHora.ToString().Substring(1, 2);
            else
                return oHora.ToString().Substring(0, 1) + ":" + oHora.ToString().Substring(1, 2);
        }
    }
}
