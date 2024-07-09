using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public abstract class DataAccess
    {

        public virtual string LoadConnectionString(string name)
        {
            Console.WriteLine("Load connection string!");
            return "TestConnection";
        }

        public abstract void LoadData(string name);
        public abstract void SaveData(string name);



        static void Main(string[] args)
        {
        }
    }
}
