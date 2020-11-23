using ParkingLot;
using ParkingLot.DataModels;
using ParkingLotTest.Utils;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingBoyTest
    {
        private readonly ParkingBoy myBoy;
        public ParkingBoyTest()
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

        [Fact]
        public void Should_simpleBoy_park_per_sequence()
        {
            string parkMessage = myBoy.TryPark(new Car("test plate1"), out Ticket ticket1);
            myBoy.TryPark(new Car("test plate2"), out Ticket ticket2);
            myBoy.TryPark(new Car("test plate3"), out Ticket ticket3);
            myBoy.TryPark(new Car("test plate4"), out Ticket ticket4);

            Assert.Equal(string.Empty, parkMessage);
            Assert.Equal("MyLot2", ticket4.LotName);

            string fetchMessage = myBoy.TryFetch(ticket1, out Car car1);

            Assert.Equal("test plate1", car1.Plate);
        }

        [Fact]
        public void Should_smartBoy_park_per_availabe_positions()
        {
            var mySmartBoy = new SmartParkingBoy(DataLoader.GetParkingLots());

            mySmartBoy.TryPark(new Car("test plate1"), out Ticket ticket1);
            mySmartBoy.TryPark(new Car("test plate2"), out Ticket ticket2);
            mySmartBoy.TryPark(new Car("test plate3"), out Ticket ticket3);
            mySmartBoy.TryPark(new Car("test plate4"), out Ticket ticket4);

            Assert.Equal("MyLot2", ticket1.LotName);
            Assert.Equal("MyLot2", ticket2.LotName);
            Assert.Equal("MyLot2", ticket3.LotName);
            Assert.Equal("MyLot2", ticket4.LotName);
        }

        [Fact]
        public void Should_superSmartBoy_park_per_availabe_ratio()
        {
            var mySuperBoy = new SuperSmartParkingBoy(DataLoader.GetParkingLots());

            mySuperBoy.TryPark(new Car("test plate1"), out Ticket ticket1);
            mySuperBoy.TryPark(new Car("test plate2"), out Ticket ticket2);
            mySuperBoy.TryPark(new Car("test plate3"), out Ticket ticket3);
            mySuperBoy.TryPark(new Car("test plate4"), out Ticket ticket4);

            Assert.Equal("MyLot2", ticket1.LotName);
            Assert.Equal("MyLot1", ticket2.LotName);
            Assert.Equal("MyLot2", ticket3.LotName);
            Assert.Equal("MyLot2", ticket4.LotName);
        }
    }
}
