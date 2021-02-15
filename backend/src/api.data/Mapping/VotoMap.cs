using api.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.data.Mapping
{
    public class VotoMap : IEntityTypeConfiguration<VotoEntity>
    {
        public void Configure(EntityTypeBuilder<VotoEntity> builder)
        {
            builder.ToTable("votos");
            builder.UseXminAsConcurrencyToken();

            builder.HasKey(u => u.Id);
            
            builder.HasOne(u => u.Usuario).WithMany(m => m.Votos);
            builder.HasOne(u => u.Recurso).WithMany(m => m.Votos);
        }
    }
}
