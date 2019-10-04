using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Ga2.Business
{
    public static class HelpClass
    {
        public static DateTime CNumero_a_Fecha(double oFecha)
        {
            DateTime objDate;
                if (oFecha > 0)
                 {
                int y;
            int m;
            int d;
            y = int.Parse(oFecha.ToString().Substring(0, 4));         
            m = int.Parse(oFecha.ToString().Substring(0, 6).Substring(4, 2));
            d = int.Parse(oFecha.ToString().Substring(oFecha.ToString().Length - 2, 2));

                objDate = new DateTime(y, m, d);
            }
            else
            {
                objDate = new DateTime();
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
