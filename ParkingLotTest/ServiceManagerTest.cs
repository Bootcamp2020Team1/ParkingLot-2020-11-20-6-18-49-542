using ParkingLotCLI;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ParkingLotCLITest
{
    public class ServiceManagerTest
    {
        [Fact]
        public void Should__Manager_Specify_The_Parking_Boy_To_Park_The_Car_Given_The_Parking_Boy_Is_In_ManagementList()
        {
            //given
            var expectedTicket = new Ticket("1234", "N98245");
            var serviceManager = new ServiceManager(new List<ParkingLot>() { new ParkingLot() });
            var parkingBoy = new ParkingBoy(new List<ParkingLot>() { });
            serviceManager.AddParkingBoy(parkingBoy);

            //when
            var ticket = serviceManager.SpecifyParkingBoyToPark(new Car("N98245"), out _);

            //then
            Assert.Equal(expectedTicket.GetType(), ticket.GetType());
        }

        [Fact]
        public void Should__Manager_Specify_The_Parking_Boy_To_Fetch_The_Car_Given_The_Parking_Boy_Is_In_ManagementList()
        {
            //given
            var carType = new Car("acar");
            var serviceManager = new ServiceManager(new List<ParkingLot>() { new ParkingLot() });
            var parkingBoy = new ParkingBoy(new List<ParkingLot>() { });
            serviceManager.AddParkingBoy(parkingBoy);
            var ticket = serviceManager.SpecifyParkingBoyToPark(new Car("N98245"), out _);
            //when
            var car = serviceManager.SpecifyParkingBoyToFetch(ticket, out _);

            //then
            Assert.Equal(carType.GetType(), car.GetType());
        }

        [Fact]
        public void Should_Manager_Park_A_Car_And_Get_Ticket()
        {
            //given
            var expectedTicket = new Ticket("1234", "N98245");

            //when
            var parkingBoy = new ServiceManager(new List<ParkingLot>() { new ParkingLot() });
            var ticket = parkingBoy.Park(new Car("N98245"), out _);

            //then
            Assert.Equal(expectedTicket.GetType(), ticket.GetType());
        }

        [Fact]
        public void Should_Manager_Fetch_A_Car_Using_Ticket()
        {
            //given
            var expectedCar = new Car("N98245");

            //when
            var parkingBoy = new ParkingBoy(new List<ParkingLot>() { new ParkingLot() });
            var ticket = parkingBoy.Park(expectedCar, out _);
            var car = parkingBoy.Fetch(ticket, out _);

            //then
            Assert.Equal(expectedCar.GetType(), car.GetType());
        }

        [Fact]
        public void Should_Manager_Park_The_Car_To_Mutiple_Parking_Lots_Sequentially()
        {
            //given
            var id_1 = Guid.NewGuid();
            var id_2 = Guid.NewGuid();

            var parkingBoy = new ServiceManager(new List<ParkingLot>() { new ParkingLot(id_1, 1), new ParkingLot(id_2, 2) });

            //when
            var ticket = parkingBoy.Park(new Car("car"), out _);

            //then
            Assert.Equal(id_1.ToString(), ticket.ParkingLotID);
        }

        [Fact]
        public void Should__Manager_Park_Car_In_His_Own_Parking_Lot()
        {
            //given
            var parkingBoy = new ServiceManager(new List<ParkingLot>() { new ParkingLot() });

            //when
            var ticket = parkingBoy.Park(new Car("N98245"), out _);

            //then
            Assert.Contains(ticket.ParkingLotID, parkingBoy.IdOfParkingLots);
        }

        [Fact]
        public void Should_Manager_Display_Error_Message_When_Specify_A_Parking_Boy_To_Fetch_Car_Given_Null_Ticket()
        {
            //given
            var parkingBoy = new ParkingBoy(new List<ParkingLot>() { });
            var serviceManager = new ServiceManager(new List<ParkingLot>() { new ParkingLot() });
            serviceManager.AddParkingBoy(parkingBoy);

            //when
            var errorMessage = string.Empty;
            serviceManager.Fetch(null, out errorMessage);

            //then
            Assert.Equal("Please provide your parking ticket.", errorMessage);
        }

        [Fact]
        public void Should_Manager_Display_Error_Message_When_Specify_A_Parking_Boy_To_Fetch_Car_Given_Wrong_Ticket()
        {
            //given
            var parkingBoy = new ParkingBoy(new List<ParkingLot>() { });
            var serviceManager = new ServiceManager(new List<ParkingLot>() { new ParkingLot() });
            serviceManager.AddParkingBoy(parkingBoy);
            var ticket = serviceManager.SpecifyParkingBoyToPark(new Car("N98245"), out _);

            //when
            var errorMessage = string.Empty;
            serviceManager.SpecifyParkingBoyToFetch(new Ticket(ticket.ParkingLotID, "wrong"), out errorMessage);

            //then
            Assert.Equal("Unrecognized parking ticket.", errorMessage);
        }

        [Fact]
        public void Should_Manager_Display_Error_Message_When_The_Parking_Lot_Is_Full()
        {
            //given
            var parkingBoy = new ParkingBoy(new List<ParkingLot>() { });
            var serviceManager = new ServiceManager(new List<ParkingLot>() { new ParkingLot(0) });
            serviceManager.AddParkingBoy(parkingBoy);
            var errorMessage = string.Empty;

            //when
            var ticket = serviceManager.Park(new Car("car"), out errorMessage);

            //then
            Assert.Equal("Not enough position.", errorMessage);
        }
    }
}
