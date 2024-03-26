using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Test03250921 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ArchiveOrders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1986));

            migrationBuilder.UpdateData(
                table: "ArchiveOrders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 24, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(2016));

            migrationBuilder.UpdateData(
                table: "CategoryTags",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EditeAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(885), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(888) });

            migrationBuilder.UpdateData(
                table: "CategoryTags",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EditeAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(893), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(895) });

            migrationBuilder.UpdateData(
                table: "CategoryTags",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EditeAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(899), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(902) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EditedAt", "StartTime" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(806), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(809), new DateTime(2024, 4, 8, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(788) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EditedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(834), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(836), new DateTime(2024, 4, 8, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(817), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(815) });

            migrationBuilder.UpdateData(
                table: "LogInInfo",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(81));

            migrationBuilder.UpdateData(
                table: "LogInInfo",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 24, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(170));

            migrationBuilder.UpdateData(
                table: "LogInInfo",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 23, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(177));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1432), new DateTime(2024, 3, 20, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1435) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 15, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1449));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1458), new DateTime(2024, 3, 13, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1460) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 5, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1468), new DateTime(2024, 3, 7, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1470) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 2, 29, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1477), new DateTime(2024, 3, 3, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1491) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 24, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1499));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 2, 19, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1505), new DateTime(2024, 2, 22, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1508) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 2, 14, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1515), new DateTime(2024, 2, 16, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1517) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 2, 9, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1524), new DateTime(2024, 2, 12, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1527) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1533));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 1, 30, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1541), new DateTime(2024, 2, 2, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1544) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 1, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1550), new DateTime(2024, 1, 27, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1556) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1563), new DateTime(2024, 1, 23, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1565) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 15, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1572));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 1, 10, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1579), new DateTime(2024, 1, 13, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1581) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 1, 5, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1588), new DateTime(2024, 1, 7, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1590) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2023, 12, 31, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1597), new DateTime(2024, 1, 3, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1600) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 26, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1606));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2023, 12, 21, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1613), new DateTime(2023, 12, 24, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1615) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2023, 12, 16, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1621), new DateTime(2023, 12, 18, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1624) });

            migrationBuilder.UpdateData(
                table: "OrgFan",
                keyColumn: "Id",
                keyValue: 1,
                column: "FanTime",
                value: new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1152));

            migrationBuilder.UpdateData(
                table: "OrgFan",
                keyColumn: "Id",
                keyValue: 2,
                column: "FanTime",
                value: new DateTime(2024, 3, 24, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1157));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1028), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1031) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1041), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1043) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1050), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1052) });

            migrationBuilder.UpdateData(
                table: "PreFill",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 15, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(2171));

            migrationBuilder.UpdateData(
                table: "PreFill",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 16, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(2180));

            migrationBuilder.UpdateData(
                table: "PreFill",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(2187));

            migrationBuilder.UpdateData(
                table: "SeatAreas",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(2071));

            migrationBuilder.UpdateData(
                table: "SeatAreas",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 11, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(2079));

            migrationBuilder.UpdateData(
                table: "SeatAreas",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "SeatAreas",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 13, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(2089));

            migrationBuilder.UpdateData(
                table: "SeatAreas",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 14, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(2093));

            migrationBuilder.UpdateData(
                table: "SeatAreas",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 15, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(2098));

            migrationBuilder.UpdateData(
                table: "SeatAreas",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 16, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(2103));

            migrationBuilder.UpdateData(
                table: "SeatAreas",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(2107));

            migrationBuilder.UpdateData(
                table: "SeatAreas",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(2112));

            migrationBuilder.UpdateData(
                table: "SeatAreas",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(2117));

            migrationBuilder.UpdateData(
                table: "SeatAreas",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 20, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(2121));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(234), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(237) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(244), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(262) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(285), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(288) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(293), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(295) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(302), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(304) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(309), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(311) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(315), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(318) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(323), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(325) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(330), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(332) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(337), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(339) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(343), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(345) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(350), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(352) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(356), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(358) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(363), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(365) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(369), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(371) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(376), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(378) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(382), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(384) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(389), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(391) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(396), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(397) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(402), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(404) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(409), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(411) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(416), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(418) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(423), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(424) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(429), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(431) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(436), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(438) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(442), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(444) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(452), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(454) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(459), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(460) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(465), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(467) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(472), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(474) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(478), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(480) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(485), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(489) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(494), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(496) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(500), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(502) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(507), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(509) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(514), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(516) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(521), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(523) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(528), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(530) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(534), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(536) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(541), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(543) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(547), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(549) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(554), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(556) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(561), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(563) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(567), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(569) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(574), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(576) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(580), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(582) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(589), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(591) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(596), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(598) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(603), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(605) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(609), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(611) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(616), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(618) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(622), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(625) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(629), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(631) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(636), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(638) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(642), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(644) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(649), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(651) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(656), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(658) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(662), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(664) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(669), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(671) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(676), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(678) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(690), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(692) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(696), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(698) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(703), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(704) });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EditedAt", "EndSaleTime", "StartSaleTime" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1330), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1332), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1321), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1319) });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EditedAt", "EndSaleTime", "StartSaleTime" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1350), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1352), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1341), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1338) });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EditedAt", "EndSaleTime", "StartSaleTime" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1363), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1365), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1359), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1357) });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EditedAt", "EndSaleTime", "StartSaleTime" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1374), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1376), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1371), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1369) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1677));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1686), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1689) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 23, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1697));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1704));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1710), new DateTime(2024, 3, 25, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(1712) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EditedAt", "LastLogInAt" },
                values: new object[] { new DateTime(2024, 3, 25, 21, 23, 3, 413, DateTimeKind.Local).AddTicks(9970), new DateTime(2024, 3, 25, 21, 23, 3, 413, DateTimeKind.Local).AddTicks(9974), new DateTime(2024, 3, 25, 21, 23, 3, 413, DateTimeKind.Local).AddTicks(9923) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 25, 21, 23, 3, 413, DateTimeKind.Local).AddTicks(9988));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EditedAt", "LastLogInAt" },
                values: new object[] { new DateTime(2024, 3, 15, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(12), new DateTime(2024, 3, 23, 21, 23, 3, 414, DateTimeKind.Local).AddTicks(15), new DateTime(2024, 3, 20, 21, 23, 3, 413, DateTimeKind.Local).AddTicks(9998) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ArchiveOrders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4798));

            migrationBuilder.UpdateData(
                table: "ArchiveOrders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 24, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4810));

            migrationBuilder.UpdateData(
                table: "CategoryTags",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EditeAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4311), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4311) });

            migrationBuilder.UpdateData(
                table: "CategoryTags",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EditeAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4314), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4314) });

            migrationBuilder.UpdateData(
                table: "CategoryTags",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EditeAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4316), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4317) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EditedAt", "StartTime" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4279), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4280), new DateTime(2024, 4, 8, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4273) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EditedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4288), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4288), new DateTime(2024, 4, 8, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4283), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4282) });

            migrationBuilder.UpdateData(
                table: "LogInInfo",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(3997));

            migrationBuilder.UpdateData(
                table: "LogInInfo",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 24, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(3999));

            migrationBuilder.UpdateData(
                table: "LogInInfo",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 23, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4002));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4518), new DateTime(2024, 3, 20, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4519) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 15, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4523));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4526), new DateTime(2024, 3, 13, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4527) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 5, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4530), new DateTime(2024, 3, 7, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4531) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 2, 29, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4534), new DateTime(2024, 3, 3, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4543) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 24, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4546));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 2, 19, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4549), new DateTime(2024, 2, 22, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4550) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 2, 14, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4579), new DateTime(2024, 2, 16, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4580) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 2, 9, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4583), new DateTime(2024, 2, 12, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4584) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 4, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4586));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 1, 30, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4589), new DateTime(2024, 2, 2, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4592) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 1, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4594), new DateTime(2024, 1, 27, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4595) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4598), new DateTime(2024, 1, 23, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4598) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 15, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4601));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 1, 10, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4603), new DateTime(2024, 1, 13, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4604) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 1, 5, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4607), new DateTime(2024, 1, 7, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2023, 12, 31, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4610), new DateTime(2024, 1, 3, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4611) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 26, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2023, 12, 21, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4616), new DateTime(2023, 12, 24, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4617) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2023, 12, 16, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4620), new DateTime(2023, 12, 18, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4621) });

            migrationBuilder.UpdateData(
                table: "OrgFan",
                keyColumn: "Id",
                keyValue: 1,
                column: "FanTime",
                value: new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4433));

            migrationBuilder.UpdateData(
                table: "OrgFan",
                keyColumn: "Id",
                keyValue: 2,
                column: "FanTime",
                value: new DateTime(2024, 3, 24, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4435));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4373), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4374) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4378), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4379) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4381), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4382) });

            migrationBuilder.UpdateData(
                table: "PreFill",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 15, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4880));

            migrationBuilder.UpdateData(
                table: "PreFill",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 16, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4883));

            migrationBuilder.UpdateData(
                table: "PreFill",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4885));

            migrationBuilder.UpdateData(
                table: "SeatAreas",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4837));

            migrationBuilder.UpdateData(
                table: "SeatAreas",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 11, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4840));

            migrationBuilder.UpdateData(
                table: "SeatAreas",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4842));

            migrationBuilder.UpdateData(
                table: "SeatAreas",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 13, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4843));

            migrationBuilder.UpdateData(
                table: "SeatAreas",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 14, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4845));

            migrationBuilder.UpdateData(
                table: "SeatAreas",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 15, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4847));

            migrationBuilder.UpdateData(
                table: "SeatAreas",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 16, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4848));

            migrationBuilder.UpdateData(
                table: "SeatAreas",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4850));

            migrationBuilder.UpdateData(
                table: "SeatAreas",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4851));

            migrationBuilder.UpdateData(
                table: "SeatAreas",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4855));

            migrationBuilder.UpdateData(
                table: "SeatAreas",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 20, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4857));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4032), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4033) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4036), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4047) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4059), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4060) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4062), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4063) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4064), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4065) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4067), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4068) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4070), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4070) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4072), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4073) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4075), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4075) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4077), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4077) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4079), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4080) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4082), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4082) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4084), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4084) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4088), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4088) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4090), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4090) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4092), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4093) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4095), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4095) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4097), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4097) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4099), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4100) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4102), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4102) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4104), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4104) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4106), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4107) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4109), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4109) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4111), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4111) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4113), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4114) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4115), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4116) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4121), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4121) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4123), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4124) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4125), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4126) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4128), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4128) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4130), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4131) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4132), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4133) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4135), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4135) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4137), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4137) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4139), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4140) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4141), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4142) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4144), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4144) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4146), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4147) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4148), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4149) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4152), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4152) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4154), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4155) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4156), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4157) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4158), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4159) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4161), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4161) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4163), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4163) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4165), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4166) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4167), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4168) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4170), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4170) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4172), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4173) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4174), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4175) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4177), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4177) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4179), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4180) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4182), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4183) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4185), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4185) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4187), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4188) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4189), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4190) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4192), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4192) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4194), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4195) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4196), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4197) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4199), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4199) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4201), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4202) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4203), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4204) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4234), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4234) });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EditedAt", "EndSaleTime", "StartSaleTime" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4479), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4479), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4476), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4475) });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EditedAt", "EndSaleTime", "StartSaleTime" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4485), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4486), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4482), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4481) });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EditedAt", "EndSaleTime", "StartSaleTime" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4489), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4490), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4488), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4488) });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EditedAt", "EndSaleTime", "StartSaleTime" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4493), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4493), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4492), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4491) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4651));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4654), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4655) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 23, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4658));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4660));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "EditedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4663), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4663) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EditedAt", "LastLogInAt" },
                values: new object[] { new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(3902), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(3903), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(3889) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(3909));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EditedAt", "LastLogInAt" },
                values: new object[] { new DateTime(2024, 3, 15, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(3918), new DateTime(2024, 3, 23, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(3919), new DateTime(2024, 3, 20, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(3912) });
        }
    }
}
