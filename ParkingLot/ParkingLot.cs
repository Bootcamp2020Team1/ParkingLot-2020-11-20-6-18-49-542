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
            Capacity = 10;
        }

        public ParkingLot(int capacity) : this()
        {
            Capacity = capacity;
        }

        public string ParkingLotID { get; }
        public int Capacity { get; }

        internal Ticket AddCar(Car car, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (cars.Count == Capacity)
            {
                errorMessage = "Not enough position.";
                return null;
            }

            if (cars.ContainsValue(car))
            {
                return null;
            }

            var ticket = new Ticket(ParkingLotID, GenerateUniqueTicketNumber());
            cars.Add(ticket.TicketNumber, car);
            return ticket;
        }

        internal Car GetCarByTicket(string ticketNumber)
        {
            if (ticketNumber == null || !cars.ContainsKey(ticketNumber))
            {
                return null;
            }

            return cars[ticketNumber];
        }

        internal bool RemoveTheCar(string ticketNumbre)
        {
            return cars.Remove(ticketNumbre);
        }

        private string GenerateUniqueTicketNumber()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
