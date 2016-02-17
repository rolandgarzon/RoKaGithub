using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace RoKa.Models
{
    public class ContextRoKa:DbContext
    {
        public ContextRoKa():base("name=ConexDBRoKa")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<rk_pais> rk_pais { get; set; }
        public DbSet<rk_departamento> rk_departamento { get; set; }
        public DbSet<rk_municipio> rk_municipio { get; set; }
        public DbSet<rk_servicio> rk_servicio { get; set; }
        public DbSet<rk_formulario> rk_formulario { get; set; }
        public DbSet<rk_usuario> rk_usuario { get; set; }
        public DbSet<rk_usuarioformulario> rk_usuarioformulario { get; set; }
        public DbSet<rk_causalectura> rk_causalectura { get; set; }
        public DbSet<rk_ciclofacturacion> rk_ciclofacturacion { get; set; }
        public DbSet<rk_critica> rk_critica { get; set; }
        public DbSet<rk_estadolectura> rk_estadolectura { get; set; }
        public DbSet<rk_grupolectura> rk_grupolectura { get; set; }
        public DbSet<rk_lectura> rk_lectura { get; set; }
        public DbSet<rk_observacioneslectura> rk_observacioneslectura { get; set; }
        public DbSet<rk_reglasdecritica> rk_reglasdecritica { get; set; }
        public DbSet<rk_tecnico> rk_tecnico { get; set; }
        public DbSet<rk_terminalportatil> rk_terminalportatil { get; set; }
        public DbSet<rk_tipocobroobervacion> rk_tipocobroobervacion { get; set; }
        public DbSet<rk_tipoobervacionlectura> rk_tipoobervacionlectura { get; set; }



    }
}