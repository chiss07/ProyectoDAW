﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DesarrolloBE
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_SISTEMAS_DAWEntities : DbContext
    {
        public DB_SISTEMAS_DAWEntities()
            : base("name=DB_SISTEMAS_DAWEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Local> Local { get; set; }
        public virtual DbSet<Puesto_trabajo> Puesto_trabajo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
    }
}