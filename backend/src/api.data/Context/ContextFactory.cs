using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace api.data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<VotosContext>
    {
        public VotosContext CreateDbContext(string[] args)
        {
            var basePath = AppContext.BaseDirectory;
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("jsconfig.json")
                .AddEnvironmentVariables();

            var config = builder.Build();

            var stringConnection = config.GetConnectionString("Database");

            var options = new DbContextOptionsBuilder<VotosContext>()
               .UseNpgsql(stringConnection)
               .UseSnakeCaseNamingConvention()
               .Options;

            return new VotosContext(options);
        }
    }
}
