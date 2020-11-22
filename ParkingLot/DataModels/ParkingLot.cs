using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot.DataModels
{
    public class ParkingLot
    {
        public ParkingLot(int capacity)
        {
            Capacity = capacity;
        }

        public ParkingLot()
        {
            Capacity = 10;
        }

        public int Capacity { get; }
    }
}
