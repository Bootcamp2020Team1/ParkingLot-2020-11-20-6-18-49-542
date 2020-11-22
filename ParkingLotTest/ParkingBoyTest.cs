namespace ParkingLotTest
{
    using ParkingLot;
    using ParkingLot.DataModels;
    using Xunit;

    public class ParkingBoyTest
    {
        [Fact]
        public void Test1()
        {
            var class1 = new ParkingBoy();
            Assert.NotNull(class1);
        }
    }
}
