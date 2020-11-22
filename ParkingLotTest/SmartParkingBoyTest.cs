using ParkingLotCLI;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ParkingLotTest
{
    public class SmartParkingBoyTest
    {
        [Fact]
        public void Should_Smart_Parking_Boy_Park_The_Car_To_Mutiple_Parking_Lots_And_Park_To_The_Parking_Lot_Has_More_Avaliable_Spaces()
        {
            //given
            var id_1 = Guid.NewGuid();
            var id_2 = Guid.NewGuid();

            var parkingBoy = new SmartParkingBoy(new List<ParkingLot>() { new ParkingLot(id_1, 1), new ParkingLot(id_2, 2) });

            //when
            var ticket = parkingBoy.Park(new Car("car"), out _);

            //then
            Assert.Equal(id_2.ToString(), ticket.ParkingLotID);
        }
    }
}
