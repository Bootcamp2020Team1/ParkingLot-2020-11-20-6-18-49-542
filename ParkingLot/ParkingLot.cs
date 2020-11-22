﻿namespace ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class ParkingLot
    {
        private List<ParkingBoy> manageParkingBoys = new List<ParkingBoy>();
        private List<string> parkedCars = new List<string>();

        public ParkingLot(int capacity, string parkingLotId)
        {
            this.Capacity = capacity;
            this.Id = parkingLotId;
        }

        public int Capacity { get; set; }
        public string Id { get; set; }

        public int LeftPosition
        {
            get
            {
                return Capacity - parkedCars.Count;
            }
        }

        public int UsedPosition
        {
            get
            {
                return parkedCars.Count;
            }
        }

        public void AddParkingBoy(ParkingBoy newParkingBoy)
        {
            manageParkingBoys.Add(newParkingBoy);
        }

        public string FetchCarLot(Ticket ticket)
        {
            string carFound = parkedCars.Find(eachParkedCar => eachParkedCar == ticket.CarId);
            if (carFound != null)
            {
                parkedCars.Remove(ticket.CarId);
            }

            return carFound;
        }

        public void ParkCarLot(string carId)
        {
            parkedCars.Add(carId);
        }
    }
}
