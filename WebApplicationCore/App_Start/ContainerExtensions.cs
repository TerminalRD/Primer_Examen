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
            // Aqui van la inyeccion de dependencias
            services.AddSingleton<IDataAccess, DataAccess>();//Primero la interfaz y luego la clase
            services.AddTransient<IJobsService, JobsService>();//Por cada servicio que se cree para una entidad, se debe de agregar aqui
            services.AddTransient<IDeparmentsService, DeparmentsService>();
            services.AddTransient<ITitlesService, TitlesService>();
            return services;
        }
    }
}
