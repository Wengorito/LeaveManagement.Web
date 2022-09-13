using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class CorrectTypeOfNumberOfDaysInLeaveAllocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NumberOfDays",
                table: "LeaveAllocations",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc181ad9-73d4-4114-8277-1059f8a8aaf8",
                column: "ConcurrencyStamp",
                value: "c5abcf49-44b0-4a97-bd60-d11c9f2a5587");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc654ba9-71d4-4114-8123-1000a1c8aaf8",
                column: "ConcurrencyStamp",
                value: "c17da3c0-895b-45b6-989f-ff64c40943a7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc611ca9-706a-3214-8003-1021b1c8aef8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d1244a1-309b-4bb0-a9df-9ac6196b9b5d", "AQAAAAEAACcQAAAAEM3JNtbvat/acREr0MUjzoOE5mA17c9/wvRCwckrGvNx2Qp9Y8VNPOZUOUEdXKCxYQ==", "0c3866ef-d949-4973-87ae-1c2f7c825c83" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc61a1a9-136a-3214-1103-1021b1c8abcd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2da0bdb9-228c-40db-ae6d-610d43a5b537", "AQAAAAEAACcQAAAAEC7R/OUnRkR01BJ+3ZiLESJeAprBGjLLZZa8IfHm3XP99vOEEaZgLlTjXbJ26IvKmg==", "d38dcb9d-a56e-4db0-9c0d-7f1f7b3a001b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NumberOfDays",
                table: "LeaveAllocations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc181ad9-73d4-4114-8277-1059f8a8aaf8",
                column: "ConcurrencyStamp",
                value: "cf2099d1-7581-467d-b3c7-60f5c0b5716f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc654ba9-71d4-4114-8123-1000a1c8aaf8",
                column: "ConcurrencyStamp",
                value: "aaeaf46f-3798-4809-95d5-686c5f86f864");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc611ca9-706a-3214-8003-1021b1c8aef8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b6b420d-0110-4132-931a-64c5f0740263", "AQAAAAEAACcQAAAAEGdxbMtvxYbe1UBdYo2abydIW5nATwpSyDhU5M/w1O3gxt4RDSLsNtejGMWC/SxKtA==", "51cd339f-b069-488d-a1db-43fa47b08d04" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc61a1a9-136a-3214-1103-1021b1c8abcd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72b861f3-060d-47fa-8d32-5f9a14176672", "AQAAAAEAACcQAAAAEAfrfNIL1MmobFAFuSb4bfQr7aWbH0n90vULEHUYu0y30fuyfnt0GJojQgerioIPUQ==", "64bba9a8-d407-4c37-a7ba-8891adbacf59" });
        }
    }
}
