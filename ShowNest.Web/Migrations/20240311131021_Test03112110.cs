using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShowNest.Web.Migrations
{
    /// <inheritdoc />
    public partial class Test03112110 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "AreaId", "AreaName" },
                values: new object[] { 11, "TEST" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "AreaId",
                keyValue: 11);
        }
    }
}
