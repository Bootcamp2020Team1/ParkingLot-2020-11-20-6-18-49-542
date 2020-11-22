using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot
{
    public class SmartParkingBoy : ParkingBoy
    {
        private List<ParkingLot> parkingLots = new List<ParkingLot>();

        public SmartParkingBoy(List<ParkingLot> parkingLots) : base(parkingLots)
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

            List<int> availablePositions = new List<int>();
            foreach (var parkingLot in parkingLots)
            {
                availablePositions.Add(parkingLot.GetAvailablePosition());
            }

            var selectedParkingLot = selectedParkingLotList.Where(parkingLot =>
                parkingLot.GetAvailablePosition() == availablePositions.Max()).ToList()[0];
            selectedParkingLot.ParkACar(license);
            return GetTicket(selectedParkingLot, license);
        }
    }
}
