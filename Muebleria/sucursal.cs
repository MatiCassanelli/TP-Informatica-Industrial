//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Muebleria
{
    using System;
    using System.Collections.Generic;
    
    public partial class sucursal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sucursal()
        {
            this.almacen = new HashSet<almacen>();
            this.movimiento = new HashSet<movimiento>();
            this.movimiento1 = new HashSet<movimiento>();
        }
    
        public int idSucursal { get; set; }
        public int idDireccion { get; set; }
        public string Nombre { get; set; }
        public sbyte Real { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<almacen> almacen { get; set; }
        public virtual direccion direccion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<movimiento> movimiento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<movimiento> movimiento1 { get; set; }
    }
}
