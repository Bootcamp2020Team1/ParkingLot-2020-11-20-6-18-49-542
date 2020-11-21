using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotCLI
{
    public class Ticket
    {
        public Ticket(string parkingLotID, string ticketNumber)
        {
            ParkingLotID = parkingLotID;
            TicketNumber = ticketNumber;
        }

        public string ParkingLotID { get; }
        public string TicketNumber { get; }
    }
}
