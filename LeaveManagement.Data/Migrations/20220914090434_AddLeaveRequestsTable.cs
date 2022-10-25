using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Data.Migrations
{
    public partial class AddLeaveRequestsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: true),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false),
                    RequestingEmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc181ad9-73d4-4114-8277-1059f8a8aaf8",
                column: "ConcurrencyStamp",
                value: "9697d94d-4228-4c65-bdad-88bb27de549c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc654ba9-71d4-4114-8123-1000a1c8aaf8",
                column: "ConcurrencyStamp",
                value: "dbb3640f-09e5-418e-9aac-085262663b4d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc611ca9-706a-3214-8003-1021b1c8aef8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5eb87962-6e18-4358-adda-41e3c0403c8e", "AQAAAAEAACcQAAAAEDbiSVq1aVRdm7Uz3VDnns6MZcfJSBp+aS4nkwqohofqQL5EKkWCxSDFCP9S7P8Brw==", "f007be2b-797a-4eee-9a48-014284484b2c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc61a1a9-136a-3214-1103-1021b1c8abcd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "221f49b9-a90c-4aa2-a923-0dd1054f378d", "AQAAAAEAACcQAAAAECJltR1S2OpkrUOLKIn/fbAeoUQlCq7z9bN256uKIjGxYKAW1v3WlfOkugSS9j9i9w==", "bfad0e1f-0a11-40e8-bc05-a29adef37247" });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LeaveTypeId",
                table: "LeaveRequests",
                column: "LeaveTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequests");

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
    }
}
