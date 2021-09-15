using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDonationMicroservice.Models
{
    public class FoodDescription
    {
        [Key]
        public string FoodId { get; set; } 
        public string FoodName { get; set; }
        public string Description { get; set; }
    }
}
