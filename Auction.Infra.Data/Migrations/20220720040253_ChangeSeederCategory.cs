using Microsoft.EntityFrameworkCore.Migrations;

namespace Auction.Infra.Data.Migrations
{
    public partial class ChangeSeederCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6);

            migrationBuilder.AddColumn<string>(
                name: "Banner",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "Banner", "Image" },
                values: new object[] { "/assets/images/auction/car/car-bg.png", "/assets/images/auction/01.png" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "Banner", "Image" },
                values: new object[] { "/assets/images/auction/jewelry/jwelry-bg.png", "/assets/images/auction/02.png" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "Banner", "CategoryName", "Image" },
                values: new object[] { "/assets/images/auction/coins/coin-bg.png", "سکه", "/assets/images/auction/07.png" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                columns: new[] { "Banner", "CategoryName", "Image" },
                values: new object[] { "/assets/images/auction/realstate/real-bg.png", "املاک", "/assets/images/auction/06.png" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Banner",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Image",
                value: "01.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Image",
                value: "02.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "CategoryName", "Image" },
                values: new object[] { "ساعت", "03.png" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                columns: new[] { "CategoryName", "Image" },
                values: new object[] { "الکترونیک", "04.png" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Image" },
                values: new object[,]
                {
                    { 5, "ورزشی", "05.png" },
                    { 6, "املاک", "06.png" }
                });
        }
    }
}
