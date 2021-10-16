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
       
        public FoodDonationView GetDonationByID(string donationId)
        {
            return _dbContext.FoodDonationViews.Find(donationId);
        }

        public IEnumerable<FoodDonationView> GetDonations()
        {           
            return _dbContext.FoodDonationViews.ToList();
        }

        public IEnumerable<FoodDonationView> GetTodayAllDonations()
        {
            return _dbContext.FoodDonationViews.Where(s => s.CreatedDate.Day == DateTime.Now.Day && s.CreatedDate.Month == DateTime.Now.Month && s.CreatedDate.Year == DateTime.Now.Year)
                                                .OrderBy(s => s.CreatedDate)
                                                .Select(s => s)
                                                .ToList();
        }

        public IEnumerable<FoodDonationView> GetAvailableDonations()
        {
            // Available refers to food that are not yet expired and not reserved yet
            return _dbContext.FoodDonationViews.Where(s => s.ExpiryDate > DateTime.Now && string.IsNullOrEmpty(s.ReservedBy))
                                                .Select(s => s)
                                                .ToList();
        }

        public string InsertDonation(CreateRequest request)
        {
            int rowsAffected;
            string sql = "EXEC SP_AddFoodDonation @pQuantity, @pExpiryDate, @pFoodId, @pDonationName, @pCreatedBy, @pUserId, @pLocationId ";

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
        public string UpdateDonation(UpdateRequest request)
        {
            int rowsAffected;
            string sql = "EXEC SP_ModifyFoodDonation @pDonationId, @pNewDonationName, @pNewExpiryDate, @pNewQuantity, @pNewFoodId, @pNewLocationId, @pUpdatedBy, @pUserId ";

            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Create parameters    
                new SqlParameter { ParameterName = "@pDonationId", Value = request.DonationId },
                new SqlParameter { ParameterName = "@pNewDonationName", Value = request.DonationName },
                new SqlParameter { ParameterName = "@pNewExpiryDate", Value = request.ExpiryDate },
                new SqlParameter { ParameterName = "@pNewQuantity", Value = request.Quantity },
                new SqlParameter { ParameterName = "@pNewFoodId", Value = request.FoodId },
                new SqlParameter { ParameterName = "@pNewLocationId", Value = request.LocationId },
                new SqlParameter { ParameterName = "@pUpdatedBy", Value = request.UpdatedBy },
                new SqlParameter { ParameterName = "@pUserId", Value = request.UserId }
            };

            rowsAffected = _dbContext.Database.ExecuteSqlRaw(sql, parms.ToArray());

            return "OK";
        }

        public string DeleteDonation(DeleteRequest request)
        {
            int rowsAffected;
            string sql = "EXEC SP_CancelFoodDonation @pDonationId ";

            List<SqlParameter> parms = new List<SqlParameter>
            { 
                // Create parameters    
                new SqlParameter { ParameterName = "@pDonationId", Value = request.DonationId }
            };

            rowsAffected = _dbContext.Database.ExecuteSqlRaw(sql, parms.ToArray());

            return "OK";
        }
    }
}
