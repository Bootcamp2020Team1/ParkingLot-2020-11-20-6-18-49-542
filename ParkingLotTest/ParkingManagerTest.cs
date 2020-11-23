using System;
using System.Collections.Generic;
using System.Text;
using ParkingLot;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingManagerTest
    {
        [Fact]
        public void Should_Return_ticket_Parking_Manager()
        {
            var parkingLot1 = new ParkingLot.ParkingLot(3, 1);
            var parkingLot2 = new ParkingLot.ParkingLot(4, 2);
            var parkingLotList = new List<ParkingLot.ParkingLot>
            {
                parkingLot1,
                parkingLot2
            };
            var parkingManager = new ParkingManager(parkingLotList);
            parkingManager.AddParkingBoy(new NormalParkingBoy(parkingLotList));
            var ticket0 = parkingManager.ParkACarAndGetTicket("abc123");
            var ticket1 = parkingManager.ParkACarAndGetTicket("abc123");
            var ticket2 = parkingManager.ParkACarAndGetTicket("abc124");
            var expectedTicket = new Ticket("abc124", 1);

            Assert.Equal(expectedTicket.GetParkingLotNumber(), ticket2.GetParkingLotNumber());
        }
    }
}
