﻿using System;

namespace Ch11Ex04
{
    class Checker
    {
        public void Check(object param1)
        {
            if (param1 is ClassA)
                Console.WriteLine("Variable can be converted to ClassA.");
            else
                Console.WriteLine("Variable can't be converted to ClassA.");
            if (param1 is IMyInterface)
                Console.WriteLine("Variable can be converted to IMyInterface.");
            else
                Console.WriteLine("Variable can't be converted to IMyInterface.");
            if (param1 is MyStruct)
                Console.WriteLine("Variable can be converted to MyStruct.");
            else
                Console.WriteLine("Variable can't be converted to MyStruct.");

        }
    }
    interface IMyInterface { }
    class ClassA : IMyInterface { }
    class ClassB : IMyInterface { }
    class ClassC { }
    class ClassD : ClassA { }
    struct MyStruct : IMyInterface { }
    internal class Program
    {
        static void Main(string[] args)
        {
            Checker check = new Checker();
            ClassA try1 = new ClassA();
            ClassB try2 = new ClassB();
            ClassC try3 = new ClassC();
            ClassD try4 = new ClassD();
            MyStruct try5 = new MyStruct();
            object try6 = try5;
            Console.WriteLine("Anaylizing ClassA type variable:");
            check.Check(try1);
            Console.WriteLine("\nAnaylizing ClassB type variable:");
            check.Check(try2);
            Console.WriteLine("\nAnaylizing ClassC type variable:");
            check.Check(try3);
            Console.WriteLine("\nAnaylizing ClassD type variable:");
            check.Check(try4);
            Console.WriteLine("\nAnaylizing MyStruct type variable:");
            check.Check(try5);
            Console.WriteLine("\nAnaylizing boxed MyStruct type variable:");
            check.Check(try6);
            Console.ReadKey();
        }
    }
}
