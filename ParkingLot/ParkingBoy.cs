using System;
using System.Collections.Generic;
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

        public void AddParkingLot(ParkingLot newParkingLot)
        {
            boysParkingLots.Add(newParkingLot);
        }

        public Ticket BoyParkCar(string carId)
        {
            ParkingLot parkingLot = this.FindAvaibleParkingLot();
            Ticket newTicket = new Ticket(parkingLot.Id, this.Id, carId);
            return newTicket;
        }

        public string BoyFetchCar(Ticket ticket)
        {
            if (!ticket.IsUsed)
            {
                string ticketLotId = ticket.ParkingLotId;
                ParkingLot rightLot = boysParkingLots.Find(parkingLot => parkingLot.Id == ticketLotId);
                rightLot.LotFetchCar(ticket);
                ticket.IsUsed = true;
            }

            return ticket.CarId;
        }

        public ParkingLot FindAvaibleParkingLot()
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

        public List<ParkingLot> GetBoysParkingLots()
        {
            return boysParkingLots;
        }
    }
}
