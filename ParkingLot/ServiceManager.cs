using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ParkingLotCLI
{
    public class ServiceManager : ParkingBoy
    {
        private readonly List<ParkingBoy> managementList;

        public ServiceManager(List<ParkingLot> parkingLots) : base(parkingLots)
        {
            this.managementList = new List<ParkingBoy>();
        }

        public void AddParkingBoy(ParkingBoy parkingBoy)
        {
            managementList.Add(parkingBoy);
        }

        public Ticket Park(Car car, ParkingBoy parkingBoy)
        {
            if (managementList.Find(parkingBoyInList => parkingBoyInList == parkingBoy) == null)
            {
                return null;
            }

            return parkingBoy.Park(car, out _);
        }

        public Car Fetch(Ticket ticket, ParkingBoy parkingBoy)
        {
            if (managementList.Find(parkingBoyInList => parkingBoyInList == parkingBoy) == null)
            {
                return null;
            }

            return parkingBoy.Fetch(ticket, out _);
        }
    }
}
