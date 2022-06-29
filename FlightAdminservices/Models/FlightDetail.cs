using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingService.Models
{
    public class FlightDetail
    {
        [Key]
        public int Id { get; set; }
        public int? FlightId { get; set; }
        public string Airlinename { get; set; }
       
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public decimal? Price { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ReturnDate { get; set; }
       public string ScheduleDays { get; set; }
       
    }
}
