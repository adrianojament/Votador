using api.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.data.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
        {
            builder.ToTable("usuarios");
            builder.UseXminAsConcurrencyToken();

            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.eMail).IsUnique();

            builder.Property(u => u.Nome).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Senha).IsRequired().HasMaxLength(100);
            builder.Property(u => u.eMail).IsRequired().HasMaxLength(100);
            
        }
    }
}
