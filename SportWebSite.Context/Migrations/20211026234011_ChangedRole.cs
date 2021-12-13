using Microsoft.EntityFrameworkCore.Migrations;

namespace SportWebSite.Data.Migrations
{
    public partial class ChangedRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15b23c5c-7ef5-4ad4-b698-f3d4a9c074ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8effde81-12bc-4fb1-b49f-dc233ff02f6c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae0c2cf7-2c13-43e2-8231-330b600dfd1d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c94df3d7-3f14-489c-ab32-e2fddd98043c");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c236a5ed-da76-4783-b54a-33b5f5a92232", "362424ee-d014-48a6-80c3-ff03a28a612e", "Admin", "ADMIN" },
                    { "e49c25bc-5d48-4760-9c89-6203cc02336e", "59745c5b-9f52-4419-bde4-7efaf26a2a93", "Manager", "MANAGER" },
                    { "74e240c3-5b1d-4bd5-857a-d19e54e45315", "85f463e4-6aa7-4465-a1c3-1df641bb756c", "Player", "PLAYER" },
                    { "06099fa9-7a2a-4e7e-b171-f495b51cee57", "9473f497-7bf6-4ee1-abf2-bb9f45ba0784", "Scout", "SCOUT" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06099fa9-7a2a-4e7e-b171-f495b51cee57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74e240c3-5b1d-4bd5-857a-d19e54e45315");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c236a5ed-da76-4783-b54a-33b5f5a92232");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e49c25bc-5d48-4760-9c89-6203cc02336e");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8effde81-12bc-4fb1-b49f-dc233ff02f6c", "004ce6bd-0cba-46c7-8585-8194055f8db0", "Admin", "ADMIN" },
                    { "c94df3d7-3f14-489c-ab32-e2fddd98043c", "cdd9cfd5-9e00-4ae5-b23d-556bfdc2ee29", "Manager", "MANAGER" },
                    { "ae0c2cf7-2c13-43e2-8231-330b600dfd1d", "105edc83-1a89-44f5-b5ef-3a91694f84c1", "Player", "PLAYER" },
                    { "15b23c5c-7ef5-4ad4-b698-f3d4a9c074ec", "731bf4d4-ad71-4e07-b6d6-8f093eaf14e5", "Scout", "SCOUT" }
                });
        }
    }
}
