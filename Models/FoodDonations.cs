using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDonationMicroservice.Models
{
    public class FoodDonations
    {
        [Key]
        public string DonationId { get; set; }
        public string DonationName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UserId { get; set; }
        public string ReservedBy { get; set; }
        public DateTime ReservedDate { get; set; }
        public string CollectionId { get; set; }
        public string FoodEntryId { get; set; }
    }
}
