using System.Collections.Generic;

namespace ParkingLot
{
    using System;
    public class ParkingLot
    {
        private List<string> cars = new List<string>();
        private int capacity;
        private int parkingLotNumber;

        public ParkingLot(int capacity, int parkingLotNumber)
        {
            this.capacity = capacity;
            this.parkingLotNumber = parkingLotNumber;
        }

        public int GetParkingLotNumber()
        {
            return parkingLotNumber;
        }

        public void RemoveACar(string license)
        {
            cars.Remove(license);
        }

        public void ParkACar(string license)
        {
            cars.Add(license);
        }

        public bool IsParked(string license)
        {
            return cars.Contains(license);
        }

        public bool IsValidLicense(string license)
        {
            int validLicenseLength = 6;
            return license.Length == validLicenseLength;
        }
    }
}
