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
    
    public partial class tipo_externo
    {
        public tipo_externo()
        {
            this.externo = new HashSet<externo>();
        }
    
        public int idTipo_Externo { get; set; }
        public int idDescriptionTE { get; set; }
    
        public virtual ICollection<externo> externo { get; set; }
    }
}