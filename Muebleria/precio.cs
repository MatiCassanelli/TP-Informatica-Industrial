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
    
    public partial class precio
    {
        public int idProducto { get; set; }
        public float Precio1 { get; set; }
        public System.DateTime fecha_aplicacion { get; set; }
        public System.DateTime last_upd { get; set; }
        public int user_upd { get; set; }
    
        public virtual producto producto { get; set; }
        public virtual users users { get; set; }
    }
}