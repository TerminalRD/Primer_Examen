using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB;
using WBL;

namespace WebApplicationCore
{
    public static class ContainerExtensions
    {

        public static IServiceCollection AddDIContainer(this IServiceCollection services)
        {

            services.AddSingleton<IDataAccess, DataAccess>();
            services.AddTransient<IJobsService, JobsService>();//POr cada servicio que se cree para una entidad, se debe de agregar aqui
            return services;
        }
    }
}
