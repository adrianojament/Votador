using api.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.data.Mapping
{
    public class RecursoMap : IEntityTypeConfiguration<RecursoEntity>
    {
        public void Configure(EntityTypeBuilder<RecursoEntity> builder)
        {
            builder.ToTable("recursos");
            builder.UseXminAsConcurrencyToken();
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Tarefa).IsRequired().HasMaxLength(100);
        }
    }
}
