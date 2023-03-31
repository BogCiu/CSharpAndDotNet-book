using System.ComponentModel.DataAnnotations;
using System.Linq;
using static System.Console;

namespace BeginningCSharpAndDotNET_16_3_QuerySyntax
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
                               // Exercise 16.1 Start
                               orderby n descending
                               // Exercise 16.1 End
                               select n;
            WriteLine("Names beginning with S:");
            foreach (var item in queryResults)
            {
                WriteLine(item);
            }
            // Exercise 16.6 Start
            WriteLine($"Query Result Max = {queryResults.Max()}");
            WriteLine($"Query Result Max = {queryResults.Min()}");
            WriteLine($"Query Result Count = {queryResults.Count()}");
            //WriteLine($"Query Result Average does not work = {queryResults.Average()}");
            //WriteLine($"Query Result Sum does not work = {queryResults.Sum()}");
            // Exercise 16.6 End
            Write("Program finished, press Enter/Return to continue:");
            ReadKey();
        }
    }
}
