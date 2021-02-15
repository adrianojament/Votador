using api.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.data.Mapping
{
    public class ConfigureMapContext
    {
        public static void ConfigureMap(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioEntity>(new UsuarioMap().Configure);
            modelBuilder.Entity<RecursoEntity>(new RecursoMap().Configure);
            modelBuilder.Entity<VotoEntity>(new VotoMap().Configure);
        }
    }
}
