using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Ga2.Entity
{
    public class BECalculos
    {

        public double valorE1 { get; set; }
        public double valorE2 { get; set; }
        public double valorE3 { get; set; }
        public double valorE4 { get; set; }
        public double valorE5 { get; set; }
        public double HoraActualizacion { get; set; }
        public string TipoDiseno { get; set; }
        public double valorCBR { get; set; }


        public double valorConfiabR { get; set; }
        public double ServIniPI { get; set; }
        public double ServFinPT { get; set; }
        public double CantESAL { get; set; }
        public double ErrorCombiEstandar { get; set; }
        public double DesviEstandar { get; set; }
        public double SNReq { get; set; }
        public double N18Calc2 { get; set; }
        public double valorMR { get; set; }
        public double N18Nom { get; set; }
        public double BaseGranular { get; set; }

        public double DifServiciabilidad { get; set; }

        public string TipoVehiculo { get; set; }
        public double PesoE1 { get; set; }
        public double PesoE2 { get; set; }
        public double PesoE3 { get; set; }

        public double PesoE4 { get; set; }
        public double PesoE5 { get; set; }
        public int Id_TipoVehiculo { get; set; }
        public int Id_Vehiculo { get; set; }

        public double valorCBRBase { get; set; }
        public double valorCBRSubBase { get; set; }

    }
}
