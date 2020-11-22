using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot
{
    public class NormalParkingBoy : ParkingBoy
    {
        private List<ParkingLot> parkingLots = new List<ParkingLot>();
        public NormalParkingBoy(List<ParkingLot> parkingLots) : base(parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        public Ticket ParkACarAndGetTicket(string license)
        {
            var selectedParkingLotList = parkingLots.Where(parkinglot => CanPark(license, parkinglot)).ToList();
            if (selectedParkingLotList.Count == 0)
            {
                Console.WriteLine("Not enough position.");
                return null;
            }

            selectedParkingLotList[0].ParkACar(license);
            return GetTicket(selectedParkingLotList[0], license);
        }
    }
}
