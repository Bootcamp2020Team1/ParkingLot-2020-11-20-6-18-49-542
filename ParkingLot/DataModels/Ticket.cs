using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot.DataModels
{
    public class Ticket
    {
        public Ticket(string plate, string lotName)
        {
            TicketNumber = Guid.NewGuid().ToString();
            Plate = plate;
            LotName = lotName;
        }

        public string TicketNumber { get; }
        public string Plate { get; }
        public string LotName { get; }

        public override string ToString()
        {
            return $"Your car {Plate} parked at {LotName}.\n TicketNumber: {TicketNumber}";
        }
    }
}
