using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch13ExExtra13._6
{
    internal static class Extension
    {
        public static string ToAcronym(this string inputString)
        {
            inputString = inputString.Trim();
            if (inputString == "")
                return "";
            string[] inputStringAsArray = inputString.Split(' ');
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < inputStringAsArray.Length; i++)
            {
                if (inputStringAsArray[i].Length > 0)
                {
                    sb.AppendFormat("{0}", inputStringAsArray[i].Substring(0, 1).ToUpper());
                }
            }
            return sb.ToString();
        }
        public static string ToAcronym2(this string inputString) =>
            inputString.Trim().Split(' ').Aggregate<string, string>("", (a, b) => a + (b.Length > 0 ? b.ToUpper()[0].ToString() : ""));
    }
}
