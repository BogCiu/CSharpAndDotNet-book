using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch10ExExtra10._1
{
    internal class MyClass
    {
        protected string myString;
        public string ConainedString
        {
            set { myString = value; }
        }
        public virtual string GetString() => myString;
    }
}
