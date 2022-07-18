using System.Collections.Generic;
using Auction.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auction.Infra.Data.Seeder
{
    public class SettingSeeder : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.HasData(new List<Setting>()
            {
                new Setting() {SettingId = 1, CommissionPercentage = 1, GrowthLadder = 1}
            });
        }
    }
}