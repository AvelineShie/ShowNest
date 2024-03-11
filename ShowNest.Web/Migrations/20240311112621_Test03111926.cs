using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShowNest.Web.Migrations
{
    /// <inheritdoc />
    public partial class Test03111926 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PasswordHistories",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UsedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordHistories", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_PasswordHistories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrefillsInfos",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganiztionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyZipCode = table.Column<int>(type: "int", nullable: true),
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyVAT = table.Column<int>(type: "int", nullable: true),
                    DonateEInvoice = table.Column<int>(type: "int", nullable: true),
                    MobileEInvoice = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrefillsInfos", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_PrefillsInfos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "AreaId", "AreaName" },
                values: new object[,]
                {
                    { 1, "北北基宜地區" },
                    { 2, "桃竹苗地區" },
                    { 3, "雲嘉南地區" },
                    { 4, "高屏地區" },
                    { 5, "中彰投地區" },
                    { 6, "花東地區" },
                    { 7, "澎金馬地區" },
                    { 8, "香港" },
                    { 9, "澳門" },
                    { 10, "其他地區" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PasswordHistories");

            migrationBuilder.DropTable(
                name: "PrefillsInfos");

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 10);
        }
    }
}
