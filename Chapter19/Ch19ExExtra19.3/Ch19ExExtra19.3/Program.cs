using System.Net;
using System.IO;
using Newtonsoft.Json;
using static System.Console;

namespace Ch19ExExtra19._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> cards = new List<string>();
            var playerName = "Benjamin";
            string GetURL =
                "http://handofcards.azurewebsites.net/api/HandOfCards/" + playerName; // Wtf is this supposed to be?
            WebClient client = new WebClient();
            Stream dataStream = client.OpenRead(GetURL);
            StreamReader reader = new StreamReader(dataStream);
            var results = JsonConvert.DeserializeObject<dynamic>(reader.ReadLine());
            reader.Close();
            foreach (var item in results)
            {
                WriteLine((string)item.imagelink);
            }
            ReadLine();
        }
    }
}
