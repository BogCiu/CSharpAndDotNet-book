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
            public void OrderInfo()
            {
                Console.WriteLine($"Order Information: {unitCount} {itemName} items at ${unitCost} each, total cost ${TotalPrice}");
            }
        }
        static void Main(string[] args)
        {
            Order computerParts = new Order();
            computerParts.itemName = "Cooling Fan";
            computerParts.unitCount = 5;
            computerParts.unitCost = 43.95;

            computerParts.OrderInfo();
        }
    }
}
