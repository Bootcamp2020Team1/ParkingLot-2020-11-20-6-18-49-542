using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ParkingLotCLI
{
    public class ParkingLot
    {
        private Dictionary<string, Car> cars;
        public ParkingLot()
        {
            cars = new Dictionary<string, Car>();
            ParkingLotID = "123";
        }

        public string ParkingLotID { get; }

        internal Ticket AddCar(Car car)
        {
            var ticket = new Ticket(ParkingLotID, "ticket number");
            cars.Add(ticket.TicketNumber, car);
            return ticket;
        }

        internal Car GetCarByTicket(Ticket ticket)
        {
            return new Car("N958673");
        }
    }
}
