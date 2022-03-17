using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyAutomapper
{
    internal class MapManager
    {
        public TMap To<T, TMap>(T toMap)
            where TMap : class, new()
            => toMap.To<T, TMap>();
    }
    internal class MapManager<T, TMap>
            where TMap : class, new()
    {
        private readonly MapManagerOptions<T, TMap> Options;
        public MapManager(MapManagerOptions<T, TMap> options)
        {
            Options = options;
        }
        public TMap To(T toMap)
            => toMap.To(Options);
    }
}
