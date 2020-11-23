using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class Ticket
    {
        private readonly string license;
        private readonly int parkingLotNumber;

        public Ticket(string license, int parkingLotNumber)
        {
            this.license = license;
            this.parkingLotNumber = parkingLotNumber;
        }

        public string GetLicense()
        {
            return license;
        }

        public int GetParkingLotNumber()
        {
            return parkingLotNumber;
        }
    }
}
