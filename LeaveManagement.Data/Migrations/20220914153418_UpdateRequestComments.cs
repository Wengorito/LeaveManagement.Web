using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Data.Migrations
{
    public partial class UpdateRequestComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
        }
    }
}
