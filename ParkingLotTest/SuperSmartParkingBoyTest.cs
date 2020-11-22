using ParkingLotCLI;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ParkingLotTest
{
    public class SuperSmartParkingBoyTest
    {
        [Fact]
        public void Should__Super_Smart_Parking_Boy_Park_The_Car_To_Mutiple_Parking_Lots_And_Park_To_The_Parking_Lot_Has_Largest_AvaliablePositionRate()
        {
            //given
            var id_1 = Guid.NewGuid();
            var id_2 = Guid.NewGuid();

            var parkingBoy = new SuperSmartParkingBoy(new List<ParkingLot>() { new ParkingLot(id_1, 2), new ParkingLot(id_2, 1) });

            //when
            parkingBoy.Park(new Car("car1"), out _);
            var ticket = parkingBoy.Park(new Car("car2"), out _);

            //then
            Assert.Equal(id_1.ToString(), ticket.ParkingLotID);
        }
    }
}
