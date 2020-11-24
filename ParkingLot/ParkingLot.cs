using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ParkingLotCLI
{
    public class ParkingLot : IParkable
    {
        private Dictionary<string, Car> cars;
        public ParkingLot()
        {
            cars = new Dictionary<string, Car>();
            Capacity = 10;
        }

        public ParkingLot(int capacity) : this()
        {
            Capacity = capacity;
        }

        public int Capacity { get; }
        public int PositionAvailable => Capacity - cars.Count;

        public bool IsFull => PositionAvailable <= 0;

        public List<string> Tickets => cars.Select(car => car.Key).ToList();

        public Ticket Park(Car car, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (IsFull)
            {
                errorMessage = "Not enough position.";
                return null;
            }

            if (car == null || cars.ContainsValue(car))
            {
                return null;
            }

            var ticket = new Ticket(GenerateUniqueTicketNumber());
            cars.Add(ticket.TicketNumber, car);
            return ticket;
        }

        public Car Fetch(Ticket ticket, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrEmpty(ticket.TicketNumber) || !cars.ContainsKey(ticket.TicketNumber))
            {
                errorMessage = "Unrecognized parking ticket.";
                return null;
            }

            var car = cars[ticket.TicketNumber];
            cars.Remove(ticket.TicketNumber);
            return car;
        }

        private string GenerateUniqueTicketNumber()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
