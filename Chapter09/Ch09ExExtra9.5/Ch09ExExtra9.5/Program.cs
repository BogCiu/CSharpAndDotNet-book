using System;
using Vehicles;


namespace Ch09ExExtra9._5
{
    internal class Program
    {
        static void AddPassenger(IPassengerCarrier Vehicle)
        {
            Console.WriteLine(Vehicle.ToString());
        }
        static void Main(string[] args)
        {
            AddPassenger(new Compact());
            AddPassenger(new SUV());
            //AddPassenger(new Pickup());
            AddPassenger(new PassengerTrain());
            //AddPassenger(new FreightTrain());
            //AddPassenger(new _424DoubleBogey());

        }
    }
}
