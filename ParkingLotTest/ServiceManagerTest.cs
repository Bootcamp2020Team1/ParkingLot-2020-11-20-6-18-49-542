using ParkingLotCLI;
using System;
using System.Collections.Generic;
using Xunit;

namespace ParkingLotCLITest
{
    public class ServiceManagerTest
    {
        [Fact]
        public void Should__Manager_Specify_The_Parking_Boy_To_Park_The_Car_Given_The_Parking_Boy_Is_In_ManagementList()
        {
            //given
            var expectedTicket = new Ticket("N98245");
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
            var expectedTicket = new Ticket("N98245");

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
            var parkingLot1 = new ParkingLot(1);
            var parkingBoy = new ServiceManager(new List<ParkingLot>() { parkingLot1, new ParkingLot(2) });

            //when
            var ticket = parkingBoy.Park(new Car("car"), out _);

            //then
            Assert.Contains(ticket.TicketNumber, parkingLot1.Tickets);
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
            serviceManager.SpecifyParkingBoyToFetch(new Ticket("wrong"), out errorMessage);

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

        [Fact]
        public void Should_Manager_Remove_Parking_Boy_Given_Parking_Boy_Existed()
        {
            //given
            var parkingBoy = new ParkingBoy(new List<ParkingLot>() { });
            var serviceManager = new ServiceManager(new List<ParkingLot>() { new ParkingLot(0) });
            serviceManager.AddParkingBoy(parkingBoy);

            //when
            var deleteResult = serviceManager.RemoveParkingBoy(parkingBoy);

            //then
            Assert.True(deleteResult);
        }

        [Fact]
        public void Should_Return_True_Given_Parking_Lot_Exist_When_Remove_ParkingLot()
        {
            //given
            var parkingLot = new ParkingLot();
            var parkingBoy = new ServiceManager(new List<ParkingLot>() { parkingLot });

            //when
            var result = parkingBoy.RemoveParkingLot(parkingLot);

            //then
            Assert.True(result);
        }

        [Fact]
        public void Should_Return_False_Given_Parking_Lot_Not_Exist_When_Remove_ParkingLot()
        {
            //given
            var parkingLot = new ParkingLot();
            var parkingBoy = new ServiceManager(new List<ParkingLot>() { });

            //when
            var result = parkingBoy.RemoveParkingLot(parkingLot);

            //then
            Assert.False(result);
        }

        [Fact]
        public void Should_Remove_Parking_Lot_Given_Parking_Lot_Exist_When_Remove_ParkingLot()
        {
            //given
            var parkingLot = new ParkingLot();
            var parkingBoy = new ServiceManager(new List<ParkingLot>() { parkingLot });

            //when
            var result = parkingBoy.RemoveParkingLot(parkingLot);

            //then
            Assert.Equal(0, parkingBoy.ParkingLotsCount);
        }
    }
}
