using FoodDonationMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDonationMicroservice.Repository
{
    public interface IFoodDonationRepository
    {
        IEnumerable<FoodDonationView> GetDonations();
        FoodDonationView GetDonationByID(string donationId);
        string InsertDonation(CreateRequest request);
        void DeleteDonation(string donationId);
        void UpdateDonation(FoodDonations donation);
        void Save();
    }
}
