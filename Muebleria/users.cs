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
    
    public partial class users
    {
        public users()
        {
            this.padre_componente = new HashSet<padre_componente>();
        }
    
        public int idUsers { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sector { get; set; }
        public int idRole { get; set; }
        public string Interno { get; set; }
        public string Mail { get; set; }
        public int idLanguage { get; set; }
        public string Password { get; set; }
    
        public virtual language language { get; set; }
        public virtual ICollection<padre_componente> padre_componente { get; set; }
        public virtual role role { get; set; }
    }
}
