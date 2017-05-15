using GerenciamentoDeAnuncio.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GerenciamentoDeAnuncio.Infra.Data.EntityConfig
{
    public class AnuncioConfiguration : EntityTypeConfiguration<Anuncio>
    {
        public AnuncioConfiguration()
        {
            HasKey(c => c.AnuncioID);

            Property(c => c.Texto).HasMaxLength(300);

            Property(c => c.Audio).HasMaxLength(200);

            Property(c => c.Video).HasMaxLength(200);

        }
    }
}
