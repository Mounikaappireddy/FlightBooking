using LoginService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LoginService
{
    public class FlightBookingDbContext:DbContext
    {
        public FlightBookingDbContext(DbContextOptions<FlightBookingDbContext>options):base(options)
        {

        }
        //public virtual DbSet<FlightDetail> FlightDetail { get; set; }
        //public virtual DbSet<Bookedseat> Bookedseat { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        //public virtual DbSet<AirLineDetail> AirLineDetail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var connectionstring = configuration.GetConnectionString("LocalConnection");
            optionsBuilder.UseSqlServer(connectionstring);
        }
    }
}
