using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyAutomapper
{
    internal static class Map
    {
        private static Dictionary<string, (Dictionary<string, PropertyInfo> FromName, Dictionary<string, PropertyInfo> FromAttribute)> Instances = new();
        private static readonly object TrafficLight = new();
        private static (Dictionary<string, PropertyInfo> FromName, Dictionary<string, PropertyInfo> FromAttribute) GetValues(Type entityType)
        {
            if (!Instances.ContainsKey(entityType.FullName))
            {
                lock (TrafficLight)
                {
                    if (!Instances.ContainsKey(entityType.FullName))
                    {
                        Dictionary<string, PropertyInfo> mappingProperties = entityType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .ToDictionary(p => p.Name, p => p);
                        Dictionary<string, PropertyInfo> attributeMappingProperties = entityType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                            .Where(p => p.GetCustomAttribute<MappingAttribute>() != default)
                            .ToDictionary(p => p.GetCustomAttribute<MappingAttribute>().Name, p => p);
                        Instances.Add(entityType.FullName, (mappingProperties, attributeMappingProperties));
                    }
                }
            }
            return Instances[entityType.FullName];
        }
        private static Dictionary<string, IEnumerable<PropertyInfo>> Properties = new();
        private static readonly object Semaphore = new();
        private static IEnumerable<PropertyInfo> GetProperties(Type toMapType)
        {
            if (!Properties.ContainsKey(toMapType.FullName))
            {
                lock (Semaphore)
                    if (!Properties.ContainsKey(toMapType.FullName))
                        Properties.Add(toMapType.FullName, toMapType.GetProperties(BindingFlags.Public | BindingFlags.Instance));
            }
            return Properties[toMapType.FullName];
        }
        public static TMap To<T, TMap>(this T toMap)
            where TMap : class, new()
        {
            Type toMapType = toMap.GetType();
            Type entityType = typeof(TMap);
            var map = GetValues(entityType);
            var entity = new TMap();
            foreach (var property in GetProperties(toMapType))
            {
                var name = property.Name;
                if (map.FromName.ContainsKey(name))
                {
                    map.FromName[name].SetValue(entity, property.GetValue(toMap));
                }
                else if (map.FromAttribute.ContainsKey(name))
                {
                    map.FromAttribute[name].SetValue(entity, property.GetValue(toMap));
                }
            }
            return entity;
        }
    }
}