using System;

namespace Vehicles
{
    public class Vehicle
    {
    }
    public class Car : Vehicle
    {
    }
    public class Train : Vehicle
    {
    }
    public interface IHeavyLoadCarrier
    {
    }
    public interface IPassengerCarrier
    {
    }
    public class Compact : Car, IPassengerCarrier
    {
    }
    public class SUV : Car, IPassengerCarrier
    {
    }
    public class Pickup : Car, IHeavyLoadCarrier
    {
    }
    public class PassengerTrain : Train, IPassengerCarrier
    {
    }
    public class FreightTrain : Train, IHeavyLoadCarrier
    {
    }
    public class _424DoubleBogey : Train
    {
    }
}
