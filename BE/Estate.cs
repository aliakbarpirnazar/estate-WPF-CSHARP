using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Estate
    {
        public int id { get; set; }
        public bool Sale { get; set; } 
        public bool Rental { get; set; }
        public string PropertyType { get; set; }
        public bool Presell { get; set; }
        public bool Construction { get; set; }
        public bool Exchange { get; set; }
        public string TypeExchange { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Address { get; set; }
        public double PriceAmount { get; set; }
        public double PriceRent { get; set; }
        public double PriceSale { get; set; }
        public int Amber { get; set; }
        public bool KeyNot { get; set; }
        public string KUsers { get; set; }
        public string Geography { get; set; }
        public int Area { get; set; }
        public int BarMelk { get; set; }
        public int Foundation { get; set; }
        public int NRooms { get; set; }
        public string NFloor { get; set; }
        public string Floor { get; set; }
        public string NUnitFloor { get; set; }
        public string TypeDoucument { get; set; }
        public bool ProductionLicense { get; set; }
        public bool Parking { get; set; }
        public bool WareHouse { get; set; }
        public bool Elevator { get; set; }
        public bool Pilot { get; set; }
        public string Discription { get; set; }
        public DateTime RegDate { get; set; }
        public Customer Customers { get; set; }


    }
}
