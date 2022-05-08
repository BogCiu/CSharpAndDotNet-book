using System;
using System.Text.RegularExpressions;
using System.Collections;

namespace Ch05ExExtra5._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string testString = "Wassup my Gangster, this is my test string. Ain't it nice?";
            Console.WriteLine(testString);

            // Splitting the testString according to RegEx that determines any space, any space preceded by a punctuation mark, and any end line-feed (\n) character preceeded by a punctiation mark.
            string[] myWords = Regex.Split(testString, @"\W?[ \n?]", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(500));
            Console.WriteLine($"\n\nAdded double quotes around all the words (but it's much better than the book example):\n");

            // Remove duplicates from myWords
            // Also, we're going only to "Length - 1" because our regex "accidentally" also cathes a space (" ") as one of the splitted words due to the line-feed character.
            // But this is always at the end of the array, so the -1 'should' allways deal with it.
            var myWords2 = new ArrayList();
            for (int i = 0; i < myWords.Length - 1; i++)
            {
                if (myWords2.Contains(myWords[i]) == false)
                {
                    myWords2.Add(myWords[i]);
                }
            }
            var myWordsNew = myWords2.ToArray();

            // Manually replacing the first word in myWords because it doesn't have a space to the left of it.
            testString = testString.Replace(myWordsNew[0].ToString(), " \"" + myWordsNew[0].ToString() + "\"");

            // Replacing all of the rest of the words in myWords into the testString, because with GOOD GRAMMAR, all words will be preceded by a space
            foreach (string word in myWordsNew)
            {
                testString = testString.Replace(" " + word, " \"" + word + "\"");
                //Console.WriteLine($"\"{word}\"");
            }
            Console.WriteLine(testString);

            Console.ReadKey();
        }
    }
}
