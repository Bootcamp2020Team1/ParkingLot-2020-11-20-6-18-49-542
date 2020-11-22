namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class FetchParkCarTest
    {
        [Fact]
        public void Should_GetBoysParkingLots_return_ParkingLot_When_Add_ParkingLot_To_ParkingBoy()
        {
            //given
            var parkingLot = new ParkingLot(10, "p1");
            var parkingBoy = new ParkingBoy("b1");
            parkingBoy.AddParkingLot(parkingLot);
            //when
            ParkingLot actual = parkingBoy.GetBoysParkingLots()[0];
            var expexted = parkingLot;
            //then
            Assert.Equal(actual.Id, expexted.Id);
        }

        [Fact]
        public void Should_Return_Ticket_When_Park_Car()
        {
            //given
            var parkingLot = new ParkingLot(10, "p1");
            var parkingBoy = new ParkingBoy("b1");
            parkingBoy.AddParkingLot(parkingLot);
            //when
            var actual = parkingBoy.ParkCarBoy("c1");
            var expectedCarId = "c1";
            var expectedBoy = "b1";
            var expectedLot = "p1";
            //then
            Assert.Equal(actual.CarId, expectedCarId);
            Assert.Equal(actual.ParkingBoyId, expectedBoy);
            Assert.Equal(actual.ParkingLotId, expectedLot);
        }

        [Fact]
        public void Should_Return_CarId_When_Fetch_Car()
        {
            //given
            var parkingLot = new ParkingLot(10, "p1");
            var parkingBoy = new ParkingBoy("b1");
            parkingBoy.AddParkingLot(parkingLot);
            var ticket = parkingBoy.ParkCarBoy("c1");
            //when
            var actual = parkingBoy.FetchCarBoy(ticket);
            var expectedCarId = "c1";
            //then
            Assert.Equal(actual, expectedCarId);
        }
    }
}
