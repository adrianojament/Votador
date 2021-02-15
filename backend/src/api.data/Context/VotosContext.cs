using api.data.Mapping;
using api.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.data.Context
{
    public class VotosContext : DbContext
    {
        public DbSet<UsuarioEntity> Usuarios;
        public DbSet<RecursoEntity> Recursos;
        public DbSet<VotoEntity> Votos;

        public VotosContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureMapContext.ConfigureMap(modelBuilder);
        }
    }
}
