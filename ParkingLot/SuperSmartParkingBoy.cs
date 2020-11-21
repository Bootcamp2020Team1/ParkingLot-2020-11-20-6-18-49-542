using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ParkingLotCLI
{
    public class SuperSmartParkingBoy : ParkingBoy
    {
        public SuperSmartParkingBoy(List<ParkingLot> parkingLots) : base(parkingLots)
        {
        }

        protected override ParkingLot ChooseParkingLot()
        {
            return ChooseParkingLotWithLargerAvailablePositionRate();
        }

        private ParkingLot ChooseParkingLotWithLargerAvailablePositionRate()
        {
            var maxAvailablePositionRate = ParkingLots.Max(p => GetAvailablePositionRate(p));
            return ParkingLots.Find(p => GetAvailablePositionRate(p) == maxAvailablePositionRate);
        }

        private double GetAvailablePositionRate(ParkingLot parkingLot)
        {
            if (parkingLot == null || parkingLot.PositionAvailable == 0)
            {
                return 0;
            }

            return (double)parkingLot.PositionAvailable / (double)parkingLot.PositionAvailable;
        }
    }
}
