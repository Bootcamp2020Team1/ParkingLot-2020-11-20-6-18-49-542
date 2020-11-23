using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class Car
    {
        public Car(string id)
        {
            this.Id = id;
        }

        public string Id { get; set; }
        public bool IsParked { get; set; } = false;
    }
}
