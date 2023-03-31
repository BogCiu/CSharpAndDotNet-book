using System.Linq;
using static System.Console;

namespace BeginningCSharpAndDotNET_16_5_OrderQueryResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Alonso", "Zheng", "Smith", "Jones", "Smythe",
                "Small", "Ruiz", "Hsieh", "Jorgenson", "Ilyich", "Singh",
                "Samba", "Fatimah" };
            var queryResults = from n in names
                               where n.StartsWith("S")
                               orderby n
                               select n;
            WriteLine("Names beginning with S ordered alphabetically:");
            foreach (var item in queryResults)
            {
                WriteLine(item);
            }
            Write("Program finished, press Enter/Return to continue:");
            ReadKey();
        }
    }
}