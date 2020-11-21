using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ParkingLotCLI
{
    public class SmartParkingBoy : ParkingBoy
    {
        public SmartParkingBoy(List<ParkingLot> parkingLots) : base(parkingLots)
        {
        }

        protected override ParkingLot ChooseParkingLot()
        {
            return ChooseParkingLotWithMoreEmptyPositions();
        }

        private ParkingLot ChooseParkingLotWithMoreEmptyPositions()
        {
            var maxCapacity = ParkingLots.Max(p => p.Capacity);
            return ParkingLots.Find(p => p.Capacity == maxCapacity);
        }
    }
}
