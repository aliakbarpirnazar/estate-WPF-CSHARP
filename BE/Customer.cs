using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Customer
    {
        public Customer()
        {
            DeleteStatus = false;
        }
        public int id { get; set; }
        public string NameFamily { get; set; }
        public string Phone { get; set; }
        public bool DeleteStatus { get; set; }
        public List<Estate> Estates { get; set; } = new List<Estate>();
        public List<CustomerApply> CustomerApplies { get; set; } = new List<CustomerApply>();
        public List<Trust> trusts { get; set; } = new List<Trust>();
        public DateTime RegDate { get; set; }
    }
}
