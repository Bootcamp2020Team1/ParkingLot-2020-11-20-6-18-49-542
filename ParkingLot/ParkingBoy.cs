using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotCLI
{
    public class ParkingBoy
    {
        private ParkingLot parkingLot;

        public ParkingBoy(ParkingLot parkingLot)
        {
            this.parkingLot = parkingLot;
        }

        public Ticket Park(Car car)
        {
            var ticket = parkingLot.AddCar(car);
            return ticket;
        }

        public Car Fetch(Ticket ticket)
        {
            var car = parkingLot.GetCarByTicket(ticket);
            return car;
        }
    }
}
