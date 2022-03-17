using System;
using System.Collections.Generic;
using System.Linq;
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
}
