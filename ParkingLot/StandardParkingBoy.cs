using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLotCLI
{
    public class PersonCanPark : IParkable
    {
        public PersonCanPark(List<ParkingLot> parkingLots)
        {
            ParkingLots = parkingLots;
        }

        public List<string> IdOfParkingLots
        {
            get
            {
                return ParkingLots.Select(parkingLot => parkingLot.ParkingLotID).ToList();
            }
        }

        protected List<ParkingLot> ParkingLots { get; }
        public void AddParkingLots(List<ParkingLot> parkingLots)
        {
            parkingLots.ForEach(parkingLot => ParkingLots.Add(parkingLot));
        }

        public Ticket Park(Car car, out string errorMessage)
        {
            var parkingLot = ChooseParkingLot();
            if (parkingLot == null)
            {
                errorMessage = "Not enough position.";
                return null;
            }

            return parkingLot.Park(car, out errorMessage);
        }

        public Car Fetch(Ticket ticket, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (ticket == null)
            {
                errorMessage = "Please provide your parking ticket.";
                return null;
            }

            var parkingLot = GetParkingLotByTicket(ticket);
            if (parkingLot == null)
            {
                return null;
            }

            return parkingLot.Fetch(ticket, out errorMessage);
        }

        protected virtual ParkingLot ChooseParkingLot()
        {
            return ChooseParkingLotSequentially();
        }

        private ParkingLot ChooseParkingLotSequentially()
        {
            return ParkingLots.Find(parkingLot => parkingLot.IsFull == false);
        }

        private ParkingLot GetParkingLotByTicket(Ticket ticket)
        {
            return ParkingLots.Find(parkingLot => parkingLot.ParkingLotID == ticket.ParkingLotID);
        }
    }
}
