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
            var car = new Car("c1");
            var customer = new Customer("customer1");
            //when
            var actual = customer.ParkCarCustomer(car, parkingBoy);
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
            var car = new Car("c1");
            var customer = new Customer("customer1");
            var ticket = customer.ParkCarCustomer(car, parkingBoy);
            //when
            var actual = customer.FetchCarCustomer(ticket, parkingBoy);
            var expected = "c1";
            //then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_Return_UsedMessage_When_Fetch_Car_With_Ticket_ParkingBoy_not_provided()
        {
            //given
            var parkingLot = new ParkingLot(10, "p1");
            var parkingBoy = new ParkingBoy("b1");
            parkingBoy.AddParkingLot(parkingLot);
            var car = new Car("c1");
            var customer = new Customer("customer1");

            var ticket = customer.ParkCarCustomer(car, parkingBoy);
            var fetchedCar = customer.FetchCarCustomer(ticket, parkingBoy);
            //when
            var actual = customer.FetchCarCustomer(ticket, parkingBoy);
            var expected = "The ticket has been used.";
            //then
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void Should_Return_WrongBoyMessage_When_Fetch_Car_With_Ticket_ParkingBoy_not_provided()
        {
            //given
            var parkingLot = new ParkingLot(10, "p1");
            var parkingBoy1 = new ParkingBoy("b1");
            var parkingBoy2 = new ParkingBoy("b2");
            parkingBoy1.AddParkingLot(parkingLot);
            parkingBoy2.AddParkingLot(parkingLot);
            var car = new Car("c1");
            var customer = new Customer("customer1");
            var ticket = customer.ParkCarCustomer(car, parkingBoy1);

            //when
            var actual = customer.FetchCarCustomer(ticket, parkingBoy2);
            var expected = "The ticket is not provided by the parking boy.";
            //then
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void Should_Return_True_When_Ticket_is_SetAsUsed()
        {
            //given
            var parkingLot = new ParkingLot(10, "p1");
            var parkingBoy = new ParkingBoy("b1");
            parkingBoy.AddParkingLot(parkingLot);
            var car = new Car("c1");
            var customer = new Customer("customer1");
            var ticket = customer.ParkCarCustomer(car, parkingBoy);
            var newt = ticket;
            ticket.SetTicketAsUsed();

            //when
            //var expected = "The ticket is not provided by the parking boy.";
            //then
            Assert.Equal(true, newt.IsUsed);
            //customer.FetchCarCustomer(ticket, parkingBoy);
            //Assert.Equal(true, ticket.IsUsed);
        }

        [Fact]
        public void Should_Park_To_ParkingLot_With_More_LeftPosition()
        {
            //given
            var parkingLot1 = new ParkingLot(6, "p1");
            var parkingLot2 = new ParkingLot(10, "p2");
            var parkingBoy = new SmartParkingBoy("b1");
            parkingBoy.AddParkingLot(parkingLot1);
            parkingBoy.AddParkingLot(parkingLot2);
            var car = new Car("c1");
            var customer = new Customer("customer1");
            var ticket = customer.ParkCarCustomer(car, parkingBoy);
            //when
            var actual1 = parkingLot1.LeftPosition;
            var actual2 = parkingLot2.LeftPosition;
            var expected = 9;
            //then
            //Assert.Equal(expected, actual1);
            Assert.Equal(9, actual2);
            //customer.FetchCarCustomer(ticket, parkingBoy);
            //Assert.Equal(true, ticket.IsUsed);
        }
    }
}
