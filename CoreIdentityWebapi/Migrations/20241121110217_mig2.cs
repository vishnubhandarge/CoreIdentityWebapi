using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoreIdentityWebapi.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50994fcb-856c-4449-8150-017000c7939c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6da47fcc-80cb-4d49-8694-e867bef873d3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "68acfa15-ec2f-41a3-8246-dc87a643181e", "2", "User", "USER" },
                    { "72310e45-6ea4-44bc-ab50-2374b9d0d29a", "3", "HR", "HR" },
                    { "f7c088af-3e5a-484e-a5dc-820e9646dfbb", "1", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68acfa15-ec2f-41a3-8246-dc87a643181e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72310e45-6ea4-44bc-ab50-2374b9d0d29a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7c088af-3e5a-484e-a5dc-820e9646dfbb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "50994fcb-856c-4449-8150-017000c7939c", null, "Customer", "CUSTOMER" },
                    { "6da47fcc-80cb-4d49-8694-e867bef873d3", null, "Admin", "ADMIN" }
                });
        }
    }
}
