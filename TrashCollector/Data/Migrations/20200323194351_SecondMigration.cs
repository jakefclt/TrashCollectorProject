using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06c02000-1438-4808-8006-7fd2be4d2ea9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41c630c0-0b72-4d09-ac0e-01d51a9d81f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea2734c1-dfd0-4e96-b928-15d559f50002");

            migrationBuilder.AddColumn<bool>(
                name: "PickUp",
                table: "Employees",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a4b85c6a-f335-4f9a-8e7b-9827915c91dc", "832d7800-f82e-4970-9d9c-3ca10ad0bf4e", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "62369b33-8142-4081-9236-fe6992783a22", "7f9f1442-cf6b-4bbf-a5c0-3c9754a9aae3", "Employee", "Employee" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ac6beb4d-491a-4d0b-8492-41b70e29894b", "f8234b97-ed84-4b6e-8d21-0d14e2308ea5", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62369b33-8142-4081-9236-fe6992783a22");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4b85c6a-f335-4f9a-8e7b-9827915c91dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac6beb4d-491a-4d0b-8492-41b70e29894b");

            migrationBuilder.DropColumn(
                name: "PickUp",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "06c02000-1438-4808-8006-7fd2be4d2ea9", "9b639273-a98a-403e-916c-f41fb79929d8", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "41c630c0-0b72-4d09-ac0e-01d51a9d81f0", "041528ed-8549-4d96-b254-894cae2e9a01", "Employee", "Employee" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ea2734c1-dfd0-4e96-b928-15d559f50002", "ad6f8afc-cf8e-435f-bf56-0d73c1ebf1ca", "Admin", "ADMIN" });
        }
    }
}
