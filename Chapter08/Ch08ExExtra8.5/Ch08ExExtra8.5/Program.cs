using System;

namespace Ch08ExExtra8._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICup myCoffee = new CupOfCoffee();
            ICup myTea = new CupOfTea();
            ICup myHotDrink = new HotDrink();

            HandleDrink((HotDrink)myHotDrink);
            HandleDrink((HotDrink)myTea);
            HandleDrink((HotDrink)myCoffee);
        }

        static void HandleDrink(HotDrink drink)
        {
            drink.AddMilk();
            drink.Drink();
            ICup cupHandler = (ICup)drink;
            cupHandler.Wash();
        }
    }
    public class HotDrink:ICup
    {
        bool Milk;
        bool Sugar;
        public void AddMilk()
        {

        }

        public void Drink()
        {

        }
        public void AddSugar()
        {

        }
    }
    public interface ICup
    {
        void Wash()
        { }
        void Refill()
        { }
    }

    public class CupOfCoffee:HotDrink
    {
        string BeanType = "";
    }
    public class CupOfTea:HotDrink
    {
        string LeafType = "";
    }
}
