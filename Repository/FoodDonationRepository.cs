using FoodDonationMicroservice.DBContexts;
using FoodDonationMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDonationMicroservice.Repository
{
    public class FoodDonationRepository : IFoodDonationRepository
    {
        private readonly FoodDonationContext _dbContext;
        public FoodDonationRepository(FoodDonationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteDonation(string donationId)
        {
            var donation = _dbContext.FoodDonations.Find(donationId);
            _dbContext.FoodDonations.Remove(donation);
            Save();
        }

        public FoodDonations GetDonationByID(string donationId)
        {
            return _dbContext.FoodDonations.Find(donationId);
        }

        public IEnumerable<FoodDonationView> GetDonations()
        {           
            return _dbContext.FoodDonationViews.ToList();
        }
        public void InsertDonation(FoodDonations donation)
        {
            _dbContext.Add(donation);
            Save();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public void UpdateDonation(FoodDonations donation)
        {
            _dbContext.Entry(donation).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
    }
}
