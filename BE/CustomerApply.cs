using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class CustomerApply
    {
        public int id { get; set; }
        public string TypeApply { get; set; }
        public string PropertyType { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public bool Presell { get; set; }
        public bool Construction { get; set; }
        public bool Exchange { get; set; }
        public int PriceAmount { get; set; }
        public int PriceRent { get; set; }
        public int PriceSale { get; set; }
        public int Amber { get; set; }
        public int Area { get; set; }
        public string TypeDoucument { get; set; }
        public int NFloor { get; set; }
        public string KUsers { get; set; }
        public bool Parking { get; set; }
        public bool WareHouse { get; set; }
        public bool Elevator { get; set; }
        public bool Pilot { get; set; }
        public CustomerApply CustomerApplies { get; set; }

    }
}
