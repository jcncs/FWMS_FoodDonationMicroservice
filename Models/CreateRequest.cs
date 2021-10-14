using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDonationMicroservice.Models
{ 
    public class CreateRequest
    {
        [Key]
        public string DonationName { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string LocationId { get; set; }
        public string CreatedBy { get; set; }
        public string FoodId { get; set; }
        public int Quantity { get; set; }
        // UserId of Donor
        public string UserId { get; set; }

    }
}
