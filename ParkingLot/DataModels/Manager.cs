using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot.DataModels
{
    public class Manager : ParkingBoy
    {
        private readonly List<ParkingBoy> managementList = new List<ParkingBoy>();
        public Manager(Lot[] lots, List<ParkingBoy> managementList) : base(lots)
        {
            this.managementList = managementList;
        }

        public int ManagementListCount => this.managementList.Count;
        public void AddParkingBoy(ParkingBoy parkingBoy)
        {
            parkingBoy.ParkingLots = this.ParkingLots;
            managementList.Add(parkingBoy);
        }

        public ParkingBoy AppointBoy()
        {
            var appointedBoy = managementList[0];
            return appointedBoy;
        }
    }
}
