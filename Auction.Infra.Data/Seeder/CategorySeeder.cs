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
                new Category(){CategoryId = 1,CategoryName = "خودرو",Image = "01.png"},
                new Category(){CategoryId = 2,CategoryName = "جواهر سازی",Image = "02.png"},
                new Category(){CategoryId = 3,CategoryName = "ساعت",Image = "03.png"},
                new Category(){CategoryId = 4,CategoryName = "الکترونیک",Image = "04.png"},
                new Category(){CategoryId = 5,CategoryName = "ورزشی",Image = "05.png"},
                new Category(){CategoryId = 6,CategoryName = "املاک",Image = "06.png"},
            });
        }
    }
}