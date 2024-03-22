using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Test031220102 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogInInfo_Users",
                table: "LogInInfo");

            migrationBuilder.InsertData(
                table: "CategoryTags",
                columns: new[] { "Id", "CreatedAt", "EditeAt", "IsDeleted", "Name", "Sort" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7775), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7776), false, "音樂", 0 },
                    { 2, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7778), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7778), false, "戲劇", 0 },
                    { 3, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7780), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7780), false, "展覽", 0 }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "ContactMobile", "ContactName", "ContactTelephone", "CreatedAt", "Description", "EditedAt", "Email", "FBLink", "IGAccount", "ImgURL", "IsDeleted", "Name", "OrganizationURL", "OuterURL", "OwnerId" },
                values: new object[,]
                {
                    { 1, "0123456789", "Alice", "02-2123-45678", new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7800), "組織簡介內容區", new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7801), null, null, null, null, false, "Build School", "HTTP", null, 0 },
                    { 2, "0123456789", "Bob", "02-2123-45678", new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7805), "組織簡介內容區", new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7805), null, null, null, null, false, "卡米地", "HTTP", null, 2 },
                    { 3, "0123456789", "Charlie", "02-2123-45678", new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7808), "組織簡介內容區", new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7808), null, null, null, null, false, "海邊的卡夫卡", "HTTP", null, 3 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreatedAt", "EditedAt", "IsDeleted", "Number", "SeatAreaId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7536), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7537), false, "1排1號", 1, (byte)1 },
                    { 2, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7540), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7540), false, "1排2號", 1, (byte)1 },
                    { 3, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7543), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7543), false, "1排3號", 1, (byte)1 },
                    { 4, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7545), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7546), false, "1排4號", 1, (byte)1 },
                    { 5, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7547), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7548), false, "1排5號", 1, (byte)1 },
                    { 6, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7550), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7550), false, "1排6號", 1, (byte)1 },
                    { 7, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7552), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7553), false, "1排7號", 1, (byte)1 },
                    { 8, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7555), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7555), false, "1排8號", 1, (byte)1 },
                    { 9, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7557), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7558), false, "1排9號", 1, (byte)1 },
                    { 10, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7559), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7560), false, "1排10號", 1, (byte)1 },
                    { 11, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7562), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7562), false, "1排11號", 1, (byte)1 },
                    { 12, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7564), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7565), false, "1排12號", 1, (byte)1 },
                    { 13, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7567), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7567), false, "1排13號", 1, (byte)1 },
                    { 14, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7569), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7570), false, "1排14號", 1, (byte)1 },
                    { 15, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7571), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7572), false, "1排15號", 1, (byte)1 },
                    { 16, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7574), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7574), false, "1排16號", 1, (byte)1 },
                    { 17, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7576), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7576), false, "1排17號", 1, (byte)1 },
                    { 18, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7578), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7579), false, "2排1號", 1, (byte)1 },
                    { 19, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7581), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7581), false, "2排2號", 1, (byte)1 },
                    { 20, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7583), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7583), false, "2排3號", 1, (byte)1 },
                    { 21, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7585), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7586), false, "2排4號", 1, (byte)1 },
                    { 22, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7587), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7588), false, "2排5號", 1, (byte)1 },
                    { 23, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7590), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7590), false, "2排6號", 1, (byte)1 },
                    { 24, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7592), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7593), false, "2排7號", 1, (byte)1 },
                    { 25, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7595), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7595), false, "2排8號", 1, (byte)1 },
                    { 26, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7597), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7597), false, "2排9號", 1, (byte)1 },
                    { 27, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7599), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7600), false, "2排10號", 1, (byte)1 },
                    { 28, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7602), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7602), false, "2排11號", 1, (byte)1 },
                    { 29, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7604), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7604), false, "2排12號", 1, (byte)1 },
                    { 30, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7606), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7607), false, "2排13號", 1, (byte)1 },
                    { 31, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7608), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7609), false, "2排14號", 1, (byte)1 },
                    { 32, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7611), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7611), false, "2排15號", 1, (byte)1 },
                    { 33, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7613), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7614), false, "2排16號", 1, (byte)1 },
                    { 34, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7615), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7616), false, "2排17號", 1, (byte)1 },
                    { 35, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7618), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7619), false, "3排1號", 1, (byte)1 },
                    { 36, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7620), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7621), false, "3排2號", 1, (byte)1 },
                    { 37, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7623), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7623), false, "3排3號", 1, (byte)1 },
                    { 38, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7625), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7625), false, "3排4號", 1, (byte)1 },
                    { 39, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7627), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7628), false, "3排5號", 1, (byte)1 },
                    { 40, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7629), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7630), false, "3排6號", 1, (byte)1 },
                    { 41, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7632), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7632), false, "3排7號", 1, (byte)1 },
                    { 42, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7634), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7634), false, "3排8號", 1, (byte)1 },
                    { 43, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7636), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7637), false, "3排9號", 1, (byte)1 },
                    { 44, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7638), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7639), false, "3排10號", 1, (byte)1 },
                    { 45, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7641), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7641), false, "3排11號", 1, (byte)1 },
                    { 46, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7643), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7643), false, "3排12號", 1, (byte)1 },
                    { 47, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7645), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7646), false, "3排13號", 1, (byte)1 },
                    { 48, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7647), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7648), false, "3排14號", 1, (byte)1 },
                    { 49, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7649), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7650), false, "3排16號", 1, (byte)0 },
                    { 50, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7652), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7652), false, "3排17號", 1, (byte)0 },
                    { 51, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7654), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7654), false, "4排1號", 1, (byte)0 },
                    { 52, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7656), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7657), false, "4排2號", 1, (byte)0 },
                    { 53, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7658), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7659), false, "4排3號", 1, (byte)0 },
                    { 54, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7660), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7661), false, "4排4號", 1, (byte)0 },
                    { 55, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7663), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7663), false, "4排5號", 1, (byte)0 },
                    { 56, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7665), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7665), false, "4排6號", 1, (byte)0 },
                    { 57, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7667), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7668), false, "4排7號", 1, (byte)0 },
                    { 58, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7669), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7670), false, "4排8號", 1, (byte)0 },
                    { 59, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7672), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7673), false, "4排9號", 1, (byte)0 },
                    { 60, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7674), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7675), false, "4排10號", 1, (byte)0 },
                    { 61, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7676), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7677), false, "4排11號", 1, (byte)0 },
                    { 62, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7679), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7679), false, "4排12號", 1, (byte)0 },
                    { 63, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7681), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7681), false, "4排13號", 1, (byte)0 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EditedAt", "LastLogInAt" },
                values: new object[] { new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7472), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7473), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7458) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7478));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EditedAt", "LastLogInAt" },
                values: new object[] { new DateTime(2024, 3, 12, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7517), new DateTime(2024, 3, 20, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7518), new DateTime(2024, 3, 17, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7511) });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Capacity", "CoOrganizer", "ContactPerson", "CreatedAt", "Description", "EditedAt", "EndTime", "EventImage", "Introduction", "IsDeleted", "IsFree", "IsPrivateEvent", "Latitude", "LocationAddress", "LocationName", "Longitude", "MainOrganizer", "Name", "OrganizationId", "ParticipantPeople", "Sort", "StartTime", "Status", "StreamingPlatform", "StreamingUrl", "Type" },
                values: new object[,]
                {
                    { 1, 500, null, "", new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7749), "線上活動描述內容區", new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7750), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://picsum.photos/1300/600/?random=11", "線上活動簡介內容區", false, true, false, null, null, null, null, "Build School", "【線上直播課】掌握網路三大流量，讓你在同行中脫穎而出", 1, "[\r\n  {\r\n    \"ParticipantPeopleImage\": \"https://picsum.photos/200/200/?random=10\",\r\n    \"ParticipantPeopleId\": \"DDDD\"\r\n  },\r\n  {\r\n    \"ParticipantPeopleImage\": \"https://picsum.photos/200/200/?random=14\",\r\n    \"ParticipantPeopleId\": \"EEEE\"\r\n  },\r\n  {\r\n    \"ParticipantPeopleImage\": \"https://picsum.photos/200/200/?random=18\",\r\n    \"ParticipantPeopleId\": \"FFFF\"\r\n  }\r\n]\r\n", 0, new DateTime(2024, 4, 5, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7744), (byte)1, "http;", "http;", (byte)0 },
                    { 2, 1000, null, "", new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7758), "實體活動描述內容區", new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7759), new DateTime(2024, 4, 5, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7753), "https://picsum.photos/1300/600/?random=15", "實體活動簡介內容區", false, false, false, "120.33333", "", "大巨蛋", "120.33333", "卡米地", "【演唱會】五月天", 2, "[\r\n  {\r\n    \"ParticipantPeopleImage\": \"https://picsum.photos/200/200/?random=10\",\r\n    \"ParticipantPeopleId\": \"DDDD\"\r\n  },\r\n  {\r\n    \"ParticipantPeopleImage\": \"https://picsum.photos/200/200/?random=14\",\r\n    \"ParticipantPeopleId\": \"EEEE\"\r\n  },\r\n  {\r\n    \"ParticipantPeopleImage\": \"https://picsum.photos/200/200/?random=18\",\r\n    \"ParticipantPeopleId\": \"FFFF\"\r\n  }\r\n]\r\n", 0, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7752), (byte)1, null, null, (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "TicketTypes",
                columns: new[] { "Id", "CapacityAmount", "CreatedAt", "EditedAt", "EndSaleTime", "EventId", "IsDeleted", "IsDisplayed", "Name", "Price", "Sort", "StartSaleTime" },
                values: new object[,]
                {
                    { 1, 300, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7825), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7826), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7822), 1, false, false, "Free", 0m, (byte)0, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7821) },
                    { 2, 50, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7832), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7832), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7829), 2, false, false, "搖滾票", 6800m, (byte)0, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7828) },
                    { 3, 200, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7836), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7836), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7835), 2, false, false, "一般票", 2800m, (byte)0, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7834) },
                    { 4, 400, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7840), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7840), new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7839), 2, false, false, "站票", 800m, (byte)0, new DateTime(2024, 3, 22, 17, 27, 31, 686, DateTimeKind.Local).AddTicks(7838) }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_LogInInfo_Users_UserId",
                table: "LogInInfo",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogInInfo_Users_UserId",
                table: "LogInInfo");

            migrationBuilder.DeleteData(
                table: "CategoryTags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CategoryTags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CategoryTags",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EditedAt", "LastLogInAt" },
                values: new object[] { new DateTime(2024, 3, 17, 19, 37, 24, 144, DateTimeKind.Local).AddTicks(3123), new DateTime(2024, 3, 17, 19, 37, 24, 144, DateTimeKind.Local).AddTicks(3123), new DateTime(2024, 3, 17, 19, 37, 24, 144, DateTimeKind.Local).AddTicks(3109) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 19, 37, 24, 144, DateTimeKind.Local).AddTicks(3127));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EditedAt", "LastLogInAt" },
                values: new object[] { new DateTime(2024, 3, 7, 19, 37, 24, 144, DateTimeKind.Local).AddTicks(3134), new DateTime(2024, 3, 15, 19, 37, 24, 144, DateTimeKind.Local).AddTicks(3135), new DateTime(2024, 3, 12, 19, 37, 24, 144, DateTimeKind.Local).AddTicks(3130) });

            migrationBuilder.AddForeignKey(
                name: "FK_LogInInfo_Users",
                table: "LogInInfo",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
