using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ParkingLotCLI
{
    public class ServiceManager : IParkable
    {
        private readonly List<ParkingBoy> managementList;
        private List<ParkingLot> parkingLots;

        public ServiceManager(List<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots;
            this.managementList = new List<ParkingBoy>();
        }

        public void AddParkingBoy(ParkingBoy parkingBoy)
        {
            if (parkingBoy.IdOfParkingLots.Count == 0)
            {
                parkingBoy.AddParkingLots(parkingLots);
                managementList.Add(parkingBoy);
            }
        }

        public Ticket SpecifyParkingBoyToPark(Car car, out string errorMessage)
        {
            errorMessage = string.Empty;
            var parkingBoy = ChooseBoy();
            if (parkingBoy == null)
            {
                return null;
            }

            return parkingBoy.Park(car, out errorMessage);
        }

        public Car SpecifyParkingBoyToFetch(Ticket ticket, out string errorMessage)
        {
            errorMessage = string.Empty;
            var parkingBoy = ChooseBoy();
            if (parkingBoy == null)
            {
                return null;
            }

            return parkingBoy.Fetch(ticket, out errorMessage);
        }

        public Car Fetch(Ticket ticket, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (ticket == null)
            {
                errorMessage = "Please provide your parking ticket.";
                return null;
            }

            var parkingLot = GetParkingLotByTicket(ticket);
            if (parkingLot == null)
            {
                return null;
            }

            return parkingLot.Fetch(ticket, out errorMessage);
        }

        public Ticket Park(Car car, out string errorMessage)
        {
            var parkingLot = ChooseParkingLot();
            if (parkingLot == null)
            {
                errorMessage = "Not enough position.";
                return null;
            }

            return parkingLot.Park(car, out errorMessage);
        }

        private ParkingLot GetParkingLotByTicket(Ticket ticket)
        {
            return parkingLots.Find(parkingLot => parkingLot.IsFull == false);
        }

        private ParkingLot ChooseParkingLot()
        {
            return ChooseParkingLotSequentially();
        }

        private ParkingLot ChooseParkingLotSequentially()
        {
            return parkingLots.Find(parkingLot => parkingLot.IsFull == false);
        }

        private ParkingBoy ChooseBoy()
        {
            var count = managementList.Count;
            if (count < 1)
            {
                return null;
            }

            var randomIndex = new Random().Next(count - 1);
            return managementList[randomIndex];
        }
    }
}
