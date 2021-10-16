using FoodDonationMicroservice.Repository;
using FoodDonationMicroservice.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodDonationMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodDonationController : ControllerBase
    {
        private readonly IFoodDonationRepository _foodDonationRepository;

        public FoodDonationController(IFoodDonationRepository foodDonationRepository)
        {
            _foodDonationRepository = foodDonationRepository;
        }

        // GET: api/FoodDonation/GetAllDonations
        [HttpGet("GetAllDonations")]
        public IActionResult GetAllDonations()
        {
            var donations = _foodDonationRepository.GetDonations();
            return new OkObjectResult(donations);
        }

        // GET: api/FoodDonation/GetTodayAllDonations
        [HttpGet("GetTodayAllDonations")]
        public IActionResult GetTodayAllDonations()
        {
            // Donations that are created today, regardless of expiry date or reservations
            var donations = _foodDonationRepository.GetTodayAllDonations();
            return new OkObjectResult(donations);
        }

        // GET: api/FoodDonation/GetAvailableDonations
        [HttpGet("GetAvailableDonations")]
        public IActionResult GetAvailableDonations()
        {
            // Available refers to food that are not yet expired and not reserved yet
            var donations = _foodDonationRepository.GetAvailableDonations();
            return new OkObjectResult(donations);
        }

        // GET api/FoodDonation/4DCBC8B5F47D
        [HttpGet("GetDonationById/{id}", Name = "Get")]
        public IActionResult Get(string id)
        {
            var donation = _foodDonationRepository.GetDonationByID(id);
            return new OkObjectResult(donation);
        }

        // POST api/FoodDonation/AddNewDonation
        [HttpPost("AddNewDonation")]
        public IActionResult AddNewDonation([FromBody] CreateRequest request)
        {
            using (var scope = new TransactionScope())
            {
                var response = _foodDonationRepository.InsertDonation(request);
                scope.Complete();
                return new OkResult();
            }
            
        }

        // PUT api/FoodDonation/ModifyDonation
        [HttpPut("ModifyDonation")]
        public IActionResult Put([FromBody] UpdateRequest request)
        {
            if (request != null)
            {
                using (var scope = new TransactionScope())
                {
                    var response = _foodDonationRepository.UpdateDonation(request);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE api/FoodDonation/DeleteDonation
        [HttpDelete("DeleteDonation")]
        public IActionResult Delete(DeleteRequest request)
        {
            var response = _foodDonationRepository.DeleteDonation(request);
            return new OkResult();
        }
    }
}
