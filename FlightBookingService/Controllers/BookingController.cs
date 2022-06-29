using AutoMapper;
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
    public class BookingController : Controller
    {
        private readonly FlightBookingContext _bookingcontext;
        public readonly IDataRepository _dataRepository;
        public readonly IMapper _mapper;
        public BookingController(FlightBookingContext bookingcontext, IDataRepository dataRepository, IMapper mapper)
        {
            this._bookingcontext = bookingcontext;
            this._dataRepository = dataRepository;
            _mapper = mapper;
        }
        [HttpGet("InventoryAdd")]
        public IEnumerable<FlightDetail> Getflightdetails()
        {
            return _bookingcontext.FlightDetail;
        }

        [HttpGet("searchdetails")]
        public async Task<ActionResult> SearchFlight(string fromlocation, string tolocation)
        {
           
            var details = (from  f in _bookingcontext.FlightDetail
                           join a in _bookingcontext.AirLineDetail on f.Airlinename equals a.AirlineName
                           where f.FromLocation == fromlocation && f.ToLocation == tolocation && a.IsBlocked == 0
                           select f).ToList();
           if (details != null)
                {
                    return Ok(details);
                }
                return Ok(details);
           
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
        [HttpPost("TicketBooking")]
        public async Task<IActionResult> PostBookingTicket(PassengerBookedFlight passenger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var NewAirLine = _dataRepository.PostBookingTicket(passenger);
            return Ok(NewAirLine);
           
        }
      
        [HttpGet("searchbyemail")]
        public List<PassengerBookedFlight> historyTicketBooking(string emailid)
        {
            List<PassengerBookedFlight> details;
            try
            {   
                details = _dataRepository.historyTicketBooking(emailid);
                if (details.FirstOrDefault().IsBooked == 1)
                {
                    return details;
                }
             }
            catch (Exception ex)
            {
               throw ex;
           }
            return details;
            }

        [HttpDelete("searchpnrnumber")]
        public async Task<IActionResult> CancelTicket( string pnrnumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IQueryable<PassengerBookedFlight> passengerDetail = _bookingcontext.PassengerBookedFlights.Where(a => a.PnrNumber == pnrnumber);
            try
            {
                foreach (var details in passengerDetail)
                {
                    _bookingcontext.PassengerBookedFlights.Remove(details);

                }
                await _bookingcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }

            // if(passengerDetail==null)
            //{
            //    return NotFound();
            //}
            //return Json("Ticket Cancelled successfully for the email id:" + emailId);
            return Ok(passengerDetail);
        }

    }
}
