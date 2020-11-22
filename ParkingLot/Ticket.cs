using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class Ticket
    {
        public Ticket(string parkingLot, string parkingBoy, string carId)
        {
            this.ParkingBoyId = parkingBoy;
            this.ParkingLotId = parkingLot;
            this.CarId = carId;
        }

        public bool IsUsed { get; set; } = false;
        public string ParkingLotId { get; set; }
        public string ParkingBoyId { get; set; }
        public string CarId { get; set; }
    }
}
