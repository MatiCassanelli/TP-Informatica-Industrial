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
    
    public partial class traduccion
    {
        public int idDescriptionT { get; set; }
        public int idLanguageT { get; set; }
        public string Traduccion_str { get; set; }
    
        public virtual language language { get; set; }
    }
}
