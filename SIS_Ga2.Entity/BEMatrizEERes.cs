using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Ga2.Entity
{
    public class BEMatrizEERes
    {
        public int NroAnio { get; set; }
        public int Id_Vehiculos_IMD { get; set; }
        public int Id_Vehiculos { get; set; }
        public int Id_Tipo_Vehiculo { get; set; }
        public string Vehiculos { get; set; }
        public decimal Valor_FVP { get; set; }
        public decimal IMD_Base { get; set; }
        public int ValorEExVehi { get; set; }

        public decimal valorEEMatriz { get; set; }


    }
}
