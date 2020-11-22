using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot
{
    public class SuperSmartParkingBoy : ParkingBoy
    {
        private List<ParkingLot> parkingLots = new List<ParkingLot>();

        public SuperSmartParkingBoy(List<ParkingLot> parkingLots) : base(parkingLots)
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

            List<double> availablePositionRates = new List<double>();
            foreach (var parkingLot in parkingLots)
            {
                availablePositionRates.Add(parkingLot.GetAvailableRate());
            }

            var selectedParkingLot = selectedParkingLotList.Where(parkingLot =>
                parkingLot.GetAvailableRate() == availablePositionRates.Max()).ToList()[0];
            selectedParkingLot.ParkACar(license);
            return GetTicket(selectedParkingLot, license);
        }
    }
}
