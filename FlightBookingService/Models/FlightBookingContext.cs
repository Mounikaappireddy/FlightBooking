using FlightAdminservices.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingService.Models
{
    public class FlightBookingContext:DbContext
    {
         public FlightBookingContext(DbContextOptions<FlightBookingContext>options):base(options)
        {

        }
        public virtual DbSet<AirLineDetail> AirLineDetail { get; set; }
       public virtual DbSet<FlightDetail> FlightDetail { get; set; }
        public virtual DbSet<PassengerBookedFlight> PassengerBookedFlights { get; set; }
        public virtual DbSet<DiscountDetails> DiscountDetails { get; set; }
    }
}
