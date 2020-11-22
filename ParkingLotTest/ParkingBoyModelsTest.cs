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
            Ticket ticket = myBoy.Park(new Car("test plate"), new ParkingLot());
            Assert.NotNull(ticket);
        }
    }
}
