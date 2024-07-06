using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class PhysicalProductModel : IProductModel
    {

        public string Title { get; set; }
        public bool HasBeenDelivered { get; set; }
        public void ShipItem(CustomerModel customer)
        {
            if (HasBeenDelivered == false)
            {
                Console.WriteLine($"Simulating shipping {Title} to {customer.FirstName} in {customer.City}");
                HasBeenDelivered = true;
            }
        }
        static void Main(string[] args)
        {
        }
    }

}
