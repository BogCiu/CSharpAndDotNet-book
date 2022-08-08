using System;

namespace Ch06ExExtra6._4
{
    internal class Program
    {
        struct Order
        {
            public string itemName;
            public int unitCount;
            public double unitCost;
            public double TotalPrice => unitCost * unitCount;
        }
        static void Main(string[] args)
        {
            Order computerParts = new Order();
            computerParts.itemName = "fans";
            computerParts.unitCount = 5;
            computerParts.unitCost = 43.95;
            Console.WriteLine($"Total cost is: {computerParts.TotalPrice}");
        }
    }
}
