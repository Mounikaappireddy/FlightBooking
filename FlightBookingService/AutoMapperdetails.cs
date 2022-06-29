using AutoMapper;
using FlightBookingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingService
{
    public class AutoMapperdetails:Profile
    {
        public AutoMapperdetails()
        {
            CreateMap<Flightsearchviewmodel, FlightDetail>();
        }
    }
}
