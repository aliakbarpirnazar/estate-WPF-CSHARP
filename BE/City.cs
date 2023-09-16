using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class City
    {
        public int id { get; set; }
        public string Name { get; set; }
        public State States { get; set; }
        public List<Street> Streets { get; set; } = new List<Street>();
    }
}
