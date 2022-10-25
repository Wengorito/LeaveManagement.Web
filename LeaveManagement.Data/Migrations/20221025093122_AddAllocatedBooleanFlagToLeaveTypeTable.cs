using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Data.Migrations
{
    public partial class AddAllocatedBooleanFlagToLeaveTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Allocated",
                table: "LeaveTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc181ad9-73d4-4114-8277-1059f8a8aaf8",
                column: "ConcurrencyStamp",
                value: "97564efa-fcb8-4047-9873-0aa3a25e4b89");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc654ba9-71d4-4114-8123-1000a1c8aaf8",
                column: "ConcurrencyStamp",
                value: "d1b3e1be-1524-44de-9729-28fb0a5267e4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc611ca9-706a-3214-8003-1021b1c8aef8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b458d20-3015-4c93-ad22-f2a603286356", "AQAAAAEAACcQAAAAEJ2+fUUJrYJOqWuJC+jt7iEkrmfgsIrjeu7llHbBMFr29UNcwZrIUXTvdVHhP5QTIQ==", "4a0c91f3-85eb-44f4-84c6-bdf1dd7778de" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc61a1a9-136a-3214-1103-1021b1c8abcd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "537bd574-fb84-49fe-92dc-f6e72cefdfac", "AQAAAAEAACcQAAAAEM4/0jF82flX8/d+G1cAIUnR+7PARUGPtnSuJBGqMF+kbNrT1z8dbaELcQR6DS2cAw==", "5a385aa4-c1d4-4084-9ddb-21074ae0dc7c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Allocated",
                table: "LeaveTypes");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc181ad9-73d4-4114-8277-1059f8a8aaf8",
                column: "ConcurrencyStamp",
                value: "e6427a1f-1f95-4688-a46a-3c6cc9be6428");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc654ba9-71d4-4114-8123-1000a1c8aaf8",
                column: "ConcurrencyStamp",
                value: "6f8669e4-c14e-45b8-a759-33aa5982a7b5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc611ca9-706a-3214-8003-1021b1c8aef8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca27263a-9293-4716-9d2a-8714fe24f03f", "AQAAAAEAACcQAAAAENAUIkwLijY+D3o52Z9ogIlMnNS2K0GUhXfrJjFscuHlD9rX8/UqWnClJDmLj3TE2g==", "7907254f-06ea-4135-af96-51837cc0fc1c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc61a1a9-136a-3214-1103-1021b1c8abcd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc86ab86-b788-4871-a975-5b42fe10be58", "AQAAAAEAACcQAAAAEL5uMy5FiS6TsKWrfcikgwAwkSO+dcUZAaIaO13H3gDGGhxifkQiuwK/+PXTbcDrnQ==", "c25a5b93-79ed-4f0b-9ae9-f02f97ae7e5e" });
        }
    }
}
