using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SitioTaxis_API.Models
{
    public partial class ModeloSitioTaxi : DbContext
    {
        public ModeloSitioTaxi()
            : base("name=ModeloSitioTaxi")
        {
        }

        public virtual DbSet<Administrador> Administradores { get; set; }
        public virtual DbSet<Sitio> Sitios { get; set; }
        public virtual DbSet<AdministradorSitio> AdministradorSitios { get; set; }
        public virtual DbSet<Checador> Checadores { get; set; }
        public virtual DbSet<Taxi> Taxis { get; set; }
        public virtual DbSet<Chofer> Choferes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdministradorSitio>()
                .HasRequired(t => t.Sitio)
                .WithMany(s => s.AdministradorSitios)
                .HasForeignKey(t => t.SitioID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Checador>()
                .HasRequired(t => t.Sitio)
                .WithMany(s => s.Checadores)
                .HasForeignKey(t => t.SitioID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Taxi>()
                .HasRequired(t => t.Sitio)
                .WithMany(s => s.Taxis)
                .HasForeignKey(t => t.SitioID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Chofer>()
                .HasRequired(t => t.Sitio)
                .WithMany(s => s.Choferes)
                .HasForeignKey(t => t.SitioID)
                .WillCascadeOnDelete(false);
        }
        
    }
}
