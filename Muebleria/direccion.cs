//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Muebleria
{
    using System;
    using System.Collections.Generic;
    
    public partial class direccion
    {
        public direccion()
        {
            this.externo = new HashSet<externo>();
            this.externo1 = new HashSet<externo>();
            this.externo2 = new HashSet<externo>();
        }
    
        public int idDireccion { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string Barrio { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public int CodigoPostal { get; set; }
        public string Direccioncol { get; set; }
    
        public virtual ICollection<externo> externo { get; set; }
        public virtual ICollection<externo> externo1 { get; set; }
        public virtual ICollection<externo> externo2 { get; set; }
    }
}
