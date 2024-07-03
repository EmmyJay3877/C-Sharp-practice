using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumberDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Random random = new Random();

            //for (int i = 0; i < 10; i++)
            //{
            //    //Console.WriteLine(random.Next(5, 11));
            //    SimpleMethod(random);
            //}

            List<PersonModel> people = new List<PersonModel>
            {
                new PersonModel{FirstName = "John"},
                new PersonModel{FirstName = "Sam"},
                new PersonModel{FirstName = "Collins"},
                new PersonModel{FirstName = "Jane"},
                new PersonModel{FirstName = "Dimy"},
                new PersonModel{FirstName = "Kute"},
                new PersonModel{FirstName = "Greg"}
            };

            var sortedPeople = people.OrderBy(x => random.Next());


            foreach (var p in sortedPeople)
            {
                Console.WriteLine(p.FirstName);
            }

            Console.ReadLine();
        }

        static void SimpleMethod(Random random)
        {
            Console.WriteLine(random.Next());
        }
    }

    public class PersonModel
    {
        public string FirstName { get; set; }

    }
}
