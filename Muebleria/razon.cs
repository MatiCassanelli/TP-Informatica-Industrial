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
    
    public partial class razon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public razon()
        {
            this.users1 = new HashSet<users>();
        }
    
        public int idRazon { get; set; }
        public int idDescripcion { get; set; }
        public int idProducto { get; set; }
        public System.DateTime last_upd { get; set; }
        public int user_upd { get; set; }
        public Nullable<int> S_origen { get; set; }
        public Nullable<int> A_origen { get; set; }
        public Nullable<int> U_origen { get; set; }
        public Nullable<int> S_destino { get; set; }
        public Nullable<int> A_destino { get; set; }
        public Nullable<int> U_destino { get; set; }
    
        public virtual producto producto { get; set; }
        public virtual users users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<users> users1 { get; set; }
    }
}
