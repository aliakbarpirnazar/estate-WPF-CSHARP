using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Trust
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Discription { get; set; }
        public DateTime RegDate { get; set; }
        public bool DeleteStatus { get; set; }

        public Customer Customers { get; set; }
        
    }
}
