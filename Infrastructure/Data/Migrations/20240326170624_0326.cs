using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class _0326 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "區域ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "地區名稱")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                },
                comment: "偏好地區列表");

            migrationBuilder.CreateTable(
                name: "CategoryTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "類別TagID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "類別Tag名稱"),
                    Sort = table.Column<int>(type: "int", nullable: true, comment: "排序預設50"),
                    IsDeleted = table.Column<int>(type: "int", nullable: true, comment: "標記刪除"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, comment: "新增時間"),
                    EditeAt = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IsPaidRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "付款紀錄ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Result = table.Column<bool>(type: "bit", nullable: true, comment: "付款結果"),
                    OrderId = table.Column<int>(type: "int", nullable: false, comment: "訂單ID")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetail", x => x.Id);
                },
                comment: "付款紀錄");

            migrationBuilder.CreateTable(
                name: "SeatAreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "座位區域ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "座位區域名稱"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, comment: "新增時間"),
                    EditedAt = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改時間"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "標記封存")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "使用者ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nickname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "暱稱"),
                    Mobile = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "手機號碼"),
                    Birthday = table.Column<DateTime>(type: "date", nullable: false, comment: "生日"),
                    Gender = table.Column<byte>(type: "tinyint", nullable: true, comment: "性別"),
                    PersonalURL = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "個人網址"),
                    PersonalProfile = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true, comment: "個人簡介"),
                    EdmSubscription = table.Column<bool>(type: "bit", nullable: false, comment: "訂閱電子報"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "帳號照片"),
                    LastLogInAt = table.Column<DateTime>(type: "datetime", nullable: true, comment: "上次登入時間"),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, comment: "0未驗證EMAIL1已驗證EMAIL"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, comment: "新增時間"),
                    EditedAt = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "座位ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatAreaId = table.Column<int>(type: "int", nullable: false, comment: "座位區域ID"),
                    Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "座位號碼ex3排13號"),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, comment: "0可選1已選2不可選"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, comment: "新增時間"),
                    EditedAt = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改時間"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "標記封存")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_SeatAreas",
                        column: x => x.SeatAreaId,
                        principalTable: "SeatAreas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HistoryPassword",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false, comment: "使用者ID"),
                    UsedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "使用過的密碼"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, comment: "新增時間"),
                    EditedAt = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryPassword", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryPassword_Users1",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LogInInfo",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false, comment: "使用者ID"),
                    Account = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "帳號"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "電子郵件"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "密碼"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, comment: "新增時間"),
                    EditedAt = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogInInfo", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_LogInInfo_Users",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "訂單ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false, comment: "使用者ID"),
                    TicketId = table.Column<int>(type: "int", nullable: false, comment: "票券ID"),
                    SeatNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "座位號碼ex3排13號"),
                    PaymentType = table.Column<byte>(type: "tinyint", nullable: false, comment: "0免費1信用卡"),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, comment: "0待付款1成功2付款失敗3取消"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "標記封存"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, comment: "新增時間"),
                    EditedAt = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改時間"),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "聯絡人資料JSON"),
                    ParticipantPeople = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "報名人資料JSON"),
                    IsDisplayed = table.Column<bool>(type: "bit", nullable: false, comment: "0不顯示參加活動1顯示")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users1",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                },
                comment: "訂單");

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "組織ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<int>(type: "int", nullable: false, comment: "擁有者UserId"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "組織名稱"),
                    OrganizationURL = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "站內連結"),
                    OuterURL = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "站外連結"),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true, comment: "組織簡介"),
                    FBLink = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "FB連結"),
                    IGAccount = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "IG連結"),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "Email"),
                    ImgURL = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "組織形象圖"),
                    ContactName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "聯絡人姓名"),
                    ContactMobile = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "聯絡手機"),
                    ContactTelephone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "連絡電話"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, comment: "標記封存"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, comment: "新增時間"),
                    EditedAt = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_Users",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                },
                comment: "組織");

            migrationBuilder.CreateTable(
                name: "PreferredActivityArea",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "偏好區域ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false, comment: "使用者ID"),
                    AreaId = table.Column<int>(type: "int", nullable: false, comment: "區域ID")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferredActivityArea_1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreferredActivityArea_Area",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PreferredActivityArea_Users",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                },
                comment: "使用者偏好活動區域");

            migrationBuilder.CreateTable(
                name: "PreFill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "預填資料ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false, comment: "使用者ID"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "姓名"),
                    Mobile = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "手機號碼"),
                    PostalCode = table.Column<int>(type: "int", nullable: true, comment: "郵遞區號"),
                    County = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "縣市"),
                    District = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "鄉鎮區域"),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "聯絡地址"),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "公司名稱"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "職稱"),
                    CompanyPostalCode = table.Column<int>(type: "int", nullable: true, comment: "公司郵遞區號"),
                    CompanyAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "公司地址"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, comment: "新增時間"),
                    EditedAt = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prefill_1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreFill_Users",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                },
                comment: "報名預填資料");

            migrationBuilder.CreateTable(
                name: "ArchiveOrders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    EventStartTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "活動開始時間"),
                    EventName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "活動名稱"),
                    LocationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "活動地點"),
                    LocationAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "活動地址"),
                    StreamingPlatform = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "串流平台"),
                    StreamingUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "串流URL"),
                    TicketTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "票種名稱"),
                    TicketNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "票號"),
                    SeatNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "座位號碼ex3排13號"),
                    TicketPrice = table.Column<decimal>(type: "money", nullable: false, comment: "票價"),
                    PurchaseAmount = table.Column<int>(type: "int", nullable: false, comment: "購買數量"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "標記封存"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, comment: "新增時間"),
                    EditedAt = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchiveOrders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_ArchiveOrders_Orders",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                },
                comment: "訂單紀錄");

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "活動ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<int>(type: "int", nullable: false, comment: "組織ID"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "活動名稱"),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "開始時間"),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "結束時間"),
                    Type = table.Column<byte>(type: "tinyint", nullable: false, comment: "0線上1實體"),
                    LocationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "活動地點"),
                    LocationAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "活動地址"),
                    Longitude = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "經度"),
                    Latitude = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "緯度"),
                    StreamingPlatform = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "串流平台"),
                    StreamingUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "串流網址"),
                    Capacity = table.Column<int>(type: "int", nullable: true, comment: "可容納人數"),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "聯絡人欄位JSON"),
                    ParticipantPeople = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "報名人欄位JSON"),
                    EventImage = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "活動主圖"),
                    Introduction = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true, comment: "活動簡介"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "活動描述HTML"),
                    MainOrganizer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "主辦單位"),
                    CoOrganizer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "協辦單位"),
                    IsPrivateEvent = table.Column<bool>(type: "bit", nullable: false, comment: "是否公開活動"),
                    IsFree = table.Column<bool>(type: "bit", nullable: false, comment: "是否免費"),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, comment: "0未發佈1已發佈"),
                    Sort = table.Column<int>(type: "int", nullable: true, comment: "預設值50"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, comment: "資料封存或強制下架"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, comment: "新增時間"),
                    EditedAt = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Organizations",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrganizationAndUserMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "組織與使用者對照ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<int>(type: "int", nullable: false, comment: "組織ID"),
                    UserId = table.Column<int>(type: "int", nullable: false, comment: "使用者ID")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationUserMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationAndUserMapping_Organizations",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganizationAndUserMapping_Users",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                },
                comment: "組織與使用者對照");

            migrationBuilder.CreateTable(
                name: "OrgFan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "入坑ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<int>(type: "int", nullable: false, comment: "組織ID"),
                    UserId = table.Column<int>(type: "int", nullable: false, comment: "使用者ID"),
                    FanTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "成為粉絲時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgFan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrgFan_Organizations",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrgFan_Users",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                },
                comment: "組織粉絲");

            migrationBuilder.CreateTable(
                name: "EventAndTagMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "活動與類別對照ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryTagId = table.Column<int>(type: "int", nullable: false, comment: "類別TagID"),
                    EventID = table.Column<int>(type: "int", nullable: false, comment: "活動ID")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventAndTagMapping_1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event and Tag Mapping_Tags",
                        column: x => x.CategoryTagId,
                        principalTable: "CategoryTags",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EventAndTagMapping_pEvents",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "Id");
                },
                comment: "活動與類別對照");

            migrationBuilder.CreateTable(
                name: "TicketTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "票種ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false, comment: "活動ID"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "票種名稱"),
                    StartSaleTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "開始販售時間"),
                    EndSaleTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "結束販售時間"),
                    CapacityAmount = table.Column<int>(type: "int", nullable: false, comment: "票券數量"),
                    Price = table.Column<decimal>(type: "money", nullable: false, comment: "票價"),
                    Sort = table.Column<int>(type: "int", nullable: true, comment: "預設值50"),
                    IsDisplayed = table.Column<int>(type: "int", nullable: true, comment: "是否顯示"),
                    IsDeleted = table.Column<int>(type: "int", nullable: true, comment: "強制下架"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, comment: "新增時間"),
                    EditedAt = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketTypes_Events",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "票券ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: true, comment: "訂單ID"),
                    TicketTypeId = table.Column<int>(type: "int", nullable: false, comment: "票種ID"),
                    SeatId = table.Column<int>(type: "int", nullable: true, comment: "座位ID"),
                    Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "票號"),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, comment: "0未驗票1驗票成功"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "作廢票券"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, comment: "新增時間"),
                    EditedAt = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改時間"),
                    CheckCode = table.Column<int>(type: "int", nullable: true, comment: "檢查碼")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Orders",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_Seats",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_TicketTypes",
                        column: x => x.TicketTypeId,
                        principalTable: "TicketTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Area",
                columns: new[] { "Id", "Name" },
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

            migrationBuilder.InsertData(
                table: "CategoryTags",
                columns: new[] { "Id", "CreatedAt", "EditeAt", "IsDeleted", "Name", "Sort" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(112), new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(112), null, "音樂", null },
                    { 2, new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(115), new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(116), null, "戲劇", null },
                    { 3, new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(118), new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(118), null, "展覽", null }
                });

            migrationBuilder.InsertData(
                table: "SeatAreas",
                columns: new[] { "Id", "CreatedAt", "EditedAt", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 12, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9898), null, false, "1A區" },
                    { 2, new DateTime(2024, 3, 12, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9906), null, false, "2A區" },
                    { 3, new DateTime(2024, 3, 12, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9908), null, false, "2A區" },
                    { 4, new DateTime(2024, 3, 13, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9911), null, false, "2B區" },
                    { 5, new DateTime(2024, 3, 14, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9947), null, false, "2C區" },
                    { 6, new DateTime(2024, 3, 15, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9949), null, false, "2D區" },
                    { 7, new DateTime(2024, 3, 16, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9952), null, false, "2E區" },
                    { 8, new DateTime(2024, 3, 17, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9954), null, false, "2F區" },
                    { 9, new DateTime(2024, 3, 18, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9956), null, false, "2G區" },
                    { 10, new DateTime(2024, 3, 19, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9959), null, false, "3A區" },
                    { 11, new DateTime(2024, 3, 20, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9961), null, false, "3B區" },
                    { 12, new DateTime(2024, 3, 21, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9963), null, false, "3C區" },
                    { 13, new DateTime(2024, 3, 22, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9965), null, false, "3D區" },
                    { 14, new DateTime(2024, 3, 22, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9967), null, false, "3E區" },
                    { 15, new DateTime(2024, 3, 20, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9969), null, false, "3F區" },
                    { 16, new DateTime(2024, 3, 19, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9971), null, false, "3G區" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "CreatedAt", "EditedAt", "EdmSubscription", "Gender", "Image", "LastLogInAt", "Mobile", "Nickname", "PersonalProfile", "PersonalURL", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(9), new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(10), true, (byte)1, "https://image.com/alice.jpg", new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(8), "0912345678", "Alice", "I'm Alice!", "https://alice.com", (byte)1 },
                    { 2, new DateTime(1985, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(17), null, false, (byte)2, null, null, "0987654321", "Bob", null, null, (byte)0 },
                    { 3, new DateTime(1995, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 17, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(23), new DateTime(2024, 3, 25, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(24), true, (byte)2, "https://image.com/charlie.png", new DateTime(2024, 3, 22, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(21), "0955555555", "Charlie", "Hello world!", "https://charlie.com", (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "LogInInfo",
                columns: new[] { "UserId", "Account", "CreatedAt", "EditedAt", "Email", "Password" },
                values: new object[,]
                {
                    { 1, "abc123", new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(47), null, "abc@gmail.com", "12345678" },
                    { 2, "def456", new DateTime(2024, 3, 26, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(50), null, "def@gmail.com", "87654321" },
                    { 3, "ghi789", new DateTime(2024, 3, 25, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(53), null, "ghi@gmail.com", "98765432" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ContactPerson", "CreatedAt", "EditedAt", "IsDeleted", "IsDisplayed", "ParticipantPeople", "PaymentType", "SeatNumber", "Status", "TicketId", "UserId" },
                values: new object[,]
                {
                    { 1, "{\"Name\":\"John Doe\",\"Email\":\"john.doe@example.com\",\"Phone\":\"0912345678\"}", new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(351), new DateTime(2024, 3, 22, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(354), false, true, "{\"Name\":\"Jane Smith\",\"Age\":25}", (byte)1, "3排13號", (byte)1, 1, 1 },
                    { 2, "{\"Name\":\"Bob Johnson\",\"Email\":\"bob.johnson@example.com\",\"Phone\":\"0987654321\"}", new DateTime(2024, 3, 17, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(359), null, false, false, null, (byte)0, "5排8號", (byte)0, 2, 2 },
                    { 3, "{\"Name\":\"Emily Wilson\",\"Email\":\"emily.wilson@example.com\",\"Phone\":\"0923456789\"}", new DateTime(2024, 3, 12, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(363), new DateTime(2024, 3, 15, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(364), false, true, "{\"Name\":\"Michael Brown\",\"Age\":30}", (byte)1, "2排5號", (byte)2, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "ContactMobile", "ContactName", "ContactTelephone", "CreatedAt", "Description", "EditedAt", "Email", "FBLink", "IGAccount", "ImgURL", "IsDeleted", "Name", "OrganizationURL", "OuterURL", "OwnerId" },
                values: new object[,]
                {
                    { 1, "0123456789", "Alice", "02-2123-45678", new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(161), "組織簡介內容區", new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(162), null, null, null, null, null, "Build School", "HTTP", null, 1 },
                    { 2, "0123456789", "Bob", "02-2123-45678", new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(166), "組織簡介內容區", new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(167), null, null, null, null, null, "卡米地", "HTTP", null, 2 },
                    { 3, "0123456789", "Charlie", "02-2123-45678", new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(171), "組織簡介內容區", new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(172), null, null, null, null, null, "海邊的卡夫卡", "HTTP", null, 3 }
                });

            migrationBuilder.InsertData(
                table: "PreFill",
                columns: new[] { "Id", "Address", "CompanyAddress", "CompanyName", "CompanyPostalCode", "County", "CreatedAt", "District", "EditedAt", "Mobile", "Name", "PostalCode", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "No.1, Lane 10, Section 3, Zhongxiao E Rd", null, null, null, "Taipei", new DateTime(2024, 3, 17, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(567), "Daan", null, "0912345678", "John Doe", 106, null, 1 },
                    { 2, "No.100, Guandu Rd", null, null, null, "New Taipei", new DateTime(2024, 3, 18, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(572), "Banqiao", null, "0912345679", "Jane Doe", 107, null, 2 },
                    { 3, "No.20, Jhongsing Rd", null, null, null, "Taoyuan", new DateTime(2024, 3, 19, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(576), "Zhongli", null, "0923456789", "Mike Chen", 108, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "PreferredActivityArea",
                columns: new[] { "Id", "AreaId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 2 },
                    { 4, 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreatedAt", "EditedAt", "IsDeleted", "Number", "SeatAreaId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8162), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8174), false, "1排1號", 1, (byte)1 },
                    { 2, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8181), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8181), false, "1排2號", 1, (byte)1 },
                    { 3, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8184), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8185), false, "1排3號", 1, (byte)1 },
                    { 4, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8187), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8188), false, "1排4號", 1, (byte)1 },
                    { 5, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8190), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8191), false, "1排5號", 1, (byte)1 },
                    { 6, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8193), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8194), false, "1排6號", 1, (byte)1 },
                    { 7, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8196), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8197), false, "1排7號", 1, (byte)1 },
                    { 8, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8199), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8200), false, "1排8號", 1, (byte)1 },
                    { 9, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8202), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8203), false, "1排9號", 1, (byte)1 },
                    { 10, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8205), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8206), false, "1排10號", 1, (byte)1 },
                    { 11, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8208), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8209), false, "1排11號", 1, (byte)1 },
                    { 12, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8212), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8212), false, "1排12號", 1, (byte)1 },
                    { 13, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8215), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8215), false, "1排13號", 1, (byte)1 },
                    { 14, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8218), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8218), false, "1排14號", 1, (byte)1 },
                    { 15, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8220), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8221), false, "1排15號", 1, (byte)1 },
                    { 16, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8223), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8224), false, "1排16號", 1, (byte)1 },
                    { 17, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8226), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8227), false, "1排17號", 1, (byte)1 },
                    { 18, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8229), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8230), false, "2排1號", 1, (byte)1 },
                    { 19, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8232), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8232), false, "2排2號", 1, (byte)1 },
                    { 20, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8235), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8235), false, "2排3號", 1, (byte)1 },
                    { 21, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8237), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8238), false, "2排4號", 1, (byte)1 },
                    { 22, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8240), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8241), false, "2排5號", 1, (byte)1 },
                    { 23, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8243), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8243), false, "2排6號", 1, (byte)1 },
                    { 24, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8245), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8246), false, "2排7號", 1, (byte)1 },
                    { 25, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8248), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8249), false, "2排8號", 1, (byte)1 },
                    { 26, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8251), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8252), false, "2排9號", 1, (byte)1 },
                    { 27, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8254), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8254), false, "2排10號", 1, (byte)1 },
                    { 28, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8256), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8257), false, "2排11號", 1, (byte)1 },
                    { 29, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8259), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8260), false, "2排12號", 1, (byte)1 },
                    { 30, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8262), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8263), false, "2排13號", 1, (byte)1 },
                    { 31, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8265), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8265), false, "2排14號", 1, (byte)1 },
                    { 32, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8267), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8268), false, "2排15號", 1, (byte)1 },
                    { 33, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8270), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8271), false, "2排16號", 1, (byte)1 },
                    { 34, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8273), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8273), false, "2排17號", 1, (byte)1 },
                    { 35, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8276), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8276), false, "3排1號", 1, (byte)1 },
                    { 36, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8278), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8279), false, "3排2號", 1, (byte)1 },
                    { 37, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8281), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8282), false, "3排3號", 1, (byte)1 },
                    { 38, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8317), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8318), false, "3排4號", 1, (byte)1 },
                    { 39, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8320), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8321), false, "3排5號", 1, (byte)1 },
                    { 40, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8323), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8323), false, "3排6號", 1, (byte)1 },
                    { 41, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8325), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8326), false, "3排7號", 1, (byte)1 },
                    { 42, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8328), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8329), false, "3排8號", 1, (byte)1 },
                    { 43, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8331), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8331), false, "3排9號", 1, (byte)1 },
                    { 44, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8333), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8334), false, "3排10號", 1, (byte)1 },
                    { 45, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8336), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8337), false, "3排11號", 1, (byte)1 },
                    { 46, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8340), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8341), false, "3排12號", 1, (byte)1 },
                    { 47, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8343), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8343), false, "3排13號", 1, (byte)1 },
                    { 48, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8345), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8346), false, "3排14號", 1, (byte)1 },
                    { 49, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8349), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8350), false, "3排16號", 1, (byte)0 },
                    { 50, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8352), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8353), false, "3排17號", 1, (byte)0 },
                    { 51, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8356), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8357), false, "4排1號", 1, (byte)0 },
                    { 52, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8359), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8360), false, "4排2號", 1, (byte)0 },
                    { 53, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8362), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8362), false, "4排3號", 1, (byte)0 },
                    { 54, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8364), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8365), false, "4排4號", 1, (byte)0 },
                    { 55, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8367), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8368), false, "4排5號", 1, (byte)0 },
                    { 56, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8370), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8371), false, "4排6號", 1, (byte)0 },
                    { 57, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8373), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8373), false, "4排7號", 1, (byte)0 },
                    { 58, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8375), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8376), false, "4排8號", 1, (byte)0 },
                    { 59, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8378), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8379), false, "4排9號", 1, (byte)0 },
                    { 60, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8381), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8381), false, "4排10號", 1, (byte)0 },
                    { 61, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8383), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8384), false, "4排11號", 1, (byte)0 },
                    { 62, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8386), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8387), false, "4排12號", 1, (byte)0 },
                    { 63, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8389), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8389), false, "4排13號", 1, (byte)0 },
                    { 64, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8391), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8392), false, "1排1號", 2, (byte)1 },
                    { 65, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8394), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8394), false, "1排2號", 2, (byte)1 },
                    { 66, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8396), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8397), false, "1排3號", 2, (byte)1 },
                    { 67, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8399), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8400), false, "1排5號", 2, (byte)1 },
                    { 68, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8403), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8404), false, "1排6號", 2, (byte)1 },
                    { 69, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8407), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8408), false, "1排7號", 2, (byte)1 },
                    { 70, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8410), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8410), false, "1排8號", 2, (byte)1 },
                    { 71, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8412), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8413), false, "1排9號", 2, (byte)1 },
                    { 72, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8415), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8416), false, "1排10號", 2, (byte)1 },
                    { 73, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8418), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8418), false, "1排11號", 2, (byte)1 },
                    { 74, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8420), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8421), false, "1排12號", 2, (byte)1 },
                    { 75, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8423), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8424), false, "1排13號", 2, (byte)1 },
                    { 76, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8426), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8426), false, "1排14號", 2, (byte)1 },
                    { 77, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8429), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8429), false, "1排15號", 2, (byte)1 },
                    { 78, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8431), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8432), false, "1排16號", 2, (byte)1 },
                    { 79, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8434), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8435), false, "1排17號", 2, (byte)1 },
                    { 80, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8437), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8437), false, "2排1號", 2, (byte)1 },
                    { 81, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8441), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8442), false, "2排2號", 2, (byte)1 },
                    { 82, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8445), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8446), false, "2排3號", 2, (byte)1 },
                    { 83, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8450), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8450), false, "2排4號", 2, (byte)1 },
                    { 84, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8453), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8453), false, "2排5號", 2, (byte)1 },
                    { 85, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8455), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8456), false, "2排6號", 2, (byte)1 },
                    { 86, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8459), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8459), false, "2排7號", 2, (byte)1 },
                    { 87, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8462), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8463), false, "2排8號", 2, (byte)1 },
                    { 88, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8465), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8466), false, "2排9號", 2, (byte)1 },
                    { 89, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8470), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8471), false, "2排10號", 2, (byte)1 },
                    { 90, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8476), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8477), false, "2排11號", 2, (byte)1 },
                    { 91, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8482), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8483), false, "2排12號", 2, (byte)1 },
                    { 92, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8486), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8487), false, "2排13號", 2, (byte)1 },
                    { 93, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8490), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8491), false, "2排14號", 2, (byte)1 },
                    { 94, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8493), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8494), false, "2排15號", 2, (byte)1 },
                    { 95, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8496), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8496), false, "2排16號", 2, (byte)1 },
                    { 96, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8502), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8503), false, "2排17號", 2, (byte)1 },
                    { 97, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8505), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8506), false, "3排1號", 2, (byte)1 },
                    { 98, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8509), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8510), false, "3排2號", 2, (byte)1 },
                    { 99, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8515), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8516), false, "3排3號", 2, (byte)1 },
                    { 100, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8518), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8519), false, "3排4號", 2, (byte)1 },
                    { 101, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8523), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8524), false, "3排5號", 2, (byte)1 },
                    { 102, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8527), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8528), false, "3排6號", 2, (byte)1 },
                    { 103, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8530), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8531), false, "3排7號", 2, (byte)1 },
                    { 104, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8533), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8533), false, "3排8號", 2, (byte)1 },
                    { 105, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8535), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8536), false, "3排9號", 2, (byte)1 },
                    { 106, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8540), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8541), false, "3排10號", 2, (byte)1 },
                    { 107, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8546), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8547), false, "3排11號", 2, (byte)1 },
                    { 108, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8550), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8551), false, "3排12號", 2, (byte)1 },
                    { 109, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8556), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8556), false, "3排13號", 2, (byte)1 },
                    { 110, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8560), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8561), false, "3排14號", 2, (byte)1 },
                    { 111, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8599), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8600), false, "3排16號", 2, (byte)0 },
                    { 112, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8604), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8605), false, "3排17號", 2, (byte)0 },
                    { 113, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8609), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8610), false, "4排1號", 2, (byte)0 },
                    { 114, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8612), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8613), false, "4排2號", 2, (byte)0 },
                    { 115, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8619), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8620), false, "4排3號", 2, (byte)0 },
                    { 116, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8622), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8622), false, "4排4號", 2, (byte)0 },
                    { 117, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8627), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8627), false, "4排5號", 2, (byte)0 },
                    { 118, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8630), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8630), false, "4排6號", 2, (byte)0 },
                    { 119, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8632), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8633), false, "4排7號", 2, (byte)0 },
                    { 120, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8636), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8637), false, "4排8號", 2, (byte)0 },
                    { 121, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8639), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8640), false, "4排9號", 2, (byte)0 },
                    { 122, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8644), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8645), false, "4排10號", 2, (byte)0 },
                    { 123, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8648), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8650), false, "4排11號", 2, (byte)0 },
                    { 124, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8654), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8654), false, "4排12號", 2, (byte)0 },
                    { 125, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8656), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8657), false, "4排13號", 2, (byte)0 },
                    { 126, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8659), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8659), false, "1排1號", 3, (byte)1 },
                    { 127, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8662), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8663), false, "1排2號", 3, (byte)1 },
                    { 128, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8666), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8666), false, "1排3號", 3, (byte)1 },
                    { 129, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8669), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8670), false, "1排4號", 3, (byte)1 },
                    { 130, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8672), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8674), false, "1排5號", 3, (byte)1 },
                    { 131, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8676), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8676), false, "1排6號", 3, (byte)1 },
                    { 132, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8678), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8679), false, "1排7號", 3, (byte)1 },
                    { 133, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8683), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8684), false, "1排8號", 3, (byte)1 },
                    { 134, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8688), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8689), false, "1排9號", 3, (byte)1 },
                    { 135, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8693), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8694), false, "1排10號", 3, (byte)1 },
                    { 136, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8698), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8699), false, "1排11號", 3, (byte)1 },
                    { 137, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8701), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8701), false, "1排12號", 3, (byte)1 },
                    { 138, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8703), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8704), false, "1排13號", 3, (byte)1 },
                    { 139, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8706), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8707), false, "1排14號", 3, (byte)1 },
                    { 140, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8709), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8709), false, "1排15號", 3, (byte)1 },
                    { 141, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8711), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8712), false, "1排16號", 3, (byte)1 },
                    { 142, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8714), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8715), false, "1排17號", 3, (byte)1 },
                    { 143, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8717), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8717), false, "2排1號", 3, (byte)1 },
                    { 144, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8719), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8720), false, "2排2號", 3, (byte)1 },
                    { 145, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8722), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8723), false, "2排3號", 3, (byte)1 },
                    { 146, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8725), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8725), false, "2排4號", 3, (byte)1 },
                    { 147, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8727), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8728), false, "2排5號", 3, (byte)1 },
                    { 148, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8730), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8731), false, "2排6號", 3, (byte)1 },
                    { 149, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8733), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8733), false, "2排7號", 3, (byte)1 },
                    { 150, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8735), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8736), false, "2排8號", 3, (byte)1 },
                    { 151, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8738), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8739), false, "2排9號", 3, (byte)1 },
                    { 152, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8741), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8741), false, "2排10號", 3, (byte)1 },
                    { 153, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8743), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8744), false, "2排11號", 3, (byte)1 },
                    { 154, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8746), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8746), false, "2排12號", 3, (byte)1 },
                    { 155, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8748), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8749), false, "2排13號", 3, (byte)1 },
                    { 156, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8751), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8752), false, "2排14號", 3, (byte)1 },
                    { 157, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8754), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8754), false, "2排15號", 3, (byte)1 },
                    { 158, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8757), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8757), false, "2排16號", 3, (byte)1 },
                    { 159, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8759), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8760), false, "2排17號", 3, (byte)1 },
                    { 160, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8762), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8763), false, "3排1號", 3, (byte)1 },
                    { 161, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8765), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8765), false, "3排2號", 3, (byte)1 },
                    { 162, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8768), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8768), false, "3排3號", 3, (byte)1 },
                    { 163, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8770), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8771), false, "3排4號", 3, (byte)1 },
                    { 164, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8773), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8773), false, "3排5號", 3, (byte)1 },
                    { 165, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8775), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8776), false, "3排6號", 3, (byte)1 },
                    { 166, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8778), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8779), false, "3排7號", 3, (byte)1 },
                    { 167, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8781), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8781), false, "3排8號", 3, (byte)1 },
                    { 168, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8784), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8784), false, "3排9號", 3, (byte)1 },
                    { 169, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8786), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8787), false, "3排10號", 3, (byte)1 },
                    { 170, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8789), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8790), false, "3排11號", 3, (byte)1 },
                    { 171, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8792), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8792), false, "3排12號", 3, (byte)1 },
                    { 172, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8794), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8795), false, "3排13號", 3, (byte)1 },
                    { 173, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8797), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8798), false, "3排14號", 3, (byte)1 },
                    { 174, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8800), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8800), false, "3排16號", 3, (byte)0 },
                    { 175, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8802), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8803), false, "3排17號", 3, (byte)0 },
                    { 176, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8805), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8806), false, "4排1號", 3, (byte)0 },
                    { 177, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8808), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8808), false, "4排2號", 3, (byte)0 },
                    { 178, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8810), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8811), false, "4排3號", 3, (byte)0 },
                    { 179, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8813), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8814), false, "4排4號", 3, (byte)0 },
                    { 180, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8816), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8816), false, "4排5號", 3, (byte)0 },
                    { 181, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8818), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8819), false, "4排6號", 3, (byte)0 },
                    { 182, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8821), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8822), false, "4排7號", 3, (byte)0 },
                    { 183, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8824), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8825), false, "4排8號", 3, (byte)0 },
                    { 184, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8878), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8878), false, "4排9號", 3, (byte)0 },
                    { 185, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8881), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8881), false, "4排10號", 3, (byte)0 },
                    { 186, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8883), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8884), false, "4排11號", 3, (byte)0 },
                    { 187, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8886), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8887), false, "4排12號", 3, (byte)0 },
                    { 188, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8889), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8890), false, "4排13號", 3, (byte)0 },
                    { 189, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8894), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8894), false, "1排1號", 4, (byte)1 },
                    { 190, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8897), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8897), false, "1排2號", 4, (byte)1 },
                    { 191, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8899), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8900), false, "1排3號", 4, (byte)1 },
                    { 192, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8902), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8903), false, "1排4號", 4, (byte)1 },
                    { 193, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8905), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8905), false, "1排5號", 4, (byte)1 },
                    { 194, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8908), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8908), false, "1排6號", 4, (byte)1 },
                    { 195, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8910), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8911), false, "1排7號", 4, (byte)1 },
                    { 196, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8913), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8914), false, "1排8號", 4, (byte)1 },
                    { 197, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8916), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8916), false, "1排9號", 4, (byte)1 },
                    { 198, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8919), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8919), false, "1排10號", 4, (byte)1 },
                    { 199, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8921), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8922), false, "1排11號", 4, (byte)1 },
                    { 200, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8924), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8925), false, "1排12號", 4, (byte)1 },
                    { 201, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8927), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8927), false, "1排13號", 4, (byte)1 },
                    { 202, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8929), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8930), false, "1排14號", 4, (byte)1 },
                    { 203, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8932), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8933), false, "1排15號", 4, (byte)1 },
                    { 204, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8935), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8936), false, "1排16號", 4, (byte)1 },
                    { 205, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8938), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8938), false, "1排17號", 4, (byte)1 },
                    { 206, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8940), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8941), false, "2排1號", 4, (byte)1 },
                    { 207, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8943), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8944), false, "2排2號", 4, (byte)1 },
                    { 208, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8946), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8947), false, "2排3號", 4, (byte)1 },
                    { 209, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8949), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8950), false, "2排4號", 4, (byte)1 },
                    { 210, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8952), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8952), false, "2排5號", 4, (byte)1 },
                    { 211, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8954), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8955), false, "2排6號", 4, (byte)1 },
                    { 212, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8957), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8958), false, "2排7號", 4, (byte)1 },
                    { 213, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8960), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8960), false, "2排8號", 4, (byte)1 },
                    { 214, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8962), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8963), false, "2排9號", 4, (byte)1 },
                    { 215, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8965), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8965), false, "2排10號", 4, (byte)1 },
                    { 216, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8968), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8968), false, "2排11號", 4, (byte)1 },
                    { 217, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8970), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8971), false, "2排12號", 4, (byte)1 },
                    { 218, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8973), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8974), false, "2排13號", 4, (byte)1 },
                    { 219, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8976), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8977), false, "2排14號", 4, (byte)1 },
                    { 220, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8979), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8979), false, "2排15號", 4, (byte)1 },
                    { 221, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8981), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8982), false, "2排16號", 4, (byte)1 },
                    { 222, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8984), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8985), false, "2排17號", 4, (byte)1 },
                    { 223, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8987), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8988), false, "3排1號", 4, (byte)1 },
                    { 224, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8990), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8990), false, "3排2號", 4, (byte)1 },
                    { 225, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8992), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8993), false, "3排3號", 4, (byte)1 },
                    { 226, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8995), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8996), false, "3排4號", 4, (byte)1 },
                    { 227, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8998), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(8998), false, "3排5號", 4, (byte)1 },
                    { 228, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9001), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9001), false, "3排6號", 4, (byte)1 },
                    { 229, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9003), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9004), false, "3排7號", 4, (byte)1 },
                    { 230, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9006), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9006), false, "3排8號", 4, (byte)1 },
                    { 231, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9009), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9009), false, "3排9號", 4, (byte)1 },
                    { 232, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9011), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9012), false, "3排10號", 4, (byte)1 },
                    { 233, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9014), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9014), false, "3排11號", 4, (byte)1 },
                    { 234, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9017), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9017), false, "3排12號", 4, (byte)1 },
                    { 235, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9019), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9020), false, "3排13號", 4, (byte)1 },
                    { 236, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9022), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9023), false, "3排14號", 4, (byte)1 },
                    { 237, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9025), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9025), false, "3排16號", 4, (byte)0 },
                    { 238, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9027), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9028), false, "3排17號", 4, (byte)0 },
                    { 239, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9030), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9031), false, "4排1號", 4, (byte)0 },
                    { 240, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9033), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9034), false, "4排2號", 4, (byte)0 },
                    { 241, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9036), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9036), false, "4排3號", 4, (byte)0 },
                    { 242, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9038), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9039), false, "4排4號", 4, (byte)0 },
                    { 243, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9041), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9042), false, "4排5號", 4, (byte)0 },
                    { 244, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9044), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9044), false, "4排6號", 4, (byte)0 },
                    { 245, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9047), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9047), false, "4排7號", 4, (byte)0 },
                    { 246, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9060), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9061), false, "1排1號", 5, (byte)1 },
                    { 247, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9063), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9064), false, "1排2號", 5, (byte)1 },
                    { 248, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9049), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9050), false, "4排10號", 4, (byte)0 },
                    { 249, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9052), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9053), false, "4排11號", 4, (byte)0 },
                    { 250, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9055), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9055), false, "4排12號", 4, (byte)0 },
                    { 251, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9057), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9058), false, "4排13號", 4, (byte)0 },
                    { 252, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9066), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9067), false, "1排7號", 5, (byte)1 },
                    { 253, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9069), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9069), false, "1排8號", 5, (byte)1 },
                    { 254, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9071), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9072), false, "1排9號", 5, (byte)1 },
                    { 255, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9074), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9075), false, "1排10號", 5, (byte)1 },
                    { 256, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9077), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9077), false, "1排11號", 5, (byte)1 },
                    { 257, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9110), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9111), false, "1排12號", 5, (byte)1 },
                    { 258, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9113), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9114), false, "1排13號", 5, (byte)1 },
                    { 259, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9116), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9117), false, "1排14號", 5, (byte)1 },
                    { 260, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9119), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9120), false, "1排15號", 5, (byte)1 },
                    { 261, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9122), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9123), false, "1排16號", 5, (byte)1 },
                    { 262, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9125), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9125), false, "1排17號", 5, (byte)1 },
                    { 263, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9128), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9128), false, "2排1號", 5, (byte)1 },
                    { 264, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9132), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9133), false, "2排2號", 5, (byte)1 },
                    { 265, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9135), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9135), false, "2排3號", 5, (byte)1 },
                    { 266, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9138), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9138), false, "2排4號", 5, (byte)1 },
                    { 267, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9140), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9141), false, "2排5號", 5, (byte)1 },
                    { 268, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9143), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9144), false, "2排6號", 5, (byte)1 },
                    { 269, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9146), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9147), false, "2排7號", 5, (byte)1 },
                    { 270, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9149), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9149), false, "2排8號", 5, (byte)1 },
                    { 271, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9151), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9152), false, "2排9號", 5, (byte)1 },
                    { 272, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9154), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9155), false, "2排10號", 5, (byte)1 },
                    { 273, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9157), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9158), false, "2排11號", 5, (byte)1 },
                    { 274, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9160), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9160), false, "2排12號", 5, (byte)1 },
                    { 275, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9162), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9163), false, "2排13號", 5, (byte)1 },
                    { 276, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9165), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9166), false, "2排14號", 5, (byte)1 },
                    { 277, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9168), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9169), false, "2排15號", 5, (byte)1 },
                    { 278, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9171), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9171), false, "2排16號", 5, (byte)1 },
                    { 279, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9174), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9174), false, "2排17號", 5, (byte)1 },
                    { 280, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9176), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9177), false, "3排1號", 5, (byte)1 },
                    { 281, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9179), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9180), false, "3排2號", 5, (byte)1 },
                    { 282, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9182), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9182), false, "3排3號", 5, (byte)1 },
                    { 283, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9185), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9185), false, "3排4號", 5, (byte)1 },
                    { 284, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9187), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9188), false, "3排5號", 5, (byte)1 },
                    { 285, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9190), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9191), false, "3排6號", 5, (byte)1 },
                    { 286, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9193), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9193), false, "3排7號", 5, (byte)1 },
                    { 287, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9195), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9196), false, "3排8號", 5, (byte)1 },
                    { 288, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9198), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9199), false, "3排9號", 5, (byte)1 },
                    { 289, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9201), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9201), false, "3排10號", 5, (byte)1 },
                    { 290, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9204), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9204), false, "3排11號", 5, (byte)1 },
                    { 291, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9206), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9207), false, "3排12號", 5, (byte)1 },
                    { 292, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9209), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9210), false, "3排13號", 5, (byte)1 },
                    { 293, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9212), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9212), false, "3排14號", 5, (byte)1 },
                    { 294, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9214), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9215), false, "3排16號", 5, (byte)0 },
                    { 295, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9217), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9218), false, "3排17號", 5, (byte)0 },
                    { 296, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9220), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9220), false, "4排1號", 5, (byte)0 },
                    { 297, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9222), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9223), false, "4排2號", 5, (byte)0 },
                    { 298, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9225), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9226), false, "4排3號", 5, (byte)0 },
                    { 299, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9228), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9228), false, "4排4號", 5, (byte)0 },
                    { 300, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9230), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9231), false, "4排5號", 5, (byte)0 },
                    { 301, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9233), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9234), false, "4排6號", 5, (byte)0 },
                    { 302, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9236), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9236), false, "4排7號", 5, (byte)0 },
                    { 303, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9239), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9239), false, "4排8號", 5, (byte)0 },
                    { 304, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9241), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9242), false, "4排9號", 5, (byte)0 },
                    { 305, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9244), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9245), false, "4排10號", 5, (byte)0 },
                    { 306, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9247), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9247), false, "4排11號", 5, (byte)0 },
                    { 307, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9249), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9250), false, "4排12號", 5, (byte)0 },
                    { 308, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9252), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9253), false, "4排13號", 5, (byte)0 },
                    { 309, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9255), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9255), false, "4排15號", 5, (byte)0 },
                    { 310, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9257), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9258), false, "4排16號", 5, (byte)0 },
                    { 311, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9260), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9261), false, "4排17號", 5, (byte)0 },
                    { 312, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9263), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9263), false, "5排1號", 5, (byte)0 },
                    { 313, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9265), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9266), false, "5排2號", 5, (byte)0 },
                    { 314, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9268), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9269), false, "5排3號", 5, (byte)0 },
                    { 315, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9271), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9271), false, "5排4號", 5, (byte)0 },
                    { 316, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9274), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9274), false, "5排5號", 5, (byte)0 },
                    { 317, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9276), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9277), false, "5排6號", 5, (byte)0 },
                    { 318, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9279), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9280), false, "5排7號", 5, (byte)0 },
                    { 319, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9282), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9282), false, "5排8號", 5, (byte)0 },
                    { 320, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9284), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9285), false, "4排5號", 6, (byte)0 },
                    { 321, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9287), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9288), false, "4排6號", 6, (byte)0 },
                    { 322, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9290), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9290), false, "4排7號", 6, (byte)0 },
                    { 323, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9293), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9293), false, "4排8號", 6, (byte)0 },
                    { 324, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9295), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9296), false, "4排9號", 6, (byte)0 },
                    { 325, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9298), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9299), false, "4排10號", 6, (byte)0 },
                    { 326, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9301), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9301), false, "4排11號", 6, (byte)0 },
                    { 327, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9303), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9304), false, "4排12號", 6, (byte)0 },
                    { 328, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9306), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9307), false, "4排13號", 6, (byte)0 },
                    { 329, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9309), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9310), false, "4排14號", 6, (byte)0 },
                    { 330, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9341), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9342), false, "2排2號", 7, (byte)1 },
                    { 331, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9345), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9346), false, "2排3號", 7, (byte)1 },
                    { 332, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9348), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9348), false, "2排4號", 7, (byte)1 },
                    { 333, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9350), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9351), false, "2排5號", 7, (byte)1 },
                    { 334, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9353), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9354), false, "2排6號", 7, (byte)1 },
                    { 335, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9356), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9357), false, "2排7號", 7, (byte)1 },
                    { 336, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9359), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9359), false, "2排8號", 7, (byte)1 },
                    { 337, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9361), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9362), false, "2排9號", 7, (byte)1 },
                    { 338, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9364), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9366), false, "2排10號", 7, (byte)1 },
                    { 339, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9368), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9368), false, "2排11號", 7, (byte)1 },
                    { 340, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9370), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9371), false, "4排10號", 7, (byte)0 },
                    { 341, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9373), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9374), false, "4排11號", 7, (byte)0 },
                    { 342, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9376), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9376), false, "4排12號", 7, (byte)0 },
                    { 343, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9378), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9379), false, "4排13號", 7, (byte)0 },
                    { 344, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9381), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9382), false, "4排14號", 7, (byte)0 },
                    { 345, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9384), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9384), false, "4排15號", 7, (byte)0 },
                    { 346, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9386), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9387), false, "4排16號", 7, (byte)0 },
                    { 347, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9389), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9390), false, "4排17號", 7, (byte)0 },
                    { 348, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9392), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9392), false, "4排5號", 8, (byte)0 },
                    { 349, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9395), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9395), false, "4排6號", 8, (byte)0 },
                    { 350, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9397), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9398), false, "4排7號", 8, (byte)0 },
                    { 351, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9400), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9401), false, "4排8號", 8, (byte)0 },
                    { 352, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9403), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9403), false, "4排9號", 8, (byte)0 },
                    { 353, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9406), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9406), false, "4排10號", 8, (byte)0 },
                    { 354, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9408), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9409), false, "4排11號", 8, (byte)0 },
                    { 355, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9411), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9411), false, "4排12號", 8, (byte)0 },
                    { 356, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9413), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9414), false, "3排18號", 9, (byte)0 },
                    { 357, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9416), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9417), false, "3排19號", 9, (byte)0 },
                    { 358, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9419), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9419), false, "3排20號", 9, (byte)0 },
                    { 359, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9421), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9422), false, "3排21號", 9, (byte)0 },
                    { 360, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9424), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9425), false, "3排22號", 9, (byte)0 },
                    { 361, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9427), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9428), false, "3排23號", 9, (byte)0 },
                    { 362, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9430), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9430), false, "3排24號", 9, (byte)0 },
                    { 363, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9432), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9433), false, "3排25號", 9, (byte)0 },
                    { 364, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9435), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9436), false, "3排12號", 10, (byte)1 },
                    { 365, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9438), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9438), false, "3排13號", 10, (byte)1 },
                    { 366, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9440), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9441), false, "3排14號", 10, (byte)1 },
                    { 367, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9443), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9444), false, "3排15號", 10, (byte)1 },
                    { 368, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9446), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9446), false, "3排16號", 10, (byte)1 },
                    { 369, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9448), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9449), false, "3排17號", 10, (byte)1 },
                    { 370, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9451), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9452), false, "3排18號", 10, (byte)1 },
                    { 371, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9454), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9454), false, "3排19號", 10, (byte)1 },
                    { 372, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9456), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9457), false, "3排20號", 10, (byte)1 },
                    { 373, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9459), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9460), false, "3排21號", 10, (byte)1 },
                    { 374, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9462), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9462), false, "3排6號", 11, (byte)1 },
                    { 375, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9464), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9465), false, "3排7號", 11, (byte)1 },
                    { 376, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9467), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9468), false, "3排8號", 11, (byte)1 },
                    { 377, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9470), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9471), false, "3排9號", 11, (byte)1 },
                    { 378, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9473), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9474), false, "3排10號", 11, (byte)1 },
                    { 379, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9476), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9476), false, "3排11號", 11, (byte)1 },
                    { 380, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9478), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9479), false, "3排12號", 11, (byte)1 },
                    { 381, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9481), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9482), false, "3排13號", 11, (byte)1 },
                    { 382, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9484), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9484), false, "3排14號", 11, (byte)1 },
                    { 383, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9486), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9487), false, "3排15號", 11, (byte)1 },
                    { 384, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9489), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9490), false, "4排10號", 12, (byte)0 },
                    { 385, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9492), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9492), false, "4排11號", 12, (byte)0 },
                    { 386, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9494), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9495), false, "4排12號", 12, (byte)0 },
                    { 387, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9497), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9498), false, "4排13號", 12, (byte)0 },
                    { 388, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9500), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9501), false, "4排14號", 12, (byte)0 },
                    { 389, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9503), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9503), false, "4排15號", 12, (byte)0 },
                    { 390, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9505), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9506), false, "4排16號", 12, (byte)0 },
                    { 391, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9508), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9509), false, "4排17號", 12, (byte)0 },
                    { 392, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9511), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9511), false, "5排1號", 12, (byte)0 },
                    { 393, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9513), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9514), false, "5排2號", 12, (byte)0 },
                    { 394, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9516), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9517), false, "5排3號", 12, (byte)0 },
                    { 395, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9519), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9519), false, "5排4號", 12, (byte)0 },
                    { 396, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9521), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9522), false, "5排5號", 12, (byte)0 },
                    { 397, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9524), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9525), false, "5排6號", 12, (byte)0 },
                    { 398, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9527), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9527), false, "5排7號", 12, (byte)0 },
                    { 399, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9529), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9530), false, "5排8號", 12, (byte)0 },
                    { 400, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9532), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9533), false, "4排10號", 12, (byte)0 },
                    { 401, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9535), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9536), false, "4排11號", 12, (byte)0 },
                    { 402, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9538), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9538), false, "4排12號", 12, (byte)0 },
                    { 403, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9572), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9572), false, "4排13號", 12, (byte)0 },
                    { 404, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9575), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9575), false, "1排1號", 13, (byte)1 },
                    { 405, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9577), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9578), false, "1排2號", 13, (byte)1 },
                    { 406, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9580), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9581), false, "1排3號", 13, (byte)1 },
                    { 407, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9583), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9584), false, "1排4號", 13, (byte)1 },
                    { 408, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9586), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9586), false, "1排5號", 13, (byte)1 },
                    { 409, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9588), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9589), false, "1排6號", 13, (byte)1 },
                    { 410, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9591), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9592), false, "1排7號", 13, (byte)1 },
                    { 411, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9594), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9594), false, "1排8號", 13, (byte)1 },
                    { 412, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9597), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9597), false, "1排9號", 13, (byte)1 },
                    { 413, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9599), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9600), false, "1排10號", 13, (byte)1 },
                    { 414, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9602), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9602), false, "1排11號", 13, (byte)1 },
                    { 415, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9604), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9605), false, "1排12號", 13, (byte)1 },
                    { 416, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9607), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9608), false, "1排13號", 13, (byte)1 },
                    { 417, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9610), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9611), false, "1排14號", 13, (byte)1 },
                    { 418, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9613), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9613), false, "1排15號", 13, (byte)1 },
                    { 419, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9615), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9616), false, "1排16號", 13, (byte)1 },
                    { 420, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9618), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9619), false, "1排17號", 13, (byte)1 },
                    { 421, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9621), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9621), false, "2排1號", 13, (byte)1 },
                    { 422, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9624), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9624), false, "2排2號", 13, (byte)1 },
                    { 423, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9626), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9627), false, "2排3號", 13, (byte)1 },
                    { 424, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9629), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9630), false, "2排4號", 13, (byte)1 },
                    { 425, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9632), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9633), false, "2排5號", 13, (byte)1 },
                    { 426, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9635), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9635), false, "2排6號", 13, (byte)1 },
                    { 427, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9637), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9638), false, "2排7號", 13, (byte)1 },
                    { 428, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9640), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9641), false, "2排8號", 13, (byte)1 },
                    { 429, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9643), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9643), false, "2排9號", 13, (byte)1 },
                    { 430, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9645), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9646), false, "2排10號", 13, (byte)1 },
                    { 431, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9648), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9649), false, "2排11號", 13, (byte)1 },
                    { 432, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9651), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9651), false, "2排12號", 13, (byte)1 },
                    { 433, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9653), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9654), false, "2排13號", 13, (byte)1 },
                    { 434, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9656), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9657), false, "2排14號", 13, (byte)1 },
                    { 435, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9659), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9659), false, "2排15號", 13, (byte)1 },
                    { 436, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9662), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9662), false, "2排16號", 13, (byte)1 },
                    { 437, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9664), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9665), false, "2排17號", 13, (byte)1 },
                    { 438, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9667), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9668), false, "3排1號", 13, (byte)1 },
                    { 439, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9670), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9671), false, "3排2號", 13, (byte)1 },
                    { 440, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9673), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9673), false, "3排3號", 13, (byte)1 },
                    { 441, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9675), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9676), false, "3排4號", 13, (byte)1 },
                    { 442, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9678), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9679), false, "3排5號", 13, (byte)1 },
                    { 443, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9681), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9681), false, "3排6號", 13, (byte)1 },
                    { 444, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9683), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9684), false, "3排7號", 13, (byte)1 },
                    { 445, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9686), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9687), false, "3排8號", 13, (byte)1 },
                    { 446, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9690), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9691), false, "3排9號", 13, (byte)1 },
                    { 447, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9693), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9693), false, "3排10號", 13, (byte)1 },
                    { 448, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9695), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9696), false, "3排11號", 13, (byte)1 },
                    { 449, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9698), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9699), false, "3排12號", 13, (byte)1 },
                    { 450, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9701), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9702), false, "3排13號", 13, (byte)1 },
                    { 451, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9705), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9705), false, "3排14號", 13, (byte)1 },
                    { 452, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9708), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9708), false, "3排16號", 13, (byte)0 },
                    { 453, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9710), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9711), false, "3排17號", 13, (byte)0 },
                    { 454, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9713), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9713), false, "4排1號", 13, (byte)0 },
                    { 455, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9716), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9716), false, "4排2號", 13, (byte)0 },
                    { 456, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9718), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9719), false, "4排3號", 13, (byte)0 },
                    { 457, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9721), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9722), false, "4排4號", 13, (byte)0 },
                    { 458, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9724), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9724), false, "4排5號", 13, (byte)0 },
                    { 459, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9726), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9727), false, "4排6號", 13, (byte)0 },
                    { 460, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9730), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9731), false, "4排7號", 13, (byte)0 },
                    { 461, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9733), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9733), false, "4排8號", 13, (byte)0 },
                    { 462, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9735), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9736), false, "4排9號", 13, (byte)0 },
                    { 463, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9738), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9739), false, "4排10號", 13, (byte)0 },
                    { 464, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9741), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9741), false, "4排11號", 13, (byte)0 },
                    { 465, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9744), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9744), false, "4排12號", 13, (byte)0 },
                    { 466, new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9746), new DateTime(2024, 3, 27, 1, 6, 24, 380, DateTimeKind.Local).AddTicks(9747), false, "4排13號", 13, (byte)0 }
                });

            migrationBuilder.InsertData(
                table: "ArchiveOrders",
                columns: new[] { "OrderId", "CreatedAt", "EditedAt", "EventName", "EventStartTime", "IsDeleted", "LocationAddress", "LocationName", "PurchaseAmount", "SeatNumber", "StreamingPlatform", "StreamingUrl", "TicketNumber", "TicketPrice", "TicketTypeName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(534), null, "演唱會", new DateTime(2024, 3, 25, 19, 0, 0, 0, DateTimeKind.Unspecified), false, "台北市松山區南京東路四段2號", "台北小巨蛋", 1, "3排13號", null, null, "A123456789", 1000m, "一般票" },
                    { 2, new DateTime(2024, 3, 26, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(546), null, "線上研討會", new DateTime(2024, 4, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, 2, null, "Zoom", "https://zoom.us/j/123456789", null, 0m, "免費票" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Capacity", "CoOrganizer", "ContactPerson", "CreatedAt", "Description", "EditedAt", "EndTime", "EventImage", "Introduction", "IsDeleted", "IsFree", "IsPrivateEvent", "Latitude", "LocationAddress", "LocationName", "Longitude", "MainOrganizer", "Name", "OrganizationId", "ParticipantPeople", "Sort", "StartTime", "Status", "StreamingPlatform", "StreamingUrl", "Type" },
                values: new object[,]
                {
                    { 1, 500, null, "", new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(79), "線上活動描述內容區", new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(80), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://picsum.photos/1300/600/?random=11", "線上活動簡介內容區", null, true, false, "120.33333", "台北市松山區南京東路四段2號", "大巨蛋", "120.33333", "Build School", "【線上直播課】掌握網路三大流量，讓你在同行中脫穎而出", 1, "[\r\n  {\r\n    \"ParticipantPeopleImage\": \"https://picsum.photos/200/200/?random=10\",\r\n    \"ParticipantPeopleId\": \"DDDD\"\r\n  },\r\n  {\r\n    \"ParticipantPeopleImage\": \"https://picsum.photos/200/200/?random=14\",\r\n    \"ParticipantPeopleId\": \"EEEE\"\r\n  },\r\n  {\r\n    \"ParticipantPeopleImage\": \"https://picsum.photos/200/200/?random=18\",\r\n    \"ParticipantPeopleId\": \"FFFF\"\r\n  }\r\n]\r\n", null, new DateTime(2024, 4, 10, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(72), (byte)1, "http;", "http;", (byte)0 },
                    { 2, 1000, null, "", new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(89), "實體活動描述內容區", new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(90), new DateTime(2024, 4, 10, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(84), "https://picsum.photos/1300/600/?random=15", "實體活動簡介內容區", null, false, false, "120.33333", "台北市松山區南京東路四段2號", "大巨蛋", "120.33333", "卡米地", "【演唱會】五月天", 2, "[\r\n  {\r\n    \"ParticipantPeopleImage\": \"https://picsum.photos/200/200/?random=10\",\r\n    \"ParticipantPeopleId\": \"DDDD\"\r\n  },\r\n  {\r\n    \"ParticipantPeopleImage\": \"https://picsum.photos/200/200/?random=14\",\r\n    \"ParticipantPeopleId\": \"EEEE\"\r\n  },\r\n  {\r\n    \"ParticipantPeopleImage\": \"https://picsum.photos/200/200/?random=18\",\r\n    \"ParticipantPeopleId\": \"FFFF\"\r\n  }\r\n]\r\n", null, new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(83), (byte)1, null, null, (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "OrgFan",
                columns: new[] { "Id", "FanTime", "OrganizationId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(211), 1, 1 },
                    { 2, new DateTime(2024, 3, 26, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(213), 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "OrganizationAndUserMapping",
                columns: new[] { "Id", "OrganizationId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "EventAndTagMapping",
                columns: new[] { "Id", "CategoryTagId", "EventID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "TicketTypes",
                columns: new[] { "Id", "CapacityAmount", "CreatedAt", "EditedAt", "EndSaleTime", "EventId", "IsDeleted", "IsDisplayed", "Name", "Price", "Sort", "StartSaleTime" },
                values: new object[,]
                {
                    { 1, 300, new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(314), new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(315), new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(312), 1, null, null, "Free", 0m, null, new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(311) },
                    { 2, 50, new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(322), new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(323), new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(319), 2, null, null, "搖滾票", 6800m, null, new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(318) },
                    { 3, 200, new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(327), new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(327), new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(326), 2, null, null, "一般票", 2800m, null, new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(325) },
                    { 4, 400, new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(331), new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(332), new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(330), 2, null, null, "站票", 800m, null, new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(329) }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "CheckCode", "CreatedAt", "EditedAt", "IsDeleted", "Number", "OrderId", "SeatId", "Status", "TicketTypeId" },
                values: new object[,]
                {
                    { 1, 123, new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(383), null, false, "A123456789", 1, 1, (byte)0, 1 },
                    { 2, 123, new DateTime(2024, 3, 26, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(387), new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(388), false, "B987654321", 2, null, (byte)1, 2 },
                    { 3, 123, new DateTime(2024, 3, 25, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(391), null, true, "C123456789", null, 3, (byte)0, 3 },
                    { 4, 123, new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(394), null, false, "A123456789", 1, 1, (byte)0, 1 },
                    { 5, 123, new DateTime(2024, 3, 26, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(397), new DateTime(2024, 3, 27, 1, 6, 24, 381, DateTimeKind.Local).AddTicks(398), false, "B987654321", 2, null, (byte)1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventAndTagMapping_CategoryTagId",
                table: "EventAndTagMapping",
                column: "CategoryTagId");

            migrationBuilder.CreateIndex(
                name: "IX_EventAndTagMapping_EventID",
                table: "EventAndTagMapping",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_OrganizationId",
                table: "Events",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryPassword_UserId",
                table: "HistoryPassword",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationAndUserMapping_OrganizationId",
                table: "OrganizationAndUserMapping",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationAndUserMapping_UserId",
                table: "OrganizationAndUserMapping",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_OwnerId",
                table: "Organizations",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgFan_OrganizationId",
                table: "OrgFan",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgFan_UserId",
                table: "OrgFan",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PreferredActivityArea_AreaId",
                table: "PreferredActivityArea",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_PreferredActivityArea_UserId",
                table: "PreferredActivityArea",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PreFill_UserId",
                table: "PreFill",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_SeatAreaId",
                table: "Seats",
                column: "SeatAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_OrderId",
                table: "Tickets",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SeatId",
                table: "Tickets",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketTypeId",
                table: "Tickets",
                column: "TicketTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketTypes_EventId",
                table: "TicketTypes",
                column: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchiveOrders");

            migrationBuilder.DropTable(
                name: "EventAndTagMapping");

            migrationBuilder.DropTable(
                name: "HistoryPassword");

            migrationBuilder.DropTable(
                name: "IsPaidRecords");

            migrationBuilder.DropTable(
                name: "LogInInfo");

            migrationBuilder.DropTable(
                name: "OrganizationAndUserMapping");

            migrationBuilder.DropTable(
                name: "OrgFan");

            migrationBuilder.DropTable(
                name: "PreferredActivityArea");

            migrationBuilder.DropTable(
                name: "PreFill");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "CategoryTags");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "TicketTypes");

            migrationBuilder.DropTable(
                name: "SeatAreas");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
