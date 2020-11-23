using System;
using System.Collections.Generic;

namespace ParkingLotCLI
{
    //To remove duplicate code, I extract a class called PersonCanPark
    public class ServiceManager : PersonCanPark
    {
        private readonly List<ParkingBoy> managementList;

        public ServiceManager(List<ParkingLot> parkingLots) : base(parkingLots)
        {
            this.managementList = new List<ParkingBoy>();
        }

        public void AddParkingBoy(ParkingBoy parkingBoy)
        {
            if (parkingBoy.ParkingLotsCount == 0)
            {
                parkingBoy.AddParkingLots(ParkingLots);
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

        public bool RemoveParkingBoy(ParkingBoy parkingBoy)
        {
            if (managementList.Contains(parkingBoy))
            {
                managementList.Remove(parkingBoy);
                return true;
            }

            return false;
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
