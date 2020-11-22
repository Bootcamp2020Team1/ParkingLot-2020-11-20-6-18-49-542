using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ParkingLot.DataModels
{
    public class ParkingLot
    {
        private Dictionary<Ticket, Car> parkedCars;
        public ParkingLot(string lotName, int capacity = 10)
        {
            LotName = lotName;
            Capacity = capacity;
            parkedCars = new Dictionary<Ticket, Car>();
        }

        public string LotName { get; }
        public int Capacity { get; }
        public int AvailablePositions => Capacity - parkedCars.Keys.Count;
        public bool IsAvailabe => AvailablePositions > 0;

        public bool IsCarAlreadyHere(Car car) => parkedCars.Values.Select(x => x.Plate).Contains(car.Plate);

        public Ticket AcceptCar(Car incomingCar)
        {
            if (!this.IsAvailabe || IsCarAlreadyHere(incomingCar))
            {
                return null;
            }

            var ticket = new Ticket(incomingCar.Plate, LotName);
            parkedCars.Add(ticket, incomingCar);
            return ticket;
        }

        public Car ReturnCar(Ticket ticket)
        {
            Car car = parkedCars[ticket];
            parkedCars.Remove(ticket);
            return car;
        }
    }
}
