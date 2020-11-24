using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace ParkingLotCLI
{
    public class ParkingBoy : PersonCanPark
    {
        public ParkingBoy(List<ParkingLot> parkingLots) : base(parkingLots)
        {
        }
    }
}
