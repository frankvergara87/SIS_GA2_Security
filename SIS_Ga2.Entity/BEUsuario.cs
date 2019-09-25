using System;
using System.Collections.Generic;

namespace SIS_Ga2.Entity
{
    public class BEUsuario
    {
      /*  public int idUsuario { get; set; }
        public string cuenta { get; set; }
        public string clave { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string Celular { get; set; }
        public string Cargo { get; set; }
        public string Correo { get; set; }
        public bool Estado { get; set; }
        public int Aplicacion {get;set;}*/


        public int Id_Usuario { get; set; }
        public string Dni { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Cip { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public int Estado { get; set; }
        public int Id_Jerarquia { get; set; }
        public string Id_Cargo { get; set; }
        public double Fecha_Creacion { get; set; }
        public double Hora_Creacion { get; set; }
        public string Usr_Creacion { get; set; }
        public double Fecha_Actualizacion { get; set; }
        public double Hora_Actualizacion { get; set; }
        public string Usr_Actualizacion { get; set; }
        public string Cargo { get; set; }
        public int Aplicacion { get; set; }




        //public DateTime FechaRegistro { get; set; }
        //public List<Sociedades_Logistica> ListaSociedades { get; set; }
        //public Sociedades_Logistica BESociedades_Logistica { get; set; }
        //public string LangName { get; set; }
        //public string codigosociedad { get; set; } 
        //public string Descripcionsociedad { get; set; }
        //public Usuario()
        //{
        //    BookViewModel = new List<BookViewModel>();
        //}
        //public int Id
        //{
        //    get;
        //    set;
        //}
        //public string Name
        //{
        //    get;
        //    set;
        //}
        //public bool IsAuthor
        //{
        //    get;
        //    set;
        //}
        //public IList<BookViewModel> BookViewModel
        //{
        //    get;
        //    set;
        //}
    }
}
