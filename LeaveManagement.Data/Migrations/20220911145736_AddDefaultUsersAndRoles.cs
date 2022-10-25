using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Data.Migrations
{
    public partial class AddDefaultUsersAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bc181ad9-73d4-4114-8277-1059f8a8aaf8", "4517f927-bb1b-43f0-9bfe-c0199e47736a", "Administrator", "ADMINISTRATOR" },
                    { "bc654ba9-71d4-4114-8123-1000a1c8aaf8", "9f012e10-835f-4b7f-9508-36bfe8e4b23e", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "bc611ca9-706a-3214-8003-1021b1c8aef8", 0, "9d4c35f9-ef4c-4f91-b1f7-072691a73636", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", true, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAEAACcQAAAAEHUx62lEG7UBVwanUatJx9W41lPUFbSHo5UYV6VcI5nKeisFpZhT9FcV2N+gcSXgVw==", null, false, "a2f98eb1-f29c-44ad-afd3-a1236fc05df1", null, false, "admin@localhost.com" },
                    { "bc61a1a9-136a-3214-1103-1021b1c8abcd", 0, "e62665a8-0adc-42f6-927a-1f884d86469e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@localhost.com", true, "System", "User", false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAEAACcQAAAAEFpKAM5lAsOeCZHjpClZUwWlF+Da/0hyfG4gIjbC3LWKG4X9yxSMjbaW7FpFhn2guQ==", null, false, "07eb321f-5d58-4a0f-9916-ff0341f46e90", null, false, "user@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bc181ad9-73d4-4114-8277-1059f8a8aaf8", "bc611ca9-706a-3214-8003-1021b1c8aef8" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bc654ba9-71d4-4114-8123-1000a1c8aaf8", "bc61a1a9-136a-3214-1103-1021b1c8abcd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bc181ad9-73d4-4114-8277-1059f8a8aaf8", "bc611ca9-706a-3214-8003-1021b1c8aef8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bc654ba9-71d4-4114-8123-1000a1c8aaf8", "bc61a1a9-136a-3214-1103-1021b1c8abcd" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc181ad9-73d4-4114-8277-1059f8a8aaf8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc654ba9-71d4-4114-8123-1000a1c8aaf8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc611ca9-706a-3214-8003-1021b1c8aef8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc61a1a9-136a-3214-1103-1021b1c8abcd");
        }
    }
}
