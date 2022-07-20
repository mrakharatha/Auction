using System.Collections.Generic;
using Auction.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auction.Infra.Data.Seeder
{
    public class CategorySeeder : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new List<Category>()
            {
                new Category(){CategoryId = 1,CategoryName = "خودرو",Image = "/assets/images/auction/01.png",Banner = "/assets/images/auction/car/car-bg.png"},
                new Category(){CategoryId = 2,CategoryName = "جواهر سازی",Image = "/assets/images/auction/02.png",Banner = "/assets/images/auction/jewelry/jwelry-bg.png"},
                new Category(){CategoryId = 3,CategoryName = "سکه",Image = "/assets/images/auction/07.png",Banner = "/assets/images/auction/coins/coin-bg.png"},
                new Category(){CategoryId = 4,CategoryName = "املاک",Image = "/assets/images/auction/06.png",Banner = "/assets/images/auction/realstate/real-bg.png"},
            });
        }
    }
}