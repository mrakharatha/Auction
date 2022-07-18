using System;
using System.Collections.Generic;
using Auction.Application.Utilities;
using Auction.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auction.Infra.Data.Seeder
{

    public class UserSeeder : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new List<User>()
            {
                new User()
                {
                    UserId = 1,
                    FullName = "ادمین سیستم",
                    Email = "superadmin@yazd.com",
                    Password = SecurityHelper.GetSha256Hash("123"),
                    Avatar = "client02.png",
                    RegisterDate = new DateTime(2022, 07, 18, 12, 56, 32, 968, DateTimeKind.Local).AddTicks(1379)
                }
            });
        }
    }
}