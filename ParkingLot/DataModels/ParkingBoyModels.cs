namespace ParkingLot.DataModels
{
    using System;
    public abstract class ParkingBoy
    {
        public Ticket Park(Car car, ParkingLot parkingLot)
        {
            return parkingLot.AcceptCar(car);
        }

        public Car Fetch(string ticketNumber, ParkingLot parkingLot)
        {
            return parkingLot.ReturnCar(ticketNumber);
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
