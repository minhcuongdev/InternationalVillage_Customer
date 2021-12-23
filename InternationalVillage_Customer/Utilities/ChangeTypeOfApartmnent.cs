using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalVillage_Customer.Utilities
{
    class ChangeTypeOfApartmnent
    {
        public ChangeTypeOfApartmnent()
        {

        }

        public string ChangeType(string type)
        {
            switch (type)
            {
                case "Luxury (Type 3A)":
                    return "3A";
                case "High Standard (Type 3B)":
                    return "3B";
                case "Standard (Type 2A)":
                    return "2A";
                default:
                    return "";
            }
        }

        public string ChangeIdApartmentToType(string id)
        {
            if (id.Contains("2A"))
                return "Normal";
            if (id.Contains("3A"))
                return "Luxury";
            if (id.Contains("3B"))
                return "Standard";
            return "";
        }

        public int ChangeTypeToPrice(string type)
        {
            switch (type)
            {
                case "Normal":
                    return 70;
                case "Luxury":
                    return 110;
                case "Standard":
                    return 90;
                default:
                    return 0;
            }
        }

        public string ChangeTypeOfApartment(string type)
        {
            switch (type)
            {
                case "Normal":
                    return "2A";
                case "Luxury":
                    return "3A";
                case "Standard":
                    return "3B";
                default:
                    return "";
            }
        }
    }
}
