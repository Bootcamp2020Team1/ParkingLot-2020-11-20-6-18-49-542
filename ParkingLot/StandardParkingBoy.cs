//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace ParkingLotCLI
//{
//    public class StandardParkingBoy : IParkable
//    {
//        public Car Fetch(Ticket ticket, out string errorMessage)
//        {
//            errorMessage = string.Empty;
//            if (ticket == null)
//            {
//                errorMessage = "Please provide your parking ticket.";
//                return null;
//            }

//            var car = parkingLot.GetCarByTicket(ticket.TicketNumber);
//            if (car == null)
//            {
//                errorMessage = "Unrecognized parking ticket.";
//                return null;
//            }

//            parkingLot.RemoveTheCar(ticket.TicketNumber);
//            return car;
//        }

//        public Ticket Park(Car car, out string errorMessage)
//        {
//        }
//    }
//}
