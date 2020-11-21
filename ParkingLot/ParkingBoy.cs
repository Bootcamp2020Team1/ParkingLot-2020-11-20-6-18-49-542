using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotCLI
{
    public class ParkingBoy
    {
        private List<ParkingLot> parkingLots;

        public ParkingBoy(List<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots;
        }

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
            return parkingLots.Find(parkingLot => parkingLot.IsFull == false);
        }

        private ParkingLot GetParkingLotByTicket(Ticket ticket)
        {
            return parkingLots.Find(parkingLot => parkingLot.ParkingLotID == ticket.ParkingLotID);
        }
    }
}
