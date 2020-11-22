using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot
{
    public class ParkingManager : ParkingBoy
    {
        private List<ParkingLot> parkingLots = new List<ParkingLot>();
        private List<ParkingBoy> parkingBoys = new List<ParkingBoy>();

        public ParkingManager(List<ParkingLot> parkingLots) : base(parkingLots)
        {
            this.parkingLots = parkingLots;
            this.parkingBoys.Add(this);
        }

        public void AddParkingBoy(ParkingBoy parkingBoy)
        {
            parkingBoys.Add(parkingBoy);
        }

        public Ticket ParkACarAndGetTicket(string license)
        {
            return SelectedParkingBoy().ParkACarAndGetTicket(license);
        }

        private ParkingBoy SelectedParkingBoy()
        {
            Random seed = new Random();
            return parkingBoys[seed.Next(0, parkingBoys.Count)];
        }
    }
}
