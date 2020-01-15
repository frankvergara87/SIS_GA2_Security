using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Ga2.Entity
{
    public class BEPorcEstructPavimento
    {

        public int Id_Porc_Estruc_Pavimento { get; set; }
        public string CalidadDrenaje { get; set; }
        public decimal Desde_0 { get; set; }
        public decimal Hasta_1 { get; set; }
        public decimal Desde_1 { get; set; }
        public decimal Hasta_5 { get; set; }
        public decimal Desde_5 { get; set; }
        public decimal Hasta_25 { get; set; }
        public decimal Desde_25 { get; set; }
        public decimal Hasta_Mas { get; set; }
    }
}
