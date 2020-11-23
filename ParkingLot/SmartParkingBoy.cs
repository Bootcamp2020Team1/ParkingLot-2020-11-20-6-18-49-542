using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class SmartParkingBoy : ParkingBoy
    {
        //private List<ParkingLot> boysParkingLots = new List<ParkingLot>();
        public SmartParkingBoy(string id) : base(id)
        {
        }

        public override ParkingLot FindAvaibleParkingLot()
        {
            ParkingLot availableLot = null;
            int maxLeftPosition = 0;
            foreach (ParkingLot parkingLot in BoysParkingLots)
            {
                if (parkingLot.LeftPosition > maxLeftPosition)
                {
                    maxLeftPosition = parkingLot.LeftPosition;
                }
            }

            availableLot = BoysParkingLots.Find(parkingLot => parkingLot.LeftPosition == maxLeftPosition);
            //availableLot = boysParkingLots[1];
            return availableLot;
        }
    }
}
