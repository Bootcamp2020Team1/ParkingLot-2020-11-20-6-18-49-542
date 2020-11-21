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
            if (cars.ContainsValue(car))
            {
                return null;
            }

            var ticket = new Ticket(ParkingLotID, GenerateUniqueTicketNumber());
            cars.Add(ticket.TicketNumber, car);
            return ticket;
        }

        internal Car GetCarByTicket(Ticket ticket)
        {
            return cars[ticket.TicketNumber];
        }

        private string GenerateUniqueTicketNumber()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
