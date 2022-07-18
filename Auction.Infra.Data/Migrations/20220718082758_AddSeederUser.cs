using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Auction.Infra.Data.Migrations
{
    public partial class AddSeederUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FullName", "Password", "RegisterDate", "UserAvatar" },
                values: new object[] { 1, "superadmin@yazd.com", "ادمین سیستم", "zlccbhGKkL1OKwMSZApYsIdBeTLlMwWoh573hL/kKaI=", new DateTime(2022, 7, 18, 12, 56, 32, 968, DateTimeKind.Local).AddTicks(1379), "client02.png" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);
        }
    }
}
