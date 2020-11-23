using ParkingLot;
using ParkingLot.DataModels;
using ParkingLotTest.Utils;
using Xunit;
using System.Collections.Generic;

namespace ParkingLotTest
{
    public class ManagerTest
    {
        [Fact]
        public void Should_manager_add_boy_to_list()
        {
            var manager = new Manager(DataLoader.GetParkingLots(), new List<ParkingBoy>());

            manager.AddParkingBoy(new ParkingBoy(new Lot[] { }));

            Assert.Equal(1, manager.ManagementListCount);
            Assert.Equal(DataLoader.GetParkingLots().Length, manager.AppointBoy().ParkingLots.Length);
        }
    }
}
