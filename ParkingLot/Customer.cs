using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class Customer
    {
        public Customer(string id)
        {
            this.Id = id;
        }

        public string Id { get; set; }

        public Ticket ParkCarCustomer(Car car, ParkingBoy parkingBoy)
        {
            Ticket ticket = parkingBoy.ParkCarBoy(car, this.Id);
            return ticket;
        }

        public string FetchCarCustomer(Ticket ticket, ParkingBoy parkingBoy)
        {
            var car = parkingBoy.FetchCarBoy(ticket);
            return car;
        }
    }
}
