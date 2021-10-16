using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDonationMicroservice.Models
{ 
    public class UpdateRequest
    {
        [Key]
        public string DonationId { get; set; }
        public string DonationName { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Quantity { get; set; }
        public string FoodId { get; set; }
        public string LocationId { get; set; }
        public string UpdatedBy { get; set; }
        // UserId of Donor
        public string UserId { get; set; }

    }
}
