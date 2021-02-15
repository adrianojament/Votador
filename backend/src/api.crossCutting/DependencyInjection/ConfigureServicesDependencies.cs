using api.domain.Interfaces.Services;
using api.services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.crossCutting.DependencyInjection
{
    public class ConfigureServicesDependencies
    {
        public static void Configure(IServiceCollection servicesCollection)
        {
            servicesCollection.AddTransient<IUsuariosServices, UsuariosServices>();
            servicesCollection.AddTransient<IRecursosServices, RecursosServices>();
            servicesCollection.AddTransient<IVotosServices, VotosServices>();
        }
    }
}
