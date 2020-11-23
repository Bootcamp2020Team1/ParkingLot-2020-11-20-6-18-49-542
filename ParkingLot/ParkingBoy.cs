using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace ParkingLotCLI
{
    public class ParkingBoy
    {
        public ParkingBoy(List<ParkingLot> parkingLots)
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

        public Ticket Park(Car car, out string errorMessage)
        {
            errorMessage = string.Empty;
            var parkingLot = ChooseParkingLot();
            if (parkingLot == null)
            {
                errorMessage = "Not enough position.";
                return null;
            }

            var ticket = parkingLot.AddCar(car);
            return ticket;
        }

        public void AddParkingLots(List<ParkingLot> parkingLots)
        {
            parkingLots.ForEach(parkingLot => ParkingLots.Add(parkingLot));
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

            var car = parkingLot.GetCarByTicket(ticket.TicketNumber);
            if (car == null)
            {
                errorMessage = "Unrecognized parking ticket.";
                return null;
            }

            parkingLot.RemoveTheCar(ticket.TicketNumber);
            return car;
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
