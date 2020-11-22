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

        //Use ParkingLotId instead of ParkingLot here
        //becuase I do not want to expose the ParkingLot information to external user by Ticket
        public string ParkingLotID { get; }
        public string TicketNumber { get; }
    }
}
