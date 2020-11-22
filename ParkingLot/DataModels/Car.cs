using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot.DataModels
{
    public class Car
    {
        public Car(string plate)
        {
            this.Plate = plate;
        }

        public string Plate { get; }
    }
}
