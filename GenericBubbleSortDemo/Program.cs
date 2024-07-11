using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBubbleSortDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            //int[] nums = new int[] { 6, 4, 2, 9, 7 };

            //string[] names = new string[] { "Zach", "James", "Bob", "Gary" };

            Employee[] employees = new Employee[]
            {
                new Employee { Id = 1, Name = "Zach"},
                new Employee { Id = 5, Name = "James"},
                new Employee { Id = 3, Name = "Bob"},
                new Employee { Id = 2, Name = "Gary"}
            };

            SortArray<Employee> sortArray = new SortArray<Employee>();

            sortArray.BubbleSort(employees);

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee} ");
            }


            Console.ReadLine();
        }
    }

    public class Employee : IComparable<Employee>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int CompareTo(Employee other)
        {
            return Id.CompareTo(other.Id);
        }

        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }


    public class SortArray<T> where T : IComparable<T>
    {
        public void BubbleSort(T[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                    {
                        T temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
    }
}
