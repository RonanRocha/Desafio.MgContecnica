using Desafio.MgContecnica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.MgContecnica.Infrastructure.Mapping
{
    public class TransacoesMapConfiguration : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.ToTable("Transacoes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired();
            builder.Property(x => x.Data).IsRequired();
            builder.Property(x => x.DataCriacao).IsRequired();
            builder.Property(x => x.DataUltimaAtualizacao).IsRequired();
            builder.Property(x => x.Valor).HasColumnType("decimal(18,2)").IsRequired();       
            builder.HasOne(x => x.Categoria).WithMany(x => x.Transacoes).HasForeignKey(x => x.CategoriaId);
        }
    }
}
