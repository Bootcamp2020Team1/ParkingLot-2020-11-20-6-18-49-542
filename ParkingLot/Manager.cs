using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class Manager : ParkingBoy
    {
        private List<ParkingBoy> parkingBoys = new List<ParkingBoy>();
        private List<ParkingLot> parkingLots = new List<ParkingLot>();
        public Manager(string id) : base(id)
        {
            this.Id = id;
        }

        public string Id { get; }

        public void AddParkingBoy(ParkingBoy parkingBoy)
        {
            parkingBoys.Add(parkingBoy);
        }

        public void AddParkingLot(ParkingLot parkingLot)
        {
            parkingLots.Add(parkingLot);
        }

        public string AssignParkingBoyFetch(Ticket ticket)
        {
            var parkingLot = parkingLots.Find(parkingLot => parkingLot.Id == ticket.ParkingLotId);
            var assignedBoy = parkingBoys.Find(parkingBoy => parkingBoy.BoysParkingLots.Contains(parkingLot));
            return assignedBoy.FetchCarBoy(ticket);
        }
    }
}
