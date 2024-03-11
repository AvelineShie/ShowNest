using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShowNest.Web.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AreaPreferences",
                table: "AreaPreferences");

            migrationBuilder.DropColumn(
                name: "City",
                table: "PrefillsInfos");

            migrationBuilder.RenameColumn(
                name: "Region",
                table: "PrefillsInfos",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "JobTitle",
                table: "PrefillsInfos",
                newName: "District");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "PrefillsInfos",
                newName: "County");

            migrationBuilder.RenameColumn(
                name: "AreaId",
                table: "Areas",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PrefillsInfos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AreaPreferences",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AreaPreferences",
                table: "AreaPreferences",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AreaPreferences_UserId",
                table: "AreaPreferences",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AreaPreferences",
                table: "AreaPreferences");

            migrationBuilder.DropIndex(
                name: "IX_AreaPreferences_UserId",
                table: "AreaPreferences");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PrefillsInfos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AreaPreferences");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "PrefillsInfos",
                newName: "Region");

            migrationBuilder.RenameColumn(
                name: "District",
                table: "PrefillsInfos",
                newName: "JobTitle");

            migrationBuilder.RenameColumn(
                name: "County",
                table: "PrefillsInfos",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Areas",
                newName: "AreaId");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "PrefillsInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AreaPreferences",
                table: "AreaPreferences",
                columns: new[] { "UserId", "AreaId" });
        }
    }
}
