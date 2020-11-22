using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private List<ParkingLot> boysParkingLots = new List<ParkingLot>();
        public ParkingBoy(string id)
        {
            this.Id = id;
        }

        public string Id { get; set; }

        public List<ParkingLot> BoysParkingLots => boysParkingLots;

        public void AddParkingLot(ParkingLot newParkingLot)
        {
            this.boysParkingLots.Add(newParkingLot);
        }

        public Ticket ParkCarBoy(Car car, string customerId)
        {
            Ticket newTicket = null;
            if (car != null && car.IsParked == false)
            {
                ParkingLot parkingLot = FindAvaibleParkingLot();
                bool isParkSuccess = parkingLot.ParkCarLot(car);
                if (isParkSuccess)
                {
                    newTicket = new Ticket(parkingLot.Id, this.Id, car.Id, customerId);
                    car.IsParked = true;
                }
            }

            return newTicket;
        }

        public string FetchCarBoy(Ticket ticket)
        {
            if (ticket.IsUsed)
            {
                return "The ticket has been used.";
            }

            if (ticket.ParkingBoyId != this.Id)
            {
                return "The ticket is not provided by the parking boy.";
            }

            var rightLot = boysParkingLots.First(parkingLot => parkingLot.Id == ticket.ParkingLotId);
            var carFound = rightLot.FetchCarLot(ticket);
            ticket.SetTicketAsUsed();
            return carFound.Id;
        }

        public virtual ParkingLot FindAvaibleParkingLot()
        {
            ParkingLot availableLot = null;
            bool canContinue = true;
            foreach (ParkingLot parkingLot in boysParkingLots)
            {
                if (parkingLot.LeftPosition > 0 && canContinue)
                {
                    canContinue = false;
                    availableLot = parkingLot;
                }
            }

            return availableLot;
        }
    }
}
