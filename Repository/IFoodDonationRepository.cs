using FoodDonationMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDonationMicroservice.Repository
{
    public interface IFoodDonationRepository
    {
        IEnumerable<FoodDonations> GetDonations();
        FoodDonations GetDonationByID(string donationId);
        void InsertDonation(FoodDonations donation);
        void DeleteDonation(string donationId);
        void UpdateDonation(FoodDonations donation);
        void Save();
    }
}
