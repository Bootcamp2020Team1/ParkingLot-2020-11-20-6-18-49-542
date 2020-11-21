using ParkingLotCLI;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingBoyTest
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
    }
}
