using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingService
{
    public class Flightsearchviewmodel
    {
        [Key]
        public int FlightId { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
      //  public decimal? Price { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
