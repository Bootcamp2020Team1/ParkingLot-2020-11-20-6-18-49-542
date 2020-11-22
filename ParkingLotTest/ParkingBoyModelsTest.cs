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
            Ticket ticket = myBoy.Park(new Car("test plate"), myLot);
            Car car = myBoy.Fetch(ticket.TicketNumber, myLot);
            Assert.Equal("test plate", car.Plate);
        }
    }
}
