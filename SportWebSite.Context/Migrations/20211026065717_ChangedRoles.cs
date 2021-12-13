using Microsoft.EntityFrameworkCore.Migrations;

namespace SportWebSite.Data.Migrations
{
    public partial class ChangedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey("PK_AspNetUserTokens", "AspNetUserTokens");
            migrationBuilder.DropPrimaryKey("PK_AspNetUserLogins", "AspNetUserLogins");

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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "91ab2e06-c59a-4c1a-ac19-bb2f154c997f", "52359769-0732-4e26-89a5-a5a322b51296", "Admin", "ADMIN" },
                    { "bafafe8e-ec40-4f3b-bd0e-3802116e638c", "7dc28415-dd0a-4087-90dc-1eab75096c43", "Manager", "MANAGER" },
                    { "cb1e783d-b912-430e-b40a-8dc00040aa29", "c2e0e1c4-85d8-4cce-b9d9-63d35112377e", "Player", "PLAYER" },
                    { "f6fe411f-61ed-4cf3-8c05-a32218bb31e4", "b3c8096c-ac5c-42c7-8b4d-bac5699ee5ff", "Scout", "SCOUT" }
                });

            migrationBuilder.AddPrimaryKey("PK_AspNetUserTokens", "AspNetUserTokens", new string[] { "UserId", "LoginProvider", "Name" });
            migrationBuilder.AddPrimaryKey("PK_AspNetUserLogins", "AspNetUserLogins", new string[] { "LoginProvider", "ProviderKey" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91ab2e06-c59a-4c1a-ac19-bb2f154c997f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bafafe8e-ec40-4f3b-bd0e-3802116e638c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb1e783d-b912-430e-b40a-8dc00040aa29");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6fe411f-61ed-4cf3-8c05-a32218bb31e4");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

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
    }
}
