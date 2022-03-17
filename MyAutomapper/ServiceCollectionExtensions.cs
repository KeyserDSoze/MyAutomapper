using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
        public static IServiceCollection AddMapping<T, TEntity>(this IServiceCollection services, Action<MapManagerOptions<T, TEntity>> options)
            where TEntity : class, new()
        {
            var value = new MapManagerOptions<T, TEntity>();
            options.Invoke(value);
            services.AddSingleton(value);
            services.AddSingleton<MapManager<T, TEntity>>();
            return services;
        }
    }
    public class MapManagerOptions<T, TEntity>
        where TEntity : class, new()
    {
        public Dictionary<string, Func<dynamic, dynamic>> Actions = new();
        public void AddAction<T, T1>(string propertyName, Func<T, T1> action)
        {
            Actions.Add(propertyName, x => action(x));
        }
    }
}
