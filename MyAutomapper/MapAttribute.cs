using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAutomapper
{
    internal class MappingAttribute : Attribute
    {
        public string Name;
        public MappingAttribute(string name)
        {
            Name = name;
        }
    }
}
