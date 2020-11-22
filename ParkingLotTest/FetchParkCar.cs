namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class FetchParkCar
    {
        [Fact]
        public void Return_Ticket_When_Park_a_Car()
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

        //[Fact]
        //public void Return_Ticket_When_Park_a_Car()
        //{
        //    //given
        //    var parkingLot = new ParkingLot(10, "p1");
        //    var parkingBoy = new ParkingBoy("b1");
        //    parkingBoy.AddParkingLot(parkingLot);
        //    //when

        //    //then
        //    Assert.NotNull(class1);
        //}
    }
}
