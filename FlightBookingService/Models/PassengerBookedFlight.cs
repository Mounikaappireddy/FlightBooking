using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingService.Models
{
    public class PassengerBookedFlight
    {

        [Key]
        public int PassengerId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public string ScheduleDays { get; set; }
        public int? age { get; set; }
      public string Airlinename { get; set; }

        public int? FlightId { get; set; }


        public string contactNo { get; set; }
        public string emailId { get; set; }
        public string PnrNumber { get; set; }
        public DateTime? OnwardDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string MealOption { get; set; }
        public decimal? Price { get; set; }
        public decimal? TotalPrice { get; set; }
        public int IsBooked { get; set; }
        public string DisCoupon { get; set; }
        public string onwardseat { get; set; }
        public string returnseat { get; set; }
		  public string FromLocation { get; set; }
        public string ToLocation { get; set; }

    }
}
