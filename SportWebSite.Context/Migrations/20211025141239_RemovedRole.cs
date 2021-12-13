using Microsoft.EntityFrameworkCore.Migrations;

namespace SportWebSite.Data.Migrations
{
    public partial class RemovedRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "67706a9b-f420-48d0-98e6-d5fb0db262c1", "ae0879e3-b32d-4387-b4d4-3524b7f0b8e7", "Admin", null },
                    { "63b15cb8-d9fb-4d5d-8dc7-4bba8c6f4f6e", "a8cc91c2-dfe2-44e9-9922-9c7f7b0cfb81", "Manager", null },
                    { "845d94e6-2642-4ebe-ab3a-9ccb5863e8c1", "8dbc720a-cd4b-458c-b431-624dc6e903ae", "Player", null },
                    { "6ae52168-69f0-4b25-8818-22d93a6f7b63", "d99c36e6-c45e-40a7-8a29-edc3c565daef", "Scout", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63b15cb8-d9fb-4d5d-8dc7-4bba8c6f4f6e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67706a9b-f420-48d0-98e6-d5fb0db262c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ae52168-69f0-4b25-8818-22d93a6f7b63");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "845d94e6-2642-4ebe-ab3a-9ccb5863e8c1");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
