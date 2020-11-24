using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotCLI
{
    public class Car
    {
        public Car(string licencePlate)
        {
            this.LicencePlate = licencePlate;
        }

        public string LicencePlate { get; }
    }
}
