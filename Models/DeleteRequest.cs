using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDonationMicroservice.Models
{ 
    public class DeleteRequest
    {
        [Key]
        public string DonationId { get; set; }

    }
}
