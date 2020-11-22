namespace ParkingLot.DataModels
{
    using System;
    public abstract class ParkingBoy
    {
        public Ticket Park(Car car, ParkingLot parkingLot)
        {
            if (!parkingLot.IsAvailabe || parkingLot.IsCarAlreadyHere(car.Plate))
            {
                return null;
            }

            return parkingLot.AcceptCar(car);
        }

        public Car Fetch(Ticket ticket, ParkingLot parkingLot)
        {
            if (!parkingLot.IsCarAlreadyHere(ticket.Plate))
            {
                return null;
            }

            return parkingLot.ReturnCar(ticket.TicketNumber);
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
