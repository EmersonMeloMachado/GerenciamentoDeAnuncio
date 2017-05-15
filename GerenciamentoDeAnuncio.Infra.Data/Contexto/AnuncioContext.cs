using GerenciamentoDeAnuncio.Domain.Entities;
using GerenciamentoDeAnuncio.Infra.Data.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace GerenciamentoDeAnuncio.Infra.Data.Contexto
{
    public class AnuncioContext : DbContext
    {
        public AnuncioContext() : base("GerenciamentoDeAnuncio")
        {

        }

        public DbSet<Anuncio> Anuncios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "Id").Configure(P => P.IsKey());

            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(300));

            modelBuilder.Configurations.Add(new AnuncioConfiguration());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if(entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                    entry.Property("DataAlteracao").IsModified = false;
                }

                if(entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                    entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }

}
