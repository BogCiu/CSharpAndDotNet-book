using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch10ExExtra10._1
{
    internal class MyDerivedClass: MyClass
    {
        public override string GetString() => base.GetString() + "(output from derived calss)";
    }
}
