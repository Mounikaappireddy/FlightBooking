using FlightBookingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAdminService
{
    public class SqlAirlineRepository : IAirlineRepository
    {
        private readonly FlightBookingContext _flightBookingContext;
        public SqlAirlineRepository(FlightBookingContext flightBookingContext)
        {
            _flightBookingContext = flightBookingContext;
        }
        public IEnumerable<AirLineDetail> GetAirLineDetails()
        {
            return _flightBookingContext.AirLineDetail;
        }
        public AirLineDetail GetAirLineDetailsbyId(int AirLineId)
        {
            return _flightBookingContext.AirLineDetail.Find(AirLineId);
        }
        public AirLineDetail RegisterAirline(AirLineDetail airLineDetail)
        {

            _flightBookingContext.AirLineDetail.Add(airLineDetail);
            _flightBookingContext.SaveChanges();
            return airLineDetail;
        }
        public AirLineDetail BlockAirline(AirLineDetail airLineDetail)
        {
            _flightBookingContext.SaveChanges();
            return airLineDetail;
        }
        //public IEnumerable<FlightDetail> GetFlightDetail()
        //{
        //    return _flightBookingContext.FlightDetail;

        //}
        public FlightDetail InventoryAdd(FlightDetail flightDetail)
        {
            try { 
            _flightBookingContext.FlightDetail.Add(flightDetail);
            _flightBookingContext.SaveChanges();
            return flightDetail;
            }
            catch(Exception ex)
            {
                return default;
            }

        }
    }

}
