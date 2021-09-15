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

        // GET: api/<FoodDonationController>
        [HttpGet]
        public IActionResult Get()
        {
            var donations = _foodDonationRepository.GetDonations();
            return new OkObjectResult(donations);
        }

        // GET api/<FoodDonationController>/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(string id)
        {
            var donation = _foodDonationRepository.GetDonationByID(id);
            return new OkObjectResult(donation);
        }

        // POST api/<FoodDonationController>
        [HttpPost]
        public IActionResult Post([FromBody] FoodDonations donation)
        {
            using (var scope = new TransactionScope())
            {
                _foodDonationRepository.InsertDonation(donation);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { DonationId = donation.DonationId }, donation);
            }
            
        }

        // PUT api/<FoodDonationController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] FoodDonations donation)
        {
            if (donation != null)
            {
                using (var scope = new TransactionScope())
                {
                    _foodDonationRepository.UpdateDonation(donation);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE api/<FoodDonationController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _foodDonationRepository.DeleteDonation(id);
            return new OkResult();
        }
    }
}
