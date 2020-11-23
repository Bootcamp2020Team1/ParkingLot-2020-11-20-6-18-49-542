using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public interface IParkable
    {
        public Ticket ParkACarAndGetTicket(string license);
        public string FetchACarWithTicket(Ticket ticket);
    }
}
