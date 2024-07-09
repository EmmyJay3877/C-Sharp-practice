using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class SqlDataAccess : DataAccess
    {
        public override string LoadConnectionString(string name)
        {
            string output = base.LoadConnectionString(name);

            output += " (from SQL)";

            return output;
        }

        public override void LoadData(string name)
        {
            Console.WriteLine("Loading SQL data.");
        }

        public override void SaveData(string name)
        {
            Console.WriteLine("Saving Data to SQL");
        }
    }
}
