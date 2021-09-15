using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodDonationMicroservice.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    DonationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DonationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReservedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReservedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CollectionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodEntryId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.DonationId);
                });

            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    FoodEntryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FoodId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.FoodEntryId);
                });

            migrationBuilder.CreateTable(
                name: "FoodDescriptions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FoodName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodDescriptions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Donations",
                columns: new[] { "DonationId", "CollectionId", "CreatedBy", "CreatedDate", "DonationName", "FoodEntryId", "ReservedBy", "ReservedDate", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[] { "1", "234t6d3", "asd2sda", new DateTime(2021, 9, 7, 23, 20, 34, 454, DateTimeKind.Local).AddTicks(2163), "Raffles Hotel Lunch Buffet", "1120", "FoodForSg", new DateTime(2021, 9, 7, 23, 20, 34, 453, DateTimeKind.Local).AddTicks(4191), "asd2sda", new DateTime(2021, 9, 7, 23, 20, 34, 454, DateTimeKind.Local).AddTicks(2642), "asd2sda" });

            migrationBuilder.InsertData(
                table: "Donations",
                columns: new[] { "DonationId", "CollectionId", "CreatedBy", "CreatedDate", "DonationName", "FoodEntryId", "ReservedBy", "ReservedDate", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[] { "2", "s12dsaf", "kdsjfw2", new DateTime(2021, 9, 7, 23, 20, 34, 454, DateTimeKind.Local).AddTicks(3077), "Marina Bay Sands Lunch Buffet", "1240", "FoodFromTheHeart", new DateTime(2021, 9, 7, 23, 20, 34, 454, DateTimeKind.Local).AddTicks(3073), "kdsjfw2", new DateTime(2021, 9, 7, 23, 20, 34, 454, DateTimeKind.Local).AddTicks(3078), "kdsjfw2" });

            migrationBuilder.InsertData(
                table: "Donations",
                columns: new[] { "DonationId", "CollectionId", "CreatedBy", "CreatedDate", "DonationName", "FoodEntryId", "ReservedBy", "ReservedDate", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[] { "3", "jjksnf2", "kibjdf2", new DateTime(2021, 9, 7, 23, 20, 34, 454, DateTimeKind.Local).AddTicks(3081), "Marina Bay Sands Lunch Buffet", "1240", "SGFoodRescure", new DateTime(2021, 9, 7, 23, 20, 34, 454, DateTimeKind.Local).AddTicks(3080), "kibjdf2", new DateTime(2021, 9, 7, 23, 20, 34, 454, DateTimeKind.Local).AddTicks(3082), "kibjdf2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "FoodDescriptions");
        }
    }
}
