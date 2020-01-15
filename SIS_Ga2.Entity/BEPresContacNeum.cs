using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Ga2.Entity
{
    public class BEPresContacNeum
    {
        public int Id_Presion_Cto_Neum { get; set; }
        public int Id_Espesor { get; set; }
        public string Espesor { get; set; }
        public int Id_Presion { get; set; }
        public string Presion { get; set; }
        public decimal valorFP { get; set; }
        public int Estado { get; set; }

    }
}
