using System;

namespace Ch06ExExtra6._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Two arguments required.");
                return;
            }
            string stringVal = args[0];
            int intVal = Convert.ToInt32(args[1]);

            Console.WriteLine($"String parameter: {stringVal}");
            Console.WriteLine($"Integer parameter: {intVal}");
        }
    }
}
