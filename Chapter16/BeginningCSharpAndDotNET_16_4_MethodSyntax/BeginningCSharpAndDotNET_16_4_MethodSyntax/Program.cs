using System.Linq;
using static System.Console;

namespace BeginningCSharpAndDotNET_16_4_MethodSyntax
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Alonso", "Zheng", "Smith", "Jones", "Smythe",
                "Small", "Ruiz", "Hsieh", "Jorgenson", "Ilyich", "Singh",
                "Samba", "Fatimah" };
            var queryResults = names
                // Modifications for Ex 16.5    
                // Comment/uncomment next line
                //.Where(n => n.StartsWith("S"))
                ;
                // Modifications end
            WriteLine("Names beginning with S:");
            foreach (var item in queryResults)
            {
                WriteLine(item);
            }
            Write("Program finished, press Enter/Return to continue:");
            ReadKey();
        }
    }
}