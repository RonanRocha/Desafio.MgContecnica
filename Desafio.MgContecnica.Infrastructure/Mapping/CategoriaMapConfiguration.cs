using Desafio.MgContecnica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.MgContecnica.Infrastructure.Mapping
{
    public class CategoriaMapConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categorias");
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Tipo).IsRequired();
            builder.Property(x => x.Status).IsRequired();

        }
    }
}
