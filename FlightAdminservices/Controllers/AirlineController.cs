using FlightAdminservices.Models;
using FlightBookingService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAdminService.Controllers
{
    [Route("api/flight/[controller]")]
    [ApiController]
    public class AirlineController : ControllerBase
    {
        private readonly IAirlineRepository _airlineRepository;
        private readonly FlightBookingContext _flightBookingContext;
        public AirlineController(IAirlineRepository airlineRepository, FlightBookingContext flightBookingContext)
        {
            _airlineRepository = airlineRepository;
            _flightBookingContext = flightBookingContext;
        }
        [HttpGet("Get")]
        public IEnumerable<AirLineDetail> GetAirLineDetails()
        {
            var airlines = _airlineRepository.GetAirLineDetails();
            if (airlines.Count() > 0)
            {
               return airlines;
            }
            return airlines;
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetAirlineDetail(string airlinname)
        {
           var airlinedetails= await _flightBookingContext.AirLineDetail.FindAsync(airlinname);
            return Ok(airlinedetails);
        }
        [HttpPost("AddAirLine"), Authorize(Roles = "Admin")]
 
        public async Task<IActionResult> RegisterAirline([FromBody] AirLineDetail airLineDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var NewAirLine = _airlineRepository.RegisterAirline(airLineDetail);
            return Ok(NewAirLine);
            
           
        }
        [HttpDelete("deleteairline")]
        public async Task<IActionResult> Cancelairline(int AirlineId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IQueryable<AirLineDetail> airLineDetails = _flightBookingContext.AirLineDetail.Where(a => a.AirLineId == AirlineId);
            try
            {
                foreach (var details in airLineDetails)
                {
                    _flightBookingContext.AirLineDetail.Remove(details);

                }
                await _flightBookingContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // if(passengerDetail==null)
            //{
            //    return NotFound();
            //}
            //return Json("Ticket Cancelled successfully for the email id:" + emailId);
            return Ok(airLineDetails);
        }
        [HttpPut("BlockAirline")]
        public async Task<IActionResult> BlockAirline([FromBody]AirLineDetail airline)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           var airLineDetails = _flightBookingContext.AirLineDetail.FirstOrDefault(a => a.AirLineId == airline.AirLineId);
            if (airLineDetails != null)
            {
                if (airLineDetails.IsBlocked == 0)
                {
                    airLineDetails.IsBlocked = 1;
                }
                else
                {
                    airLineDetails.IsBlocked = 0;
                }

            }
            await _flightBookingContext.SaveChangesAsync();
            return Ok(airLineDetails);

        }
        //getinventory
        [HttpGet("InventoryAdd")]
        public IEnumerable<FlightDetail> Getflightdetails()
        {
            return _flightBookingContext.FlightDetail;
        }
        //schedule inventory
        [HttpPost("inventoryAdd")]
        public async Task<IActionResult> InventoryAdd([FromBody]FlightDetail flightDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           _flightBookingContext.FlightDetail.Add(flightDetail);
            await _flightBookingContext.SaveChangesAsync();
            return CreatedAtAction("GetAirlineDetail", new { id = flightDetail.Airlinename }, flightDetail);
        }
        [HttpGet]
        public IEnumerable<String> Get()
        {
            return new string[] { "Flightbokkingmounika" };
        }
        //Delete Inventory
        [HttpDelete("inventorydelete")]
        public async Task<IActionResult> DeleteInventory(int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IQueryable<FlightDetail> discountdetail = _flightBookingContext.FlightDetail.Where(a => a.Id == Id);
            try
            {
                foreach (var details in discountdetail)
                {
                    _flightBookingContext.FlightDetail.Remove(details);

                }
                await _flightBookingContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // if(passengerDetail==null)
            //{
            //    return NotFound();
            //}
            //return Json("Ticket Cancelled successfully for the email id:" + emailId);
            return Ok(discountdetail);
        }

        //Update Inventory
        [HttpPut("inventoryAdd/{Id}")]
        public async Task<IActionResult> PutInventoryAdd([FromRoute] int Id, [FromBody] FlightDetail flightDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (Id != Convert.ToInt32(flightDetail.Airlinename))
            {
                return BadRequest(ModelState);
            }
            _flightBookingContext.Entry(flightDetail).State = EntityState.Modified;

            try
            {
                await _flightBookingContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightDetailExists(Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }


        [HttpGet("Getdiscountcoupon")]
        public async Task<IActionResult> GetDiscountDetail(string CouponNo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           var discount = _flightBookingContext.DiscountDetails.Where(a => a.DisCoupon == CouponNo).FirstOrDefault();
            //var discountDetail = from a in discount
            //                     select new
            //                     {
            //                         a.DiscountNo,
            //                         a.DisCoupon,
            //                         a.Price
            //                     };
            if (discount == null)
            {
                return NotFound();
            }
            return Ok(discount);
        }

        [HttpGet("GetDiscount")]
        public IEnumerable<DiscountDetails> GetAllDiscountDetail()
        {
            return _flightBookingContext.DiscountDetails;
        }

        //Add Discount
        [HttpPost("Discount")]
        public async Task<IActionResult> AddDiscount([FromBody] DiscountDetails discount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _flightBookingContext.DiscountDetails.Add(discount);
            await _flightBookingContext.SaveChangesAsync();

            return Ok(discount);
        }

        [HttpDelete("searchbydiscountno")]
        public async Task<IActionResult> CancelDiscount(int DiscountNo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IQueryable<DiscountDetails> discountdetail = _flightBookingContext.DiscountDetails.Where(a => a.DiscountNo == DiscountNo);
            try
            {
                foreach (var details in discountdetail)
                {
                    _flightBookingContext.DiscountDetails.Remove(details);

                }
                await _flightBookingContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // if(passengerDetail==null)
            //{
            //    return NotFound();
            //}
            //return Json("Ticket Cancelled successfully for the email id:" + emailId);
            return Ok(discountdetail);
        }

        private bool FlightDetailExists(int Id)
        {
            return _flightBookingContext.FlightDetail.Any(e => e.FlightId == Id);
        }
    }
}
