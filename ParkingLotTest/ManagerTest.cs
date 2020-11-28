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

        [Fact]
        public void Should_appoint_boy_to_park_and_fetch()
        {
            var manager = new Manager(DataLoader.GetParkingLots(), new List<ParkingBoy>());
            manager.AddParkingBoy(new ParkingBoy(new Lot[] { }));
            var myBoy = manager.AppointBoy();

            myBoy.TryPark(new Car("test plate1"), out Ticket ticket1);
            myBoy.TryPark(new Car("test plate2"), out Ticket ticket2);
            manager.TryPark(new Car("test plate3"), out Ticket ticket3);

            Assert.Equal("MyLot1", ticket1.LotName);
            Assert.Equal("MyLot1", ticket2.LotName);
            Assert.Equal("MyLot1", ticket3.LotName);

            myBoy.TryFetch(ticket1, out Car car1);
            myBoy.TryFetch(ticket2, out Car car2);
            manager.TryFetch(ticket3, out Car car3);

            Assert.Equal("test plate1", car1.Plate);
            Assert.Equal("test plate2", car2.Plate);
            Assert.Equal("test plate3", car3.Plate);
        }
    }
}
