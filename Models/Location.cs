using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDonationMicroservice.Models
{
    public class Location
    {
        public string LocationId { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
