using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class SqliteDataAccess : DataAccess
    {
        public override string LoadConnectionString(string name)
        {
            string output = base.LoadConnectionString(name);

            output += " (from SQLite)";

            return output;
        }

        public override void LoadData(string name)
        {
            Console.WriteLine("Loadind SQLite Data");
        }

        public override void SaveData(string name)
        {
            Console.WriteLine("Saving Data to SQLite");
        }
    }
}
