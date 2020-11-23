using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class SuperSmartParkingBoy : ParkingBoy
    {
        private List<ParkingLot> boysParkingLots = new List<ParkingLot>();
        public SuperSmartParkingBoy(string id) : base(id)
        {
        }

        public new ParkingLot FindAvaibleParkingLot()
        {
            ParkingLot availableLot = null;
            double maxLeftPositionRatio = 0;
            foreach (ParkingLot parkingLot in boysParkingLots)
            {
                double leftPositionRatio = parkingLot.LeftPosition / parkingLot.Capacity;
                if (leftPositionRatio > maxLeftPositionRatio)
                {
                    maxLeftPositionRatio = parkingLot.LeftPosition;
                }
            }

            availableLot = boysParkingLots.Find(parkingLot => parkingLot.LeftPosition == maxLeftPositionRatio);

            return availableLot;
        }
    }
}
