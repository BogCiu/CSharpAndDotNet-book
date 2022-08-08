using System;

namespace Ch07ExExtra7._4
{
    internal class Program
    {
        enum Orientation : byte
        {
            North = 1,
            South = 2,
            East = 3,
            West = 4
        }
        static void Main(string[] args)
        {
            Orientation myDirection;
            for (byte myByte = 2; myByte<10; myByte++)
            {
                try
                {
                    myDirection = checked((Orientation)myByte);
                    if ((myDirection < Orientation.North) || (myDirection > Orientation.West))
                    {
                        throw new ArgumentOutOfRangeException("myByte", myByte, "Value must be between 1 and 4");
                    }
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Assigning default value, Orientation.North.");
                    myDirection = Orientation.North;
                }

            Console.WriteLine($"myDirection = {myDirection}");
            }
        }
    }
}
