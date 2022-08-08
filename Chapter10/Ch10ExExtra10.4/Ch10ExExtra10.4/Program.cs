using System;

namespace Ch10ExExtra10._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyCopyableClass testObj1 = new MyCopyableClass();
            var testObj2 = testObj1.GetCopy();

            testObj1.MyInt = 5;
            testObj2.MyInt = 10;
            Console.WriteLine(testObj1.MyInt);
            Console.WriteLine(testObj2.MyInt);
        }
    }
}
