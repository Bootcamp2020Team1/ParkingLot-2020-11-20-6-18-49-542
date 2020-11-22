namespace ParkingLotTest
{
    using ParkingLot;
    using ParkingLot.DataModels;
    using Xunit;

    public class ParkingBoyModelsTest
    {
        [Fact]
        public void Should_park_into_parkinglot_and_return_ticket()
        {
            ParkingBoy myBoy = new SimpleParkingBoy();
            Ticket ticket = myBoy.Park(new Car("test plate"), new ParkingLot("MyLot"));
            Assert.Equal("test plate", ticket.Plate);
            Assert.Equal("MyLot", ticket.LotName);
        }

        [Fact]
        public void Should_fetch_corresponding_car_with_ticket()
        {
            ParkingBoy myBoy = new SimpleParkingBoy();
            ParkingLot myLot = new ParkingLot("MyLot");
            Ticket ticket1 = myBoy.Park(new Car("test plate1"), myLot);
            Ticket ticket2 = myBoy.Park(new Car("test plate2"), myLot);
            Ticket ticket3 = myBoy.Park(new Car("test plate3"), myLot);
            Car car1 = myBoy.Fetch(ticket1, myLot);
            Car car3 = myBoy.Fetch(ticket3, myLot);
            Assert.Equal("test plate1", car1.Plate);
            Assert.Equal("test plate3", car3.Plate);
        }
    }
}
