using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MyAutomapper
{
    internal record IdentityCard
    {
        public string Id { get; set; }
        [Mapping("Name")]
        public string NameAndSurname { get; set; }
        public bool IsMale { get; set; }
        [Mapping("Position")]
        public Vector3 PositionValue { get; set; }
    }
}
