using System;

namespace Ch13Ex02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Connection myConnection = new Connection();
            Display myDisplay = new Display();
            myConnection.MessageArrived += new MessageHandler(myDisplay.DisplayMessage);
            myConnection.Connect();
            System.Threading.Thread.Sleep(200);
            Console.ReadKey();
        }
    }
}
