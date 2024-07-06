using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLibrary;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IProductModel> cart = AddSampleData();

            CustomerModel customer = GetCustomer();

            foreach (IProductModel prod in cart)
            {
                prod.ShipItem(customer);

                if (prod is IDigitalProductModel digital)
                {
                    Console.WriteLine($"For the {digital.Title}, you have {digital.TotalDownloadsLeft} downloads left");
                }
            }

            Console.ReadLine();
        }

        private static CustomerModel GetCustomer()
        {
            return new CustomerModel
            {
                FirstName = "Sam",
                LastName = "John",
                EmailAddress = "John@gmail.com",
                City = "LA",
                PhoneNumber = "1234567890",
            };
        }

        private static List<IProductModel> AddSampleData()
        {
            List<IProductModel> output = new List<IProductModel>();

            output.Add(new PhysicalProductModel { Title = "Football"});
            output.Add(new PhysicalProductModel { Title = "T-shirt"});
            output.Add(new PhysicalProductModel { Title = "Hard Drive"});
            output.Add(new DigitalProductModel { Title = "C# course" });

            return output;
        }
    }
}
