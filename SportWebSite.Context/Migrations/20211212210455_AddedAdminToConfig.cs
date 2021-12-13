using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportWebSite.Data.Migrations
{
    public partial class AddedAdminToConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a29435df-1993-40b9-8438-ddeb47ba15ed", "a3ebb4a5-fe85-498a-a0e8-1c2c4c9fc9f1", "Admin", "ADMIN" },
                    { "22feef3a-7e18-4372-8ccb-8c5f86da6c14", "02eff85f-d0d1-4087-8c2e-7ab1cf8ef37a", "Manager", "MANAGER" },
                    { "7420c4fc-101b-40e2-8250-cb7c0df13af3", "c74a2ff6-4f81-4ff2-abe6-9fd97dbc7eac", "Player", "PLAYER" },
                    { "7761cf27-62cd-4bff-a59a-fb9dd7fe887a", "1cea6b8a-3d9c-452b-87b7-5d046af872e7", "Scout", "SCOUT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "Location", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlayerId", "Role", "SecurityStamp", "TeamId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "60d3a5cb-9a8a-4743-9853-304a222e5424", 0, new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Local), "b2b0be1e-6d36-4582-9d6a-f4b405b41e00", "admin@admin.com", true, 1, "Mykolayiv", false, null, "Admin", "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEMT2LgNzkycCUpVpcwCcT7ZqUxHe/YxBQiEV1vgGEemuvAkOm2ggdxIQwPQI9Jvepg==", null, true, null, 0, "73aaade1-b193-41f6-8ce6-773e7ae9aaed", null, false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsersRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "60d3a5cb-9a8a-4743-9853-304a222e5424", "a29435df-1993-40b9-8438-ddeb47ba15ed" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22feef3a-7e18-4372-8ccb-8c5f86da6c14");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7420c4fc-101b-40e2-8250-cb7c0df13af3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7761cf27-62cd-4bff-a59a-fb9dd7fe887a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a29435df-1993-40b9-8438-ddeb47ba15ed");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "60d3a5cb-9a8a-4743-9853-304a222e5424");

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
    }
}
