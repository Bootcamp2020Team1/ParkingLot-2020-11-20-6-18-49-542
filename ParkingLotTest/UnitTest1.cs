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

            Assert.Equal("Your car abc123 have been parked to parking lot number 1", ticket);
        }
    }
}
