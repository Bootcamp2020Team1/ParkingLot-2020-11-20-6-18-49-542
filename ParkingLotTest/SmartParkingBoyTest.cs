using System;
using System.Collections.Generic;
using System.Text;
using ParkingLot;
using Xunit;

namespace ParkingLotTest
{
    public class SmartParkingBoyTest
    {
        [Fact]
        public void Should_Return_ticket_Smart_Parking_Boy()
        {
            //given
            var parkingLot1 = new ParkingLot.ParkingLot(1, 3);
            var parkingLot2 = new ParkingLot.ParkingLot(2, 4);
            var parkingLotList = new List<ParkingLot.ParkingLot>
            {
                parkingLot1,
                parkingLot2
            };
            //when
            var parkingBoy = new SmartParkingBoy(parkingLotList);
            var ticket = parkingBoy.ParkACarAndGetTicket("abc123");
            var expectedTicket = new Ticket("abc123", 2);
            //then
            Assert.Equal(expectedTicket.GetParkingLotNumber(), ticket.GetParkingLotNumber());
        }
    }
}
