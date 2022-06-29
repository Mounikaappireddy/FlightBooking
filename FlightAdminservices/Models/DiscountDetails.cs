using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAdminservices.Models
{
    public partial class DiscountDetails
    {
        [Key]
      
        public int DiscountNo { get; set; }
        public string  DisCoupon { get; set; }
        public decimal? Price { get; set; }
    }
}
