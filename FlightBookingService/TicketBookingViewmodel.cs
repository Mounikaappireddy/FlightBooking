using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingService
{
    public class TicketBookingViewmodel
    {
        [Key]
        public int PassengerId { get; set; }
        public string PsngerFirstName { get; set; }
        public string PsngerLastName { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public string Airlinename { get; set; }
        //   public virtual AirLineDetail AirLine { get; set; }
        public int FlightId { get; set; }
        //  public virtual FlightDetail Flight { get; set; }
        public string ContactId { get; set; }
        public string EmailId { get; set; }
        public string PnrNumber { get; set; }
        public DateTime? OnwardDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string MealOption { get; set; }
        public decimal TotalPrice { get; set; }
        public int IsBooked { get; set; }
        public string DisCoupon { get; set; }
        public string OnwardSeatNo { get; set; }
        public string ReturnSeatNo { get; set; }
    }
}
