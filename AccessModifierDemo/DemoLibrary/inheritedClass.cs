using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    internal class InheritedClass : AccessDemo
    {
        public void checkProtectedDemo()
        {
            ProtectedDemo();
            PrivateProtectedDemo();
            InternalDemo();
            ProtectedInternalDemo();
        }
    }
}
