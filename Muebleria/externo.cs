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
    
    public partial class externo
    {
        public int idExterno { get; set; }
        public int idTipo_Externo { get; set; }
        public int Description_id { get; set; }
        public string CUIT { get; set; }
        public int Direcion_id { get; set; }
        public int Direcion_ent_id { get; set; }
        public int Direcion_fac_id { get; set; }
        public string Nac_Ext { get; set; }
    
        public virtual direccion direccion { get; set; }
        public virtual direccion direccion1 { get; set; }
        public virtual direccion direccion2 { get; set; }
        public virtual tipo_externo tipo_externo { get; set; }
    }
}
