using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot
{
    public class ParkingManager : ParkingBoy
    {
        private readonly List<ParkingLot> parkingLots = new List<ParkingLot>();
        private readonly List<ParkingBoy> parkingBoys = new List<ParkingBoy>();

        public ParkingManager(List<ParkingLot> parkingLots) : base(parkingLots)
        {
            this.parkingLots = parkingLots;
            parkingBoys.Add(this);
        }

        public void AddParkingBoy(ParkingBoy parkingBoy)
        {
            parkingBoys.Add(parkingBoy);
        }

        public void RemoveParkingBoy(ParkingBoy parkingBoy)
        {
            parkingBoys.Remove(parkingBoy);
        }

        public new Ticket ParkACarAndGetTicket(string license)
        {
            return SelectedParkingBoy().ParkACarAndGetTicket(license);
        }

        public new string FetchACarWithTicket(Ticket ticket)
        {
            return SelectedParkingBoy().FetchACarWithTicket(ticket);
        }

        private ParkingBoy SelectedParkingBoy()
        {
            var seed = new Random();
            return parkingBoys[seed.Next(0, parkingBoys.Count)];
        }
    }
}
