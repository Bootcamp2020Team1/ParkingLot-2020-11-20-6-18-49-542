using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ParkingLot.DataModels
{
    public class ParkingLot
    {
        private Dictionary<string, Car> parkedCars;
        public ParkingLot(string lotName, int capacity = 10)
        {
            LotName = lotName;
            Capacity = capacity;
            parkedCars = new Dictionary<string, Car>();
        }

        public string LotName { get; }
        public int Capacity { get; }
        public int AvailablePositions => Capacity - parkedCars.Keys.Count;
        public bool IsAvailabe => AvailablePositions > 0;

        public bool IsCarAlreadyHere(string plate) => parkedCars.Values.Select(x => x.Plate).Contains(plate);

        public Ticket AcceptCar(Car incomingCar)
        {
            var ticket = new Ticket(incomingCar.Plate, LotName);
            parkedCars.Add(ticket.TicketNumber, incomingCar);
            return ticket;
        }

        public Car ReturnCar(string ticketNumber)
        {
            Car car = parkedCars[ticketNumber];
            parkedCars.Remove(ticketNumber);
            return car;
        }
    }
}
