using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotCLI
{
    public class Ticket
    {
        public Ticket(string ticketNumber)
        {
            TicketNumber = ticketNumber;
        }

        public string TicketNumber { get; }
    }
}
