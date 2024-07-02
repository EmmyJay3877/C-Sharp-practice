using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    internal class InheritedDemo : AccessDemo
    {

        public void Demo()
        {
            ProtectedDemo();
            ProtectedInternalDemo();
        }
    }
}
