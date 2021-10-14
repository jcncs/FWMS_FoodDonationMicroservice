using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDonationMicroservice.Models
{
    [Table("FoodDonationView")]
    public class FoodDonationView
    {
        [Key]
        public string DonationId { get; set; }
        public string DonationName { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string LocationName { get; set; }
        public string ReservedBy { get; set; }
        public DateTime? ReservedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CollectionId { get; set; }
        public string FoodEntryId { get; set; }

    }
}
