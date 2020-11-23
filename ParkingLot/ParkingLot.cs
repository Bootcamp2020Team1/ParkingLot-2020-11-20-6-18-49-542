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
            ParkingLotID = Guid.NewGuid().ToString();
            Capacity = 10;
        }

        public ParkingLot(int capacity) : this()
        {
            Capacity = capacity;
        }

        public ParkingLot(Guid id, int capacity) : this(capacity)
        {
            ParkingLotID = id.ToString();
        }

        public string ParkingLotID { get; }
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

            var ticket = new Ticket(ParkingLotID, GenerateUniqueTicketNumber());
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
