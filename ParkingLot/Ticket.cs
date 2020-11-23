using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class Ticket
    {
        public Ticket(string parkingLot, string parkingBoy, string carId, string customerId)
        {
            this.IsUsed = false;
            this.ParkingBoyId = parkingBoy;
            this.ParkingLotId = parkingLot;
            this.CarId = carId;
            this.CustomerId = customerId;
        }

        public bool IsUsed { get; set; }
        public string ParkingLotId { get; set; }
        public string ParkingBoyId { get; set; }
        public string CarId { get; set; }
        public string CustomerId { get; set; }

        public void SetTicketAsUsed()
        {
            this.IsUsed = true;
        }
    }
}
