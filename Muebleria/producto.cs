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
    
    public partial class producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public producto()
        {
            this.articulo = new HashSet<articulo>();
            this.movimiento = new HashSet<movimiento>();
            this.padre_componente_publicado = new HashSet<padre_componente_publicado>();
            this.padre_componente_publicado1 = new HashSet<padre_componente_publicado>();
            this.padre_componente_temporal = new HashSet<padre_componente_temporal>();
            this.padre_componente_temporal1 = new HashSet<padre_componente_temporal>();
            this.producto_sustituto = new HashSet<producto_sustituto>();
            this.producto_sustituto1 = new HashSet<producto_sustituto>();
            this.remito_detalle = new HashSet<remito_detalle>();
            this.producto_sustituto2 = new HashSet<producto_sustituto>();
        }
    
        public int idProducto { get; set; }
        public int idDescriptionP { get; set; }
        public int idTipo { get; set; }
        public int Unidad_id_Purchase { get; set; }
        public int Unidad_id_Aplication { get; set; }
        public Nullable<System.DateTime> Start_Date { get; set; }
        public Nullable<System.DateTime> End_Date { get; set; }
        public Nullable<System.DateTime> Last_Upd { get; set; }
        public Nullable<int> User_Upd { get; set; }
        public Nullable<int> Codigo_abreviado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<articulo> articulo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<movimiento> movimiento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<padre_componente_publicado> padre_componente_publicado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<padre_componente_publicado> padre_componente_publicado1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<padre_componente_temporal> padre_componente_temporal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<padre_componente_temporal> padre_componente_temporal1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<producto_sustituto> producto_sustituto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<producto_sustituto> producto_sustituto1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<remito_detalle> remito_detalle { get; set; }
        public virtual stock stock { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<producto_sustituto> producto_sustituto2 { get; set; }
        public virtual tipo_producto tipo_producto { get; set; }
        public virtual unidad_medida unidad_medida { get; set; }
        public virtual unidad_medida unidad_medida1 { get; set; }
    }
}
