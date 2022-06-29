using FlightBookingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingService.Repository
{
    public interface IDataRepository
    {
      // FlightDetail SearchFlight(FlightDetail flightdetails);
       PassengerBookedFlight PostBookingTicket(PassengerBookedFlight passengerBooked);
        //  object PostBookingSeat(BookedSeat bookedseat);
        // object historyTicketBooking(string emailId);
        //object historyBooking();
        List<PassengerBookedFlight> historyTicketBooking(string emailid);
        List<PassengerBookedFlight> GetPnrDetails(string pnrNumber);
       FlightDetail SearchFlight(string fromlocation);

    }
}
