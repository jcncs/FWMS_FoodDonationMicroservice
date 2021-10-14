using FoodDonationMicroservice.DBContexts;
using FoodDonationMicroservice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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

        public FoodDonationView GetDonationByID(string donationId)
        {
            return _dbContext.FoodDonationViews.Find(donationId);
        }

        public IEnumerable<FoodDonationView> GetDonations()
        {           
            return _dbContext.FoodDonationViews.ToList();
        }
        public string InsertDonation(CreateRequest request)
        {
            int rowsAffected;
            string sql = "EXEC AddFoodDonation  @pQuantity, @pExpiryDate, @pFoodId, @pDonationName, @pCreatedBy, @pUserId, @pLocationId ";

            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Create parameters    
                new SqlParameter { ParameterName = "@pQuantity", Value = request.Quantity },
                new SqlParameter { ParameterName = "@pExpiryDate", Value = request.ExpiryDate },
                new SqlParameter { ParameterName = "@pFoodId", Value = request.FoodId },
                new SqlParameter { ParameterName = "@pDonationName", Value = request.DonationName },
                new SqlParameter { ParameterName = "@pCreatedBy", Value = request.CreatedBy },
                new SqlParameter { ParameterName = "@pUserId", Value = request.UserId },
                new SqlParameter { ParameterName = "@pLocationId", Value = request.LocationId }
            };

            rowsAffected = _dbContext.Database.ExecuteSqlRaw(sql, parms.ToArray());

            return "OK";
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
