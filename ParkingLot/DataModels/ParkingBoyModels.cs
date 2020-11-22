namespace ParkingLot.DataModels
{
    using System;
    public abstract class ParkingBoy
    {
        public Ticket Park(Car car, ParkingLot parkingLot)
        {
            return new Ticket();
        }
    }

    public class SimpleParkingBoy : ParkingBoy
    {
    }

    public class SmartParkingBoy : ParkingBoy
    {
    }

    public class SuperSmartParkingBoy : ParkingBoy
    {
    }
}
