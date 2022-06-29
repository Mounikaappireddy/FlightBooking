using FlightBookingService.Models;
using FlightBookingService.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingService.Controllers
{
    [Route("api/flight/[controller]")]
    [ApiController]
    public class TicketController : Controller
    {
        private readonly FlightBookingContext _flightBookingContext;
        public readonly IDataRepository _dataRepository;
        public TicketController(FlightBookingContext flightBookingContext,IDataRepository dataRepository)
        {
            _flightBookingContext = flightBookingContext;
            _dataRepository = dataRepository;
        }
        [HttpGet("InventoryAdd")]
        public IEnumerable<FlightDetail> Getflightdetails()
        {
            return _flightBookingContext.FlightDetail;
        }
        [HttpGet("searchpnrnumber")]
        public List<PassengerBookedFlight> GetPnrDetails( string pnrnumber)
        {
            List<PassengerBookedFlight> pnrdetails;
            try
            {
                pnrdetails = _dataRepository.GetPnrDetails(pnrnumber);
                if(pnrdetails.FirstOrDefault().IsBooked==1)
                {
                return pnrdetails;
                }
            }

            catch(Exception ex)
            {
                throw ex;
            }
            return pnrdetails;
        }
    }
}
