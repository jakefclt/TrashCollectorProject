using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "PickUp",
                table: "Customers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "70b13d5c-4551-49b2-a3a3-408edcdb6806", "9defe213-6d4e-4d88-bd06-a7a7fa23816b", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f91c068d-b3d8-4dfa-aae3-4bd53b34c6e4", "3c42d06f-5563-4460-9e57-6c1ff9c708f6", "Employee", "Employee" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "616bdf31-fb47-4bb5-999a-51dba0f23258", "4a171c45-e56c-43cd-8940-c5dd112fbd53", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "616bdf31-fb47-4bb5-999a-51dba0f23258");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70b13d5c-4551-49b2-a3a3-408edcdb6806");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f91c068d-b3d8-4dfa-aae3-4bd53b34c6e4");

            migrationBuilder.DropColumn(
                name: "PickUp",
                table: "Customers");

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
    }
}
