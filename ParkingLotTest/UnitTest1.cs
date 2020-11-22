using System.Collections.Generic;

namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class UnitTest1
    {
        [Fact]
        public void Should_Return_ticket()
        {
            var parkingLot = new ParkingLot(4, 1);
            var parkingLotList = new List<ParkingLot>();
            parkingLotList.Add(parkingLot);
            var parkingBoy = new ParkingBoy(parkingLotList);
            var ticket = parkingBoy.ParkACarAndGetTicket("abc123");
            var expectedTicket = new Ticket("abc123", 1);

            Assert.Equal(expectedTicket.GetParkingLotNumber(), ticket.GetParkingLotNumber());
        }

        [Theory]
        [InlineData("12345")]
        [InlineData("abcdefg")]
        public void Should_Return_Error_Message(string license)
        {
            var parkingLot = new ParkingLot(4, 1);
            var parkingLotList = new List<ParkingLot>();
            parkingLotList.Add(parkingLot);
            var parkingBoy = new ParkingBoy(parkingLotList);
            var ticket = parkingBoy.ParkACarAndGetTicket(license);

            Assert.Null(ticket);
        }

        [Fact]
        public void Should_Fetch_Car_And_Return_Message()
        {
            var parkingLot = new ParkingLot(4, 1);
            var parkingLotList = new List<ParkingLot>();
            parkingLotList.Add(parkingLot);
            var parkingBoy = new ParkingBoy(parkingLotList);
            var ticket = parkingBoy.ParkACarAndGetTicket("abc123");
            var returnMessage = parkingBoy.FetchACarWithTicket("abc123", 1);

            Assert.Equal("Your car abc123 in parking lot number 1 is fetched", returnMessage);
        }
    }
}
