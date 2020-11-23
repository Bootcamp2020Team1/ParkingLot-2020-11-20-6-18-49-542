using System.Collections.Generic;

namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class ParkingBoyTest
    {
        [Fact]
        public void Should_Return_ticket()
        {
            var parkingLot = new ParkingLot(1, 4);
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
            var parkingLot = new ParkingLot(1, 4);
            var parkingLotList = new List<ParkingLot>();
            parkingLotList.Add(parkingLot);
            var parkingBoy = new ParkingBoy(parkingLotList);
            var ticket = parkingBoy.ParkACarAndGetTicket("abc123");
            var returnMessage = parkingBoy.FetchACarWithTicket(ticket);

            Assert.Equal("Your car abc123 in parking lot number 1 is fetched", returnMessage);
        }

        [Theory]
        [InlineData("abc123", 1)]
        [InlineData("abc123", 1)]
        public void Should_Not_Fetch_Car_And_Return_Error_Message(string license, int parkingLotNumber)
        {
            var parkingLot = new ParkingLot(1, 4);
            var parkingLotList = new List<ParkingLot>();
            parkingLotList.Add(parkingLot);
            var parkingBoy = new ParkingBoy(parkingLotList);
            var ticket = parkingBoy.ParkACarAndGetTicket("abc123");
            parkingBoy.FetchACarWithTicket(new Ticket(license, parkingLotNumber));
            var returnMessage = parkingBoy.FetchACarWithTicket(new Ticket(license, parkingLotNumber));

            Assert.Equal("Unrecognized parking ticket.", returnMessage);
        }

        [Fact]
        public void Should_Return_ticket_Normal_Parking_Boy()
        {
            var parkingLot1 = new ParkingLot(1, 1);
            var parkingLot2 = new ParkingLot(2, 4);
            var parkingLotList = new List<ParkingLot>();
            parkingLotList.Add(parkingLot1);
            parkingLotList.Add(parkingLot2);
            var parkingBoy = new NormalParkingBoy(parkingLotList);
            var ticket0 = parkingBoy.ParkACarAndGetTicket("abc123");
            var ticket = parkingBoy.ParkACarAndGetTicket("abc123");
            var expectedTicket = new Ticket("abc123", 2);

            Assert.Equal(expectedTicket.GetParkingLotNumber(), ticket.GetParkingLotNumber());
        }

        [Fact]
        public void Should_Create_ParkingBoy_Without_Parking_Lot()
        {
            var parkingBoy = new ParkingBoy(null);
            Assert.NotNull(parkingBoy);
        }
    }
}
