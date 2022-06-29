using FlightBookingService.Models;
using FlightBookingService.Repository;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace FlightBookingService
{
    public class SqlTicketBooking : IDataRepository
    {
        private readonly FlightBookingContext _flightBookingContext;
        public SqlTicketBooking(FlightBookingContext flightBookingContext)
        {
            _flightBookingContext = flightBookingContext;
        }
        //public  List<FlightDetail> SearchFlight(FlightDetail flightdetails)
        //{
        //    var predicate = PredicateBuilder.New<FlightDetail>();
        //    if (!string.IsNullOrEmpty(flightdetails.FromLocation))
        //    {
        //        predicate = predicate.And(e => e.FromLocation==flightdetails.FromLocation);
        //    }
        //    if (!string.IsNullOrEmpty(flightdetails.ToLocation))
        //    {
        //        predicate = predicate.And(e => e.ToLocation == flightdetails.ToLocation);
        //    }

        //    var result = _flightBookingContext.FlightDetail.Where(predicate).ToList();

        //    return result;
        //}
        public FlightDetail SearchFlight(string fromlocation)
        {
            var user = _flightBookingContext.FlightDetail.SingleOrDefault(x => x.FromLocation == fromlocation);
            return user;
        }
        public PassengerBookedFlight PostBookingTicket(PassengerBookedFlight passengerBooked)
        {
            try
            {
                Random random = new Random();
                int num = random.Next();
                passengerBooked.PnrNumber = "PNR" + num;
                passengerBooked.IsBooked = 1;
                _flightBookingContext.PassengerBookedFlights.Add(passengerBooked);
                _flightBookingContext.SaveChanges();
                return passengerBooked;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
       
        public List<PassengerBookedFlight> historyTicketBooking(string emailid)
        {
            return _flightBookingContext.PassengerBookedFlights.Where(a => a.emailId == emailid).ToList();
        }
        public List<PassengerBookedFlight> GetPnrDetails(string pnrnumber)
        {
            return _flightBookingContext.PassengerBookedFlights.Where(a => a.PnrNumber == pnrnumber).ToList();
           
        }
    }
}
