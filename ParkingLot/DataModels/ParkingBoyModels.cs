namespace ParkingLot.DataModels
{
    using System;
    public abstract class ParkingBoy
    {
        public string TryPark(Car car, ParkingLot parkingLot, out Ticket ticket)
        {
            if (!parkingLot.IsAvailabe)
            {
                ticket = null;
                return $"ParkingLot {parkingLot.LotName} is full.";
            }

            if (parkingLot.IsCarAlreadyHere(car.Plate))
            {
                ticket = null;
                return $"Your car {car.Plate} is already in {parkingLot.LotName}.";
            }

            ticket = parkingLot.AcceptCar(car);
            return string.Empty;
        }

        public string TryFetch(Ticket ticket, ParkingLot parkingLot, out Car car)
        {
            if (!parkingLot.IsCarAlreadyHere(ticket.Plate))
            {
                car = null;
                return $"Your car {ticket.Plate} is NOT in {parkingLot.LotName}.";
            }

            car = parkingLot.ReturnCar(ticket.TicketNumber);
            return string.Empty;
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
