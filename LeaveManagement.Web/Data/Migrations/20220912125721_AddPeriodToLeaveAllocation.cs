using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddPeriodToLeaveAllocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "LeaveAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "LeaveAllocations");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc181ad9-73d4-4114-8277-1059f8a8aaf8",
                column: "ConcurrencyStamp",
                value: "4517f927-bb1b-43f0-9bfe-c0199e47736a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc654ba9-71d4-4114-8123-1000a1c8aaf8",
                column: "ConcurrencyStamp",
                value: "9f012e10-835f-4b7f-9508-36bfe8e4b23e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc611ca9-706a-3214-8003-1021b1c8aef8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d4c35f9-ef4c-4f91-b1f7-072691a73636", "AQAAAAEAACcQAAAAEHUx62lEG7UBVwanUatJx9W41lPUFbSHo5UYV6VcI5nKeisFpZhT9FcV2N+gcSXgVw==", "a2f98eb1-f29c-44ad-afd3-a1236fc05df1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc61a1a9-136a-3214-1103-1021b1c8abcd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e62665a8-0adc-42f6-927a-1f884d86469e", "AQAAAAEAACcQAAAAEFpKAM5lAsOeCZHjpClZUwWlF+Da/0hyfG4gIjbC3LWKG4X9yxSMjbaW7FpFhn2guQ==", "07eb321f-5d58-4a0f-9916-ff0341f46e90" });
        }
    }
}
