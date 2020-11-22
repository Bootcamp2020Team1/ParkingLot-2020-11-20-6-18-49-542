namespace ParkingLot.DataModels
{
    using System;
    using System.Linq;
    public class ParkingBoy
    {
        public ParkingBoy(Lot[] parkingLots, int id = 0)
        {
            this.Id = id;
            this.ParkingLots = parkingLots;
        }

        public Lot[] ParkingLots { get; set; }
        public int Id { get; }
        public string TryPark(Car car, Lot parkingLot, out Ticket ticket)
        {
            if (!parkingLot.IsAvailabe)
            {
                ticket = null;
                return "Not enough positions.";
            }

            if (parkingLot.IsCarAlreadyHere(car.Plate))
            {
                ticket = null;
                return $"Your car {car.Plate} is already in {parkingLot.LotName}.";
            }

            ticket = parkingLot.AcceptCar(car);
            return string.Empty;
        }

        public string TryFetch(Ticket ticket, Lot parkingLot, out Car car)
        {
            if (ticket == null)
            {
                car = null;
                return "Please provide your parking ticket.";
            }

            if (ticket.IsUsed || !parkingLot.IsCarAlreadyHere(ticket.Plate))
            {
                car = null;
                return "Unrecognized parking ticket.";
            }

            car = parkingLot.ReturnCar(ticket.TicketNumber);
            ticket.IsUsed = true;
            return string.Empty;
        }
    }
}
