using System;
using System.Linq;

namespace ParkingLot.DataModels
{
    public class ParkingBoy
    {
        public ParkingBoy(Lot[] parkingLots, int id = 0)
        {
            this.Id = id;
            this.ParkingLots = parkingLots;
        }

        public Lot[] ParkingLots { get; set; }
        public int Id { get; }
        public string TryParkToSpecificLot(Car car, Lot parkingLot, out Ticket ticket)
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

        public string TryFetchFromSpecificLot(Ticket ticket, Lot parkingLot, out Car car)
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

        public virtual string TryPark(Car car, out Ticket ticket)
        {
            var currentLot = ParkingLots.FirstOrDefault(x => x.IsAvailabe);
            return this.TryParkToSpecificLot(car, currentLot, out ticket);
        }

        public string TryFetch(Ticket ticket, out Car car)
        {
            var currentLot = ParkingLots.FirstOrDefault(x => x.LotName == ticket.LotName);
            return this.TryFetchFromSpecificLot(ticket, currentLot, out car);
        }
    }

    public class SmartParkingBoy : ParkingBoy
    {
        public SmartParkingBoy(Lot[] parkingLots, int id = 0) : base(parkingLots, id)
        {
        }

        public override string TryPark(Car car, out Ticket ticket)
        {
            var currentLot = ParkingLots.Where(x => x.IsAvailabe).OrderBy(x => x.AvailablePositions).LastOrDefault();
            return TryParkToSpecificLot(car, currentLot, out ticket);
        }
    }

    public class SuperSmartParkingBoy : ParkingBoy
    {
        public SuperSmartParkingBoy(Lot[] parkingLots, int id = 0) : base(parkingLots, id)
        {
        }

        public override string TryPark(Car car, out Ticket ticket)
        {
            var currentLot = ParkingLots.Where(x => x.IsAvailabe).OrderBy(x => x.AvailablePositions / x.Capacity).LastOrDefault();
            return TryParkToSpecificLot(car, currentLot, out ticket);
        }
    }
}
