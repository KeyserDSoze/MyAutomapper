using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MyAutomapper
{
    internal record TableIdentityCard
    {
        public string Id { get; set; }
        [Mapping("NameAndSurname")]
        public string Name { get; set; }
        public bool IsMale { get; set; }
        [Mapping("PositionValue")]
        public string Position { get; set; }
    }
}
