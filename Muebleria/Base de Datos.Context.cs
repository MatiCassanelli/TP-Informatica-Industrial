﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class informatica_industrial_dbEntities : DbContext
    {
        public informatica_industrial_dbEntities()
            : base("name=informatica_industrial_dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<conversion> conversion { get; set; }
        public virtual DbSet<direccion> direccion { get; set; }
        public virtual DbSet<externo> externo { get; set; }
        public virtual DbSet<language> language { get; set; }
        public virtual DbSet<producto> producto { get; set; }
        public virtual DbSet<role> role { get; set; }
        public virtual DbSet<tipo_externo> tipo_externo { get; set; }
        public virtual DbSet<tipo_producto> tipo_producto { get; set; }
        public virtual DbSet<traduccion> traduccion { get; set; }
        public virtual DbSet<unidad_medida> unidad_medida { get; set; }
        public virtual DbSet<users> users { get; set; }
        public virtual DbSet<padre_componente_temporal> padre_componente_temporal { get; set; }
        public virtual DbSet<producto_sustituto> producto_sustituto { get; set; }
        public virtual DbSet<articulo> articulo { get; set; }
        public virtual DbSet<movimiento> movimiento { get; set; }
        public virtual DbSet<razon> razon { get; set; }
        public virtual DbSet<stock> stock { get; set; }
        public virtual DbSet<padre_componente_publicado> padre_componente_publicado { get; set; }
        public virtual DbSet<remito> remito { get; set; }
        public virtual DbSet<remito_detalle> remito_detalle { get; set; }
    }
}
