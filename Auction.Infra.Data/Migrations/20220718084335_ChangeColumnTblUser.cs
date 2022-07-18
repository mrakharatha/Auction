using Microsoft.EntityFrameworkCore.Migrations;

namespace Auction.Infra.Data.Migrations
{
    public partial class ChangeColumnTblUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserAvatar",
                table: "Users",
                newName: "Avatar");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Avatar",
                table: "Users",
                newName: "UserAvatar");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "zlccbhGKkL1OKwMSZApYsIdBeTLlMwWoh573hL/kKaI=");
        }
    }
}
