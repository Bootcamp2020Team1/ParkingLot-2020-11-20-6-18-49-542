using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotCLI
{
    public interface IParkable
    {
        Car Fetch(Ticket ticket, out string errorMessage);
        Ticket Park(Car car, out string errorMessage);
    }
}
