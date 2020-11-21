using ParkingLotCLI;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingLotCLITest
    {
        [Fact]
        public void Should_Parking_Boy_Park_A_Car_And_Get_Ticket()
        {
            //given
            var expectedTicket = new Ticket("1234", "N98245");

            //when
            var parkingBoy = new ParkingBoy(new ParkingLot());
            var ticket = parkingBoy.Park(new Car("N98245"));

            //then
            Assert.Equal(expectedTicket.GetType(), ticket.GetType());
        }

        [Fact]
        public void Should_Parking_Boy_Fetch_A_Car_Using_Ticket()
        {
            //given
            var expectedCar = new Car("N98245");

            //when
            var parkingBoy = new ParkingBoy(new ParkingLot());
            var ticket = parkingBoy.Park(expectedCar);
            var car = parkingBoy.Fetch(ticket);

            //then
            Assert.Equal(expectedCar.GetType(), car.GetType());
        }

        [Fact]
        public void Should_Parking_Boy_Park_Mutiple_Cars_And_Fetch_The_Right_Car_Using_Ticket()
        {
            //given
            var expectedCar = new Car("N98245");

            //when
            var parkingBoy = new ParkingBoy(new ParkingLot());
            var carList = new List<Car>() { new Car("car1"), new Car("car2"), new Car("car3") };
            carList.ForEach(car => parkingBoy.Park(car));
            var ticket = parkingBoy.Park(expectedCar);
            var car = parkingBoy.Fetch(ticket);

            //then
            Assert.Equal(expectedCar, car);
        }

        [Fact]
        public void Should_Parking_Boy_Fetch_No_Cars_Given_The_Wrong_Ticket()
        {
            //given
            var expectedCar = new Car("N98245");

            //when
            var parkingBoy = new ParkingBoy(new ParkingLot());
            var ticket = parkingBoy.Park(expectedCar);
            var wrongTicket = new Ticket("123", "wrongNumber");
            var car = parkingBoy.Fetch(wrongTicket);

            //then
            Assert.Null(car);
        }

        [Fact]
        public void Should_Parking_Boy_Fetch_No_Cars_Given_The_No_Ticket()
        {
            //given
            var expectedCar = new Car("N98245");

            //when
            var parkingBoy = new ParkingBoy(new ParkingLot());
            var car = parkingBoy.Fetch(null);

            //then
            Assert.Null(car);
        }

        [Fact]
        public void Should_Parking_Boy_Fetch_No_Car_Given_The_Ticket_Has_Been_Used()
        {
            //given
            var parkedCar = new Car("N98245");
            var parkingBoy = new ParkingBoy(new ParkingLot());
            var ticket = parkingBoy.Park(parkedCar);
            parkingBoy.Fetch(ticket);

            //when
            var car = parkingBoy.Fetch(ticket);

            //then
            Assert.Null(car);
        }

        [Fact]
        public void Should_Park_No_Car_Given_Parking_Lot_Has_No_Position()
        {
            //given
            var parkedCar = new Car("N98245");
            var parkingBoy = new ParkingBoy(new ParkingLot(1));
            parkingBoy.Park(parkedCar);

            //when
            var newCar = new Car("A982453");
            var newTicket = parkingBoy.Park(newCar);

            //then
            Assert.Null(newTicket);
        }

        [Fact]
        public void Should_The_Defualt_Capacity_Of_Parking_Lot_Is_10()
        {
            //when
            var parkingLot = new ParkingLot();

            //then
            Assert.Equal(10, parkingLot.Capacity);
        }
    }
}
