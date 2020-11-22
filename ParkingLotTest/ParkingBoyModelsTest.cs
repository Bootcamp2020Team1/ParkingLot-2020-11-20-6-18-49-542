namespace ParkingLotTest
{
    using ParkingLot;
    using ParkingLot.DataModels;
    using Utils;
    using Xunit;

    public class ParkingBoyModelsTest
    {
        private ParkingBoy myBoy;
        public ParkingBoyModelsTest()
        {
            myBoy = new ParkingBoy(DataLoader.GetParkingLots());
        }

        [Fact]
        public void Should_park_into_parkinglot_and_return_ticket()
        {
            string errMessage = myBoy.TryParkToSpecificLot(new Car("test plate"), new Lot("MyLot"), out Ticket ticket);

            Assert.Equal("test plate", ticket.Plate);
            Assert.Equal("MyLot", ticket.LotName);
            Assert.Equal(string.Empty, errMessage);
        }

        [Fact]
        public void Should_fetch_corresponding_car_with_ticket()
        {
            Lot myLot = new Lot("MyLot");

            string parkErrMessage1 = myBoy.TryParkToSpecificLot(new Car("test plate1"), myLot, out Ticket ticket1);
            string parkErrMessage2 = myBoy.TryParkToSpecificLot(new Car("test plate2"), myLot, out Ticket ticket2);
            string parkErrMessage3 = myBoy.TryParkToSpecificLot(new Car("test plate3"), myLot, out Ticket ticket3);
            string fetchErrMessage1 = myBoy.TryFetchFromSpecificLot(ticket1, myLot, out Car car1);
            string fetchErrMessage3 = myBoy.TryFetchFromSpecificLot(ticket3, myLot, out Car car3);

            Assert.Equal("test plate1", car1.Plate);
            Assert.Equal("test plate3", car3.Plate);
            Assert.Equal(string.Empty, parkErrMessage1);
            Assert.Equal(string.Empty, parkErrMessage2);
            Assert.Equal(string.Empty, parkErrMessage3);
            Assert.Equal(string.Empty, fetchErrMessage1);
            Assert.Equal(string.Empty, fetchErrMessage3);
        }

        [Fact]
        public void Should_return_error_when_parkinglot_is_full()
        {
            Lot myLot = new Lot("MyLot", 1);

            myBoy.TryParkToSpecificLot(new Car("test plate1"), myLot, out Ticket ticket1);
            string errMessage = myBoy.TryParkToSpecificLot(new Car("test plate2"), myLot, out Ticket ticket2);

            Assert.Equal("test plate1", ticket1.Plate);
            Assert.Equal("MyLot", ticket1.LotName);
            Assert.Equal("Not enough positions.", errMessage);
            Assert.Null(ticket2);
        }

        [Fact]
        public void Should_return_error_message_with_wrong_ticket()
        {
            Lot myLot = new Lot("MyLot");

            myBoy.TryParkToSpecificLot(new Car("test plate1"), myLot, out Ticket ticket1);
            myBoy.TryParkToSpecificLot(new Car("test plate2"), myLot, out Ticket ticket2);
            myBoy.TryParkToSpecificLot(new Car("test plate3"), myLot, out Ticket ticket3);
            string fetchErrMessage1 = myBoy.TryFetchFromSpecificLot(new Ticket("wrong plate", "MyLot"), myLot, out Car car1);
            string fetchErrMessage2 = myBoy.TryFetchFromSpecificLot(null, myLot, out Car car2);

            Assert.Equal("Unrecognized parking ticket.", fetchErrMessage1);
            Assert.Null(car1);
            Assert.Equal("Please provide your parking ticket.", fetchErrMessage2);
            Assert.Null(car2);
        }

        [Fact]
        public void Should_return_used_with_used_ticket()
        {
            Lot myLot = new Lot("MyLot");

            myBoy.TryParkToSpecificLot(new Car("test plate1"), myLot, out Ticket ticket1);
            myBoy.TryFetchFromSpecificLot(ticket1, myLot, out Car car1);
            string fetchErrMessage2 = myBoy.TryFetchFromSpecificLot(ticket1, myLot, out Car car2);

            Assert.Equal("Unrecognized parking ticket.", fetchErrMessage2);
            Assert.Null(car2);
        }
    }
}
