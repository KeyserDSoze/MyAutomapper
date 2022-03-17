using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAutomapper
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMapperManager(this IServiceCollection services)
        {
            services.AddSingleton<MapManager>();
            return services;
        }
    }
}
