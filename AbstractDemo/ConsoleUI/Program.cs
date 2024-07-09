using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<DataAccess> databases = new List<DataAccess>()
            {
                new SqlDataAccess(),
                new SqliteDataAccess(),
            };

            foreach (var db in databases)
            {
                Console.WriteLine(db.LoadConnectionString("demo")); ;
                db.LoadData("select * from table");
                db.SaveData("Insert into table");
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
