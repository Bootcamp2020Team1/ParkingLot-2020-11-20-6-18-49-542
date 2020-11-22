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
            selectedParkingLot.ParkACar(license);
            return GetTicket(selectedParkingLot, license);
        }

        public string FetchACarWithTicket(Ticket ticket)
        {
            var selectedParkingLotList = parkingLots
                .Where(parkingLot => parkingLot.GetParkingLotNumber().Equals(ticket.GetParkingLotNumber())).ToList();
            if (selectedParkingLotList
                .Count == 0 || !selectedParkingLotList[0].IsParked(ticket.GetLicense()))
            {
                return "Unrecognized parking ticket.";
            }

            var parkingLot = selectedParkingLotList[0];
            parkingLot.RemoveACar(ticket.GetLicense());
            return $"Your car {ticket.GetLicense()} in parking lot number {parkingLot.GetParkingLotNumber()} is fetched";
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
