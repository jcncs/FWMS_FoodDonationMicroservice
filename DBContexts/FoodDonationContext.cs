using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDonationMicroservice.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDonationMicroservice.DBContexts
{
    public class FoodDonationContext : DbContext
    {
        public FoodDonationContext(DbContextOptions<FoodDonationContext> options) : base(options)
        {
        }
        public DbSet<FoodDonations> FoodDonations { get; set; }
        public DbSet<FoodDescription> FoodDescriptions { get; set; }
        public DbSet<FoodEntry> Entries { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<FoodDonationView> FoodDonationViews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodDonations>().HasData(
                new FoodDonations
                {
                    DonationId = "1",
                    DonationName = "Raffles Hotel Lunch Buffet",
                    UserId = "asd2sda",
                    ReservedBy = "FoodForSg",
                    ReservedDate = DateTime.Now,
                    CollectionId = "234t6d3",
                    FoodEntryId = "1120",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "asd2sda",
                    UpdatedDate = DateTime.Now,
                    UpdatedBy = "asd2sda",
                },
                new FoodDonations
                {
                    DonationId = "2",
                    DonationName = "Marina Bay Sands Lunch Buffet",
                    UserId = "kdsjfw2",
                    ReservedBy = "FoodFromTheHeart",
                    ReservedDate = DateTime.Now,
                    CollectionId = "s12dsaf",
                    FoodEntryId = "1240",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "kdsjfw2",
                    UpdatedDate = DateTime.Now,
                    UpdatedBy = "kdsjfw2",
                },
                new FoodDonations
                {
                    DonationId = "3",
                    DonationName = "Marina Bay Sands Lunch Buffet",
                    UserId = "kibjdf2",
                    ReservedBy = "SGFoodRescure",
                    ReservedDate = DateTime.Now,
                    CollectionId = "jjksnf2",
                    FoodEntryId = "1240",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "kibjdf2",
                    UpdatedDate = DateTime.Now,
                    UpdatedBy = "kibjdf2",
                }
           );
        }
    }
}
