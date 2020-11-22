namespace ParkingLot.DataModels
{
    using System;
    using System.Linq;
    public class ParkingBoy
    {
        public ParkingBoy(int id = 0)
        {
            this.Id = id;
        }

        public ParkingLot[] ParkingLots { get; set; }
        public int Id { get; }
        public string TryPark(Car car, ParkingLot parkingLot, out Ticket ticket)
        {
            if (!parkingLot.IsAvailabe)
            {
                ticket = null;
                return $"Not enough positions.";
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
            if (ticket.IsUsed || !parkingLot.IsCarAlreadyHere(ticket.Plate))
            {
                car = null;
                return $"Unrecognized parking ticket.";
            }

            car = parkingLot.ReturnCar(ticket.TicketNumber);
            ticket.IsUsed = true;
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
