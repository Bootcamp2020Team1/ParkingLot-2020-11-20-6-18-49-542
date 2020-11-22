namespace ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ParkingLot
    {
        private List<ParkingBoy> manageParkingBoys = new List<ParkingBoy>();
        private List<Car> parkedCars = new List<Car>();

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

        public Car FetchCarLot(Ticket ticket)
        {
            Car carFound = parkedCars.First(eachParkedCar => eachParkedCar.Id == ticket.CarId);
            //Car carFound = new Car("c1");
            if (carFound != null)
            {
                parkedCars.Remove(carFound);
            }

            return carFound;
        }

        public bool ParkCarLot(Car car)
        {
            bool isParkSuccess = true;
            parkedCars.Add(car);
            return isParkSuccess;
        }
    }
}
