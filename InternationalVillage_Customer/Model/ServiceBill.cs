using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalVillage_Customer.Model
{
    class ServiceBill : DetailBill
    {
        public ServiceBill(string n, string q, string p)
        {
            Name = n;
            Quantity = q;
            Price = p;
        }

        string name;
        string quantity;
        string price;

        public string Name { get => name; set => name = value; }
        public string Quantity { get => quantity; set => quantity = value; }
        public string Price { get => price; set => price = value; }
    }
}
