//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Muebleria
{
    using System;
    using System.Collections.Generic;
    
    public partial class tipo_producto
    {
        public tipo_producto()
        {
            this.producto = new HashSet<producto>();
        }
    
        public int idTipo_Producto { get; set; }
        public int idDescriptionTP { get; set; }
    
        public virtual ICollection<producto> producto { get; set; }
    }
}
