using api.data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace api.data.test
{
    public abstract class BaseTest
    {
        public BaseTest()
        {

        }
    }

    public class DbTeste : IDisposable
    {
        private string databaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        public ServiceProvider serviceProvider { get; private set; }

        public DbTeste()
        {
            var stringConnection = $"Host=localhost;Database={databaseName};Username=sageuser;Password=s4g3u53r;Port=5410";
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<VotosContext>(o =>
            {
                o.UseNpgsql(stringConnection)
                 .UseSnakeCaseNamingConvention();
            }, ServiceLifetime.Transient);

            serviceProvider = serviceCollection.BuildServiceProvider();
            using (var context = serviceProvider.GetService<VotosContext>())
            {
                context.Database.EnsureCreated();
            }
        }

        public void Dispose()
        {
            using (var context = serviceProvider.GetService<VotosContext>())
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}
