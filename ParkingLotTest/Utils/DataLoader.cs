using System;
using System.Collections.Generic;
using System.Text;
using ParkingLot.DataModels;

namespace ParkingLotTest.Utils
{
    public static class DataLoader
    {
        public static Lot[] GetParkingLots()
        {
            return new Lot[]
            {
                new Lot("MyLot1", 1),
                new Lot("MyLot2", 2),
                new Lot("MyLot3"),
            };
        }
    }
}
