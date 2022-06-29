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

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        //    //var connectionstring = configuration.GetConnectionString("LocalConnection");
        //    //optionsBuilder.UseSqlServer(connectionstring);
        //    if(!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=FlightBookings;user id=sa;password=pass@word1");
        //    }
        //}
    }
}
