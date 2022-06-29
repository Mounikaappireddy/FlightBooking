using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingService.Models
{
    public class AirLineDetail
    {
        [Key]
        public int AirLineId { get; set; }
        public string AirlineName { get; set; }

        public string Logo { get; set; }

        public string ContactNo { get; set; }

        public string ContactAddress { get; set; }

        public int? IsBlocked { get; set; }
       //public virtual ICollection<PassengerBookedFlight> PassengerBookedFlights { get; set; }
      // public virtual ICollection<FlightDetail> FlightDetails { get; set; }
    }
}
