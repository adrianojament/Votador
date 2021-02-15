using api.data.Context;
using api.data.Repositories;
using api.data.Repositories.Standard;
using api.domain.Interfaces.Repositories;
using api.domain.Interfaces.Repositories.Standard;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.crossCutting.DependencyInjection
{
    public class ConfigureRepositories
    {
        public static void ConfigureDependencies(IConfiguration configuration, IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUsuariosRepository, UsuariosRepository>();
            serviceCollection.AddScoped<IRecursosRepository, RecursosRepository>();
            serviceCollection.AddScoped<IVotosRepository, VotosRepository>();

            var stringConnection = ConfigurationExtensions.GetConnectionString(configuration, "Database");

            serviceCollection.AddDbContext<VotosContext>(options =>
               options.UseNpgsql(stringConnection)
               .UseSnakeCaseNamingConvention());
        }
    }
}
