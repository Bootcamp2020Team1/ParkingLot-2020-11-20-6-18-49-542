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

        public int ParkingLotsCount => ParkingLots.Count;

        protected List<ParkingLot> ParkingLots { get; }

        public void AddParkingLots(List<ParkingLot> parkingLots)
        {
            parkingLots.ForEach(parkingLot => ParkingLots.Add(parkingLot));
        }

        public bool RemoveParkingLot(ParkingLot parkingLot)
        {
            if (ParkingLots.Contains(parkingLot))
            {
                ParkingLots.Remove(parkingLot);
                return true;
            }

            return false;
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
                errorMessage = "Unrecognized parking ticket.";
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
            if (ticket == null || string.IsNullOrEmpty(ticket.TicketNumber))
            {
                return null;
            }

            return ParkingLots.Find(parkingLot => parkingLot.Tickets.Contains(ticket.TicketNumber));
        }
    }
}
