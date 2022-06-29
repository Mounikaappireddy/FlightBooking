using FlightBookingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAdminService
{
    public interface IAirlineRepository
    {
        IEnumerable<AirLineDetail> GetAirLineDetails();
        AirLineDetail GetAirLineDetailsbyId(int AirLineId);

        AirLineDetail RegisterAirline(AirLineDetail airLineDetail);
        AirLineDetail BlockAirline(AirLineDetail airLineDetail);
        //IEnumerable<FlightDetail> GetFlightDetail();
        FlightDetail InventoryAdd(FlightDetail flightDetail);
    }

}
