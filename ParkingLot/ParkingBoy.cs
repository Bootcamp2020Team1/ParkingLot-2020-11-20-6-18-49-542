using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private List<ParkingLot> parkingLots = new List<ParkingLot>();

        public ParkingBoy(List<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        public Ticket ParkACarAndGetTicket(string license)
        {
            if (parkingLots.Where(parkinglot => CanPark(license, parkinglot)).ToList().Count == 0)
            {
                Console.WriteLine("Your car can not be parked");
                return null;
            }

            var selectedParkingLot = parkingLots.Where(parkinglot => CanPark(license, parkinglot)).ToList()[0];
            return GetTicket(selectedParkingLot, license);
        }

        public string FetchACarWithTicket(string license, int parkingLotNumber)
        {
            if (parkingLots.Where(parkingLot => parkingLot.GetParkingLotNumber().Equals(parkingLotNumber)).ToList()
                .Count == 0)
            {
                return "Your parking lot is not available";
            }

            var parkingLot = parkingLots.Where(parkingLot => parkingLot.GetParkingLotNumber().Equals(parkingLotNumber)).ToList()[0];
            parkingLot.RemoveACar(license);
            return $"Your car {license} in parking lot number {parkingLot.GetParkingLotNumber()} is fetched";
        }

        private bool CanPark(string license, ParkingLot parkingLot)
        {
            return !parkingLot.IsParked(license) && parkingLot.IsValidLicense(license);
        }

        private Ticket GetTicket(ParkingLot parkingLot, string license)
        {
            return new Ticket(license, parkingLot.GetParkingLotNumber());
        }
    }
}
