using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class TrustGroup
    {
        public int id { get; set; }
        public string NameTrust { get; set; }
        public bool DeleteStatus { get; set; }
        public DateTime RegDate { get; set; }
    }
}
