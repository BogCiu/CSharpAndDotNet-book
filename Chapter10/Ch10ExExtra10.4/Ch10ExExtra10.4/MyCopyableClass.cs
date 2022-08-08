using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch10ExExtra10._4
{
    internal class MyCopyableClass
    {
        protected int myInt;
        public int MyInt { get { return myInt; } set { myInt = value; } }
        public MyCopyableClass GetCopy()
        {
            return (MyCopyableClass)this.MemberwiseClone();
        }
    }
}
