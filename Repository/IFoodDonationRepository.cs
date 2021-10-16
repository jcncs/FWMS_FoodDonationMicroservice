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
        IEnumerable<FoodDonationView> GetTodayAllDonations();
        IEnumerable<FoodDonationView> GetAvailableDonations();
        FoodDonationView GetDonationByID(string donationId);
        string InsertDonation(CreateRequest request);
        string DeleteDonation(DeleteRequest request);
        string UpdateDonation(UpdateRequest request);
        void Save();
    }
}
