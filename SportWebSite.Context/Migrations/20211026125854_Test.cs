using Microsoft.EntityFrameworkCore.Migrations;

namespace SportWebSite.Data.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_RoleId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId1",
                table: "AspNetUserRoles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c3e3770-88d7-4be1-a324-8b30281789be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ebc47ad-9b9d-4080-a7ee-0f98f5057820");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df4322c3-1448-4563-b328-e3a0dd019322");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f781625c-071e-4669-a584-b6eb506a64b4");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "AspNetUserRoles");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "RoleId1",
                table: "AspNetUserRoles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "AspNetUserRoles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "df4322c3-1448-4563-b328-e3a0dd019322", "815d5f02-185b-4c4f-9b7d-c76818c2281a", "Admin", "ADMIN" },
                    { "f781625c-071e-4669-a584-b6eb506a64b4", "db210246-bdfd-4795-a8d0-c484a80e6747", "Manager", "MANAGER" },
                    { "3c3e3770-88d7-4be1-a324-8b30281789be", "0fe7e7c7-899d-483c-973a-021c20dbc0d1", "Player", "PLAYER" },
                    { "3ebc47ad-9b9d-4080-a7ee-0f98f5057820", "8ce7bec1-a102-4a56-9b98-57d01329319d", "Scout", "SCOUT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId1",
                table: "AspNetUserRoles",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId1",
                table: "AspNetUserRoles",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId1",
                table: "AspNetUserRoles",
                column: "RoleId1",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
                table: "AspNetUserRoles",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
