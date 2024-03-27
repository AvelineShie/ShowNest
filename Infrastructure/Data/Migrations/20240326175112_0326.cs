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
                    { 1, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3854), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3855), null, "音樂", null },
                    { 2, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3857), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3858), null, "戲劇", null },
                    { 3, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3860), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3861), null, "展覽", null }
                });

            migrationBuilder.InsertData(
                table: "SeatAreas",
                columns: new[] { "Id", "CreatedAt", "EditedAt", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 12, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3647), null, false, "1A區" },
                    { 2, new DateTime(2024, 3, 12, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3653), null, false, "2A區" },
                    { 3, new DateTime(2024, 3, 12, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3656), null, false, "2A區" },
                    { 4, new DateTime(2024, 3, 13, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3657), null, false, "2B區" },
                    { 5, new DateTime(2024, 3, 14, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3660), null, false, "2C區" },
                    { 6, new DateTime(2024, 3, 15, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3662), null, false, "2D區" },
                    { 7, new DateTime(2024, 3, 16, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3665), null, false, "2E區" },
                    { 8, new DateTime(2024, 3, 17, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3667), null, false, "2F區" },
                    { 9, new DateTime(2024, 3, 18, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3669), null, false, "2G區" },
                    { 10, new DateTime(2024, 3, 19, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3671), null, false, "3A區" },
                    { 11, new DateTime(2024, 3, 20, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3673), null, false, "3B區" },
                    { 12, new DateTime(2024, 3, 21, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3676), null, false, "3C區" },
                    { 13, new DateTime(2024, 3, 22, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3678), null, false, "3D區" },
                    { 14, new DateTime(2024, 3, 22, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3680), null, false, "3E區" },
                    { 15, new DateTime(2024, 3, 20, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3682), null, false, "3F區" },
                    { 16, new DateTime(2024, 3, 19, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3685), null, false, "3G區" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "CreatedAt", "EditedAt", "EdmSubscription", "Gender", "Image", "LastLogInAt", "Mobile", "Nickname", "PersonalProfile", "PersonalURL", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3723), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3723), true, (byte)1, "https://image.com/alice.jpg", new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3721), "0912345678", "Alice", "I'm Alice!", "https://alice.com", (byte)1 },
                    { 2, new DateTime(1985, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3730), null, false, (byte)2, null, null, "0987654321", "Bob", null, null, (byte)0 },
                    { 3, new DateTime(1995, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 17, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3770), new DateTime(2024, 3, 25, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3771), true, (byte)2, "https://image.com/charlie.png", new DateTime(2024, 3, 22, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3768), "0955555555", "Charlie", "Hello world!", "https://charlie.com", (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "LogInInfo",
                columns: new[] { "UserId", "Account", "CreatedAt", "EditedAt", "Email", "Password" },
                values: new object[,]
                {
                    { 1, "abc123", new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3793), null, "abc@gmail.com", "12345678" },
                    { 2, "def456", new DateTime(2024, 3, 26, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3796), null, "def@gmail.com", "87654321" },
                    { 3, "ghi789", new DateTime(2024, 3, 25, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3799), null, "ghi@gmail.com", "98765432" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ContactPerson", "CreatedAt", "EditedAt", "IsDeleted", "IsDisplayed", "ParticipantPeople", "PaymentType", "SeatNumber", "Status", "TicketId", "UserId" },
                values: new object[,]
                {
                    { 1, "{\"Name\":\"John Doe\",\"Email\":\"john.doe@example.com\",\"Phone\":\"0912345678\"}", new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(4016), new DateTime(2024, 3, 22, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(4017), false, true, "{\"Name\":\"Jane Smith\",\"Age\":25}", (byte)1, "3排13號", (byte)1, 1, 1 },
                    { 2, "{\"Name\":\"Bob Johnson\",\"Email\":\"bob.johnson@example.com\",\"Phone\":\"0987654321\"}", new DateTime(2024, 3, 17, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(4022), null, false, false, null, (byte)0, "5排8號", (byte)0, 2, 2 },
                    { 3, "{\"Name\":\"Emily Wilson\",\"Email\":\"emily.wilson@example.com\",\"Phone\":\"0923456789\"}", new DateTime(2024, 3, 12, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(4026), new DateTime(2024, 3, 15, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(4027), false, true, "{\"Name\":\"Michael Brown\",\"Age\":30}", (byte)1, "2排5號", (byte)2, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "ContactMobile", "ContactName", "ContactTelephone", "CreatedAt", "Description", "EditedAt", "Email", "FBLink", "IGAccount", "ImgURL", "IsDeleted", "Name", "OrganizationURL", "OuterURL", "OwnerId" },
                values: new object[,]
                {
                    { 1, "0123456789", "Alice", "02-2123-45678", new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3901), "組織簡介內容區", new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3902), null, null, null, null, null, "Build School", "HTTP", null, 1 },
                    { 2, "0123456789", "Bob", "02-2123-45678", new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3907), "組織簡介內容區", new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3908), null, null, null, null, null, "卡米地", "HTTP", null, 2 },
                    { 3, "0123456789", "Charlie", "02-2123-45678", new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3911), "組織簡介內容區", new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3912), null, null, null, null, null, "海邊的卡夫卡", "HTTP", null, 3 }
                });

            migrationBuilder.InsertData(
                table: "PreFill",
                columns: new[] { "Id", "Address", "CompanyAddress", "CompanyName", "CompanyPostalCode", "County", "CreatedAt", "District", "EditedAt", "Mobile", "Name", "PostalCode", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "No.1, Lane 10, Section 3, Zhongxiao E Rd", null, null, null, "Taipei", new DateTime(2024, 3, 17, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(4259), "Daan", null, "0912345678", "John Doe", 106, null, 1 },
                    { 2, "No.100, Guandu Rd", null, null, null, "New Taipei", new DateTime(2024, 3, 18, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(4265), "Banqiao", null, "0912345679", "Jane Doe", 107, null, 2 },
                    { 3, "No.20, Jhongsing Rd", null, null, null, "Taoyuan", new DateTime(2024, 3, 19, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(4268), "Zhongli", null, "0923456789", "Mike Chen", 108, null, 3 }
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
                    { 1, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1895), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1906), false, "1排1號", 1, (byte)1 },
                    { 2, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1912), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1913), false, "1排2號", 1, (byte)1 },
                    { 3, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1916), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1916), false, "1排3號", 1, (byte)1 },
                    { 4, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1918), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1919), false, "1排4號", 1, (byte)1 },
                    { 5, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1921), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1922), false, "1排5號", 1, (byte)1 },
                    { 6, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1924), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1925), false, "1排6號", 1, (byte)1 },
                    { 7, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1928), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1928), false, "1排7號", 1, (byte)1 },
                    { 8, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1931), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1932), false, "1排8號", 1, (byte)1 },
                    { 9, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1934), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1935), false, "1排9號", 1, (byte)1 },
                    { 10, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1937), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1937), false, "1排10號", 1, (byte)1 },
                    { 11, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1939), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1940), false, "1排11號", 1, (byte)1 },
                    { 12, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1942), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1943), false, "1排12號", 1, (byte)1 },
                    { 13, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1945), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1946), false, "1排13號", 1, (byte)1 },
                    { 14, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1948), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1948), false, "1排14號", 1, (byte)1 },
                    { 15, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1950), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1951), false, "1排15號", 1, (byte)1 },
                    { 16, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1953), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1954), false, "1排16號", 1, (byte)1 },
                    { 17, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1956), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1956), false, "1排17號", 1, (byte)1 },
                    { 18, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1958), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1959), false, "2排1號", 1, (byte)1 },
                    { 19, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1961), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1962), false, "2排2號", 1, (byte)1 },
                    { 20, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1964), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1965), false, "2排3號", 1, (byte)1 },
                    { 21, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1967), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1967), false, "2排4號", 1, (byte)1 },
                    { 22, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1969), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1970), false, "2排5號", 1, (byte)1 },
                    { 23, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1972), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1973), false, "2排6號", 1, (byte)1 },
                    { 24, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1975), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1975), false, "2排7號", 1, (byte)1 },
                    { 25, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1978), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1979), false, "2排8號", 1, (byte)1 },
                    { 26, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1981), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1981), false, "2排9號", 1, (byte)1 },
                    { 27, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1983), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1984), false, "2排10號", 1, (byte)1 },
                    { 28, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1987), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1987), false, "2排11號", 1, (byte)1 },
                    { 29, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1989), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1990), false, "2排12號", 1, (byte)1 },
                    { 30, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1993), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1993), false, "2排13號", 1, (byte)1 },
                    { 31, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1995), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1996), false, "2排14號", 1, (byte)1 },
                    { 32, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1998), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(1999), false, "2排15號", 1, (byte)1 },
                    { 33, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2001), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2001), false, "2排16號", 1, (byte)1 },
                    { 34, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2003), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2004), false, "2排17號", 1, (byte)1 },
                    { 35, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2006), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2007), false, "3排1號", 1, (byte)1 },
                    { 36, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2009), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2009), false, "3排2號", 1, (byte)1 },
                    { 37, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2011), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2012), false, "3排3號", 1, (byte)1 },
                    { 38, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2014), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2015), false, "3排4號", 1, (byte)1 },
                    { 39, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2017), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2018), false, "3排5號", 1, (byte)1 },
                    { 40, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2020), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2020), false, "3排6號", 1, (byte)1 },
                    { 41, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2022), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2023), false, "3排7號", 1, (byte)1 },
                    { 42, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2026), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2026), false, "3排8號", 1, (byte)1 },
                    { 43, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2029), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2030), false, "3排9號", 1, (byte)1 },
                    { 44, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2034), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2035), false, "3排10號", 1, (byte)1 },
                    { 45, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2037), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2038), false, "3排11號", 1, (byte)1 },
                    { 46, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2040), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2040), false, "3排12號", 1, (byte)1 },
                    { 47, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2042), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2043), false, "3排13號", 1, (byte)1 },
                    { 48, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2045), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2046), false, "3排14號", 1, (byte)1 },
                    { 49, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2048), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2048), false, "3排16號", 1, (byte)0 },
                    { 50, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2051), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2051), false, "3排17號", 1, (byte)0 },
                    { 51, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2053), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2054), false, "4排1號", 1, (byte)0 },
                    { 52, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2056), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2057), false, "4排2號", 1, (byte)0 },
                    { 53, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2059), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2059), false, "4排3號", 1, (byte)0 },
                    { 54, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2061), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2062), false, "4排4號", 1, (byte)0 },
                    { 55, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2064), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2065), false, "4排5號", 1, (byte)0 },
                    { 56, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2066), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2067), false, "4排6號", 1, (byte)0 },
                    { 57, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2069), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2070), false, "4排7號", 1, (byte)0 },
                    { 58, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2072), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2072), false, "4排8號", 1, (byte)0 },
                    { 59, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2074), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2075), false, "4排9號", 1, (byte)0 },
                    { 60, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2077), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2078), false, "4排10號", 1, (byte)0 },
                    { 61, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2081), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2082), false, "4排11號", 1, (byte)0 },
                    { 62, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2114), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2115), false, "4排12號", 1, (byte)0 },
                    { 63, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2117), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2118), false, "4排13號", 1, (byte)0 },
                    { 64, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2120), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2121), false, "1排1號", 2, (byte)1 },
                    { 65, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2122), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2123), false, "1排2號", 2, (byte)1 },
                    { 66, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2125), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2126), false, "1排3號", 2, (byte)1 },
                    { 67, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2128), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2129), false, "1排5號", 2, (byte)1 },
                    { 68, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2131), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2132), false, "1排6號", 2, (byte)1 },
                    { 69, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2134), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2135), false, "1排7號", 2, (byte)1 },
                    { 70, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2137), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2138), false, "1排8號", 2, (byte)1 },
                    { 71, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2140), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2140), false, "1排9號", 2, (byte)1 },
                    { 72, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2142), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2143), false, "1排10號", 2, (byte)1 },
                    { 73, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2145), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2146), false, "1排11號", 2, (byte)1 },
                    { 74, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2150), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2151), false, "1排12號", 2, (byte)1 },
                    { 75, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2154), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2155), false, "1排13號", 2, (byte)1 },
                    { 76, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2160), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2161), false, "1排14號", 2, (byte)1 },
                    { 77, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2163), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2164), false, "1排15號", 2, (byte)1 },
                    { 78, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2168), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2168), false, "1排16號", 2, (byte)1 },
                    { 79, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2172), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2173), false, "1排17號", 2, (byte)1 },
                    { 80, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2175), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2175), false, "2排1號", 2, (byte)1 },
                    { 81, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2177), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2179), false, "2排2號", 2, (byte)1 },
                    { 82, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2181), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2182), false, "2排3號", 2, (byte)1 },
                    { 83, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2186), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2189), false, "2排4號", 2, (byte)1 },
                    { 84, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2193), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2194), false, "2排5號", 2, (byte)1 },
                    { 85, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2197), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2198), false, "2排6號", 2, (byte)1 },
                    { 86, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2201), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2201), false, "2排7號", 2, (byte)1 },
                    { 87, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2203), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2204), false, "2排8號", 2, (byte)1 },
                    { 88, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2208), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2210), false, "2排9號", 2, (byte)1 },
                    { 89, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2213), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2213), false, "2排10號", 2, (byte)1 },
                    { 90, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2216), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2217), false, "2排11號", 2, (byte)1 },
                    { 91, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2221), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2222), false, "2排12號", 2, (byte)1 },
                    { 92, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2227), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2228), false, "2排13號", 2, (byte)1 },
                    { 93, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2230), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2230), false, "2排14號", 2, (byte)1 },
                    { 94, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2234), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2234), false, "2排15號", 2, (byte)1 },
                    { 95, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2238), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2238), false, "2排16號", 2, (byte)1 },
                    { 96, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2240), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2241), false, "2排17號", 2, (byte)1 },
                    { 97, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2243), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2243), false, "3排1號", 2, (byte)1 },
                    { 98, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2247), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2248), false, "3排2號", 2, (byte)1 },
                    { 99, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2252), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2253), false, "3排3號", 2, (byte)1 },
                    { 100, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2256), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2257), false, "3排4號", 2, (byte)1 },
                    { 101, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2261), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2261), false, "3排5號", 2, (byte)1 },
                    { 102, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2267), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2267), false, "3排6號", 2, (byte)1 },
                    { 103, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2271), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2272), false, "3排7號", 2, (byte)1 },
                    { 104, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2276), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2277), false, "3排8號", 2, (byte)1 },
                    { 105, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2281), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2282), false, "3排9號", 2, (byte)1 },
                    { 106, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2286), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2287), false, "3排10號", 2, (byte)1 },
                    { 107, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2290), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2291), false, "3排11號", 2, (byte)1 },
                    { 108, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2296), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2296), false, "3排12號", 2, (byte)1 },
                    { 109, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2299), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2299), false, "3排13號", 2, (byte)1 },
                    { 110, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2305), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2305), false, "3排14號", 2, (byte)1 },
                    { 111, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2310), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2310), false, "3排16號", 2, (byte)0 },
                    { 112, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2314), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2314), false, "3排17號", 2, (byte)0 },
                    { 113, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2318), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2319), false, "4排1號", 2, (byte)0 },
                    { 114, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2321), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2322), false, "4排2號", 2, (byte)0 },
                    { 115, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2328), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2328), false, "4排3號", 2, (byte)0 },
                    { 116, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2333), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2334), false, "4排4號", 2, (byte)0 },
                    { 117, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2338), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2340), false, "4排5號", 2, (byte)0 },
                    { 118, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2342), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2344), false, "4排6號", 2, (byte)0 },
                    { 119, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2346), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2349), false, "4排7號", 2, (byte)0 },
                    { 120, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2353), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2353), false, "4排8號", 2, (byte)0 },
                    { 121, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2357), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2358), false, "4排9號", 2, (byte)0 },
                    { 122, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2361), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2361), false, "4排10號", 2, (byte)0 },
                    { 123, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2363), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2364), false, "4排11號", 2, (byte)0 },
                    { 124, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2367), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2367), false, "4排12號", 2, (byte)0 },
                    { 125, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2370), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2371), false, "4排13號", 2, (byte)0 },
                    { 126, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2376), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2376), false, "1排1號", 3, (byte)1 },
                    { 127, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2381), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2381), false, "1排2號", 3, (byte)1 },
                    { 128, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2387), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2388), false, "1排3號", 3, (byte)1 },
                    { 129, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2391), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2392), false, "1排4號", 3, (byte)1 },
                    { 130, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2394), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2394), false, "1排5號", 3, (byte)1 },
                    { 131, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2396), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2397), false, "1排6號", 3, (byte)1 },
                    { 132, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2399), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2400), false, "1排7號", 3, (byte)1 },
                    { 133, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2402), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2402), false, "1排8號", 3, (byte)1 },
                    { 134, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2435), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2436), false, "1排9號", 3, (byte)1 },
                    { 135, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2438), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2438), false, "1排10號", 3, (byte)1 },
                    { 136, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2440), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2441), false, "1排11號", 3, (byte)1 },
                    { 137, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2443), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2444), false, "1排12號", 3, (byte)1 },
                    { 138, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2446), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2447), false, "1排13號", 3, (byte)1 },
                    { 139, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2449), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2450), false, "1排14號", 3, (byte)1 },
                    { 140, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2452), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2452), false, "1排15號", 3, (byte)1 },
                    { 141, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2455), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2455), false, "1排16號", 3, (byte)1 },
                    { 142, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2457), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2458), false, "1排17號", 3, (byte)1 },
                    { 143, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2461), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2461), false, "2排1號", 3, (byte)1 },
                    { 144, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2463), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2464), false, "2排2號", 3, (byte)1 },
                    { 145, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2466), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2467), false, "2排3號", 3, (byte)1 },
                    { 146, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2469), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2469), false, "2排4號", 3, (byte)1 },
                    { 147, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2471), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2472), false, "2排5號", 3, (byte)1 },
                    { 148, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2474), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2475), false, "2排6號", 3, (byte)1 },
                    { 149, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2477), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2478), false, "2排7號", 3, (byte)1 },
                    { 150, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2480), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2480), false, "2排8號", 3, (byte)1 },
                    { 151, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2482), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2483), false, "2排9號", 3, (byte)1 },
                    { 152, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2485), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2486), false, "2排10號", 3, (byte)1 },
                    { 153, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2488), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2488), false, "2排11號", 3, (byte)1 },
                    { 154, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2490), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2491), false, "2排12號", 3, (byte)1 },
                    { 155, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2493), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2494), false, "2排13號", 3, (byte)1 },
                    { 156, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2496), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2497), false, "2排14號", 3, (byte)1 },
                    { 157, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2499), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2499), false, "2排15號", 3, (byte)1 },
                    { 158, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2501), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2502), false, "2排16號", 3, (byte)1 },
                    { 159, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2504), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2504), false, "2排17號", 3, (byte)1 },
                    { 160, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2506), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2507), false, "3排1號", 3, (byte)1 },
                    { 161, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2509), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2510), false, "3排2號", 3, (byte)1 },
                    { 162, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2512), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2512), false, "3排3號", 3, (byte)1 },
                    { 163, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2514), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2515), false, "3排4號", 3, (byte)1 },
                    { 164, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2517), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2518), false, "3排5號", 3, (byte)1 },
                    { 165, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2520), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2520), false, "3排6號", 3, (byte)1 },
                    { 166, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2522), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2523), false, "3排7號", 3, (byte)1 },
                    { 167, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2525), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2525), false, "3排8號", 3, (byte)1 },
                    { 168, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2528), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2528), false, "3排9號", 3, (byte)1 },
                    { 169, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2530), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2531), false, "3排10號", 3, (byte)1 },
                    { 170, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2533), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2534), false, "3排11號", 3, (byte)1 },
                    { 171, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2536), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2536), false, "3排12號", 3, (byte)1 },
                    { 172, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2538), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2539), false, "3排13號", 3, (byte)1 },
                    { 173, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2541), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2541), false, "3排14號", 3, (byte)1 },
                    { 174, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2543), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2544), false, "3排16號", 3, (byte)0 },
                    { 175, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2546), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2547), false, "3排17號", 3, (byte)0 },
                    { 176, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2549), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2549), false, "4排1號", 3, (byte)0 },
                    { 177, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2551), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2552), false, "4排2號", 3, (byte)0 },
                    { 178, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2554), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2555), false, "4排3號", 3, (byte)0 },
                    { 179, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2557), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2557), false, "4排4號", 3, (byte)0 },
                    { 180, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2559), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2560), false, "4排5號", 3, (byte)0 },
                    { 181, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2562), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2563), false, "4排6號", 3, (byte)0 },
                    { 182, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2565), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2565), false, "4排7號", 3, (byte)0 },
                    { 183, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2568), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2568), false, "4排8號", 3, (byte)0 },
                    { 184, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2570), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2571), false, "4排9號", 3, (byte)0 },
                    { 185, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2573), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2574), false, "4排10號", 3, (byte)0 },
                    { 186, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2576), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2576), false, "4排11號", 3, (byte)0 },
                    { 187, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2578), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2579), false, "4排12號", 3, (byte)0 },
                    { 188, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2581), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2582), false, "4排13號", 3, (byte)0 },
                    { 189, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2584), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2584), false, "1排1號", 4, (byte)1 },
                    { 190, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2586), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2587), false, "1排2號", 4, (byte)1 },
                    { 191, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2589), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2590), false, "1排3號", 4, (byte)1 },
                    { 192, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2592), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2592), false, "1排4號", 4, (byte)1 },
                    { 193, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2594), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2595), false, "1排5號", 4, (byte)1 },
                    { 194, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2597), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2598), false, "1排6號", 4, (byte)1 },
                    { 195, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2601), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2601), false, "1排7號", 4, (byte)1 },
                    { 196, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2603), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2604), false, "1排8號", 4, (byte)1 },
                    { 197, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2606), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2607), false, "1排9號", 4, (byte)1 },
                    { 198, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2609), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2609), false, "1排10號", 4, (byte)1 },
                    { 199, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2611), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2612), false, "1排11號", 4, (byte)1 },
                    { 200, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2614), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2615), false, "1排12號", 4, (byte)1 },
                    { 201, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2617), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2617), false, "1排13號", 4, (byte)1 },
                    { 202, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2619), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2620), false, "1排14號", 4, (byte)1 },
                    { 203, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2622), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2622), false, "1排15號", 4, (byte)1 },
                    { 204, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2624), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2625), false, "1排16號", 4, (byte)1 },
                    { 205, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2627), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2628), false, "1排17號", 4, (byte)1 },
                    { 206, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2630), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2630), false, "2排1號", 4, (byte)1 },
                    { 207, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2664), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2666), false, "2排2號", 4, (byte)1 },
                    { 208, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2668), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2669), false, "2排3號", 4, (byte)1 },
                    { 209, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2671), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2672), false, "2排4號", 4, (byte)1 },
                    { 210, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2674), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2674), false, "2排5號", 4, (byte)1 },
                    { 211, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2676), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2677), false, "2排6號", 4, (byte)1 },
                    { 212, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2679), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2680), false, "2排7號", 4, (byte)1 },
                    { 213, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2682), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2682), false, "2排8號", 4, (byte)1 },
                    { 214, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2685), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2685), false, "2排9號", 4, (byte)1 },
                    { 215, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2687), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2688), false, "2排10號", 4, (byte)1 },
                    { 216, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2690), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2691), false, "2排11號", 4, (byte)1 },
                    { 217, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2693), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2693), false, "2排12號", 4, (byte)1 },
                    { 218, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2695), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2696), false, "2排13號", 4, (byte)1 },
                    { 219, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2698), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2699), false, "2排14號", 4, (byte)1 },
                    { 220, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2702), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2703), false, "2排15號", 4, (byte)1 },
                    { 221, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2705), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2706), false, "2排16號", 4, (byte)1 },
                    { 222, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2708), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2708), false, "2排17號", 4, (byte)1 },
                    { 223, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2710), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2711), false, "3排1號", 4, (byte)1 },
                    { 224, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2713), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2714), false, "3排2號", 4, (byte)1 },
                    { 225, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2716), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2716), false, "3排3號", 4, (byte)1 },
                    { 226, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2718), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2719), false, "3排4號", 4, (byte)1 },
                    { 227, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2721), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2722), false, "3排5號", 4, (byte)1 },
                    { 228, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2724), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2725), false, "3排6號", 4, (byte)1 },
                    { 229, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2726), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2727), false, "3排7號", 4, (byte)1 },
                    { 230, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2729), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2730), false, "3排8號", 4, (byte)1 },
                    { 231, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2732), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2732), false, "3排9號", 4, (byte)1 },
                    { 232, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2734), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2736), false, "3排10號", 4, (byte)1 },
                    { 233, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2738), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2739), false, "3排11號", 4, (byte)1 },
                    { 234, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2741), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2741), false, "3排12號", 4, (byte)1 },
                    { 235, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2743), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2744), false, "3排13號", 4, (byte)1 },
                    { 236, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2746), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2747), false, "3排14號", 4, (byte)1 },
                    { 237, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2749), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2750), false, "3排16號", 4, (byte)0 },
                    { 238, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2752), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2752), false, "3排17號", 4, (byte)0 },
                    { 239, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2754), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2755), false, "4排1號", 4, (byte)0 },
                    { 240, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2757), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2758), false, "4排2號", 4, (byte)0 },
                    { 241, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2760), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2760), false, "4排3號", 4, (byte)0 },
                    { 242, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2762), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2763), false, "4排4號", 4, (byte)0 },
                    { 243, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2765), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2766), false, "4排5號", 4, (byte)0 },
                    { 244, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2768), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2768), false, "4排6號", 4, (byte)0 },
                    { 245, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2772), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2772), false, "4排7號", 4, (byte)0 },
                    { 246, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2785), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2786), false, "1排1號", 5, (byte)1 },
                    { 247, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2788), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2789), false, "1排2號", 5, (byte)1 },
                    { 248, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2774), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2775), false, "4排10號", 4, (byte)0 },
                    { 249, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2777), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2778), false, "4排11號", 4, (byte)0 },
                    { 250, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2780), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2780), false, "4排12號", 4, (byte)0 },
                    { 251, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2782), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2783), false, "4排13號", 4, (byte)0 },
                    { 252, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2790), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2791), false, "1排7號", 5, (byte)1 },
                    { 253, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2793), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2794), false, "1排8號", 5, (byte)1 },
                    { 254, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2796), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2797), false, "1排9號", 5, (byte)1 },
                    { 255, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2799), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2799), false, "1排10號", 5, (byte)1 },
                    { 256, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2801), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2802), false, "1排11號", 5, (byte)1 },
                    { 257, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2805), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2806), false, "1排12號", 5, (byte)1 },
                    { 258, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2808), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2809), false, "1排13號", 5, (byte)1 },
                    { 259, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2811), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2811), false, "1排14號", 5, (byte)1 },
                    { 260, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2813), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2814), false, "1排15號", 5, (byte)1 },
                    { 261, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2816), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2817), false, "1排16號", 5, (byte)1 },
                    { 262, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2819), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2819), false, "1排17號", 5, (byte)1 },
                    { 263, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2821), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2822), false, "2排1號", 5, (byte)1 },
                    { 264, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2824), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2825), false, "2排2號", 5, (byte)1 },
                    { 265, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2827), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2827), false, "2排3號", 5, (byte)1 },
                    { 266, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2829), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2830), false, "2排4號", 5, (byte)1 },
                    { 267, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2832), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2832), false, "2排5號", 5, (byte)1 },
                    { 268, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2835), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2835), false, "2排6號", 5, (byte)1 },
                    { 269, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2837), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2838), false, "2排7號", 5, (byte)1 },
                    { 270, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2841), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2842), false, "2排8號", 5, (byte)1 },
                    { 271, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2844), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2844), false, "2排9號", 5, (byte)1 },
                    { 272, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2846), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2847), false, "2排10號", 5, (byte)1 },
                    { 273, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2849), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2850), false, "2排11號", 5, (byte)1 },
                    { 274, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2852), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2853), false, "2排12號", 5, (byte)1 },
                    { 275, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2855), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2855), false, "2排13號", 5, (byte)1 },
                    { 276, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2857), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2858), false, "2排14號", 5, (byte)1 },
                    { 277, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2860), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2861), false, "2排15號", 5, (byte)1 },
                    { 278, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2863), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2863), false, "2排16號", 5, (byte)1 },
                    { 279, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2865), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2866), false, "2排17號", 5, (byte)1 },
                    { 280, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2899), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2899), false, "3排1號", 5, (byte)1 },
                    { 281, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2903), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2903), false, "3排2號", 5, (byte)1 },
                    { 282, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2906), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2906), false, "3排3號", 5, (byte)1 },
                    { 283, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2908), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2909), false, "3排4號", 5, (byte)1 },
                    { 284, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2911), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2912), false, "3排5號", 5, (byte)1 },
                    { 285, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2914), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2915), false, "3排6號", 5, (byte)1 },
                    { 286, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2917), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2918), false, "3排7號", 5, (byte)1 },
                    { 287, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2920), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2920), false, "3排8號", 5, (byte)1 },
                    { 288, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2922), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2923), false, "3排9號", 5, (byte)1 },
                    { 289, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2925), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2926), false, "3排10號", 5, (byte)1 },
                    { 290, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2928), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2929), false, "3排11號", 5, (byte)1 },
                    { 291, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2931), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2931), false, "3排12號", 5, (byte)1 },
                    { 292, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2933), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2934), false, "3排13號", 5, (byte)1 },
                    { 293, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2937), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2937), false, "3排14號", 5, (byte)1 },
                    { 294, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2940), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2941), false, "3排16號", 5, (byte)0 },
                    { 295, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2943), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2944), false, "3排17號", 5, (byte)0 },
                    { 296, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2946), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2947), false, "4排1號", 5, (byte)0 },
                    { 297, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2948), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2949), false, "4排2號", 5, (byte)0 },
                    { 298, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2951), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2952), false, "4排3號", 5, (byte)0 },
                    { 299, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2954), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2954), false, "4排4號", 5, (byte)0 },
                    { 300, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2957), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2957), false, "4排5號", 5, (byte)0 },
                    { 301, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2960), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2961), false, "4排6號", 5, (byte)0 },
                    { 302, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2963), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2964), false, "4排7號", 5, (byte)0 },
                    { 303, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2966), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2966), false, "4排8號", 5, (byte)0 },
                    { 304, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2968), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2969), false, "4排9號", 5, (byte)0 },
                    { 305, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2971), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2972), false, "4排10號", 5, (byte)0 },
                    { 306, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2974), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2974), false, "4排11號", 5, (byte)0 },
                    { 307, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2978), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2978), false, "4排12號", 5, (byte)0 },
                    { 308, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2980), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2981), false, "4排13號", 5, (byte)0 },
                    { 309, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2983), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2984), false, "4排15號", 5, (byte)0 },
                    { 310, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2986), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2986), false, "4排16號", 5, (byte)0 },
                    { 311, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2989), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2989), false, "4排17號", 5, (byte)0 },
                    { 312, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2992), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2993), false, "5排1號", 5, (byte)0 },
                    { 313, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2995), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2996), false, "5排2號", 5, (byte)0 },
                    { 314, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2997), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(2998), false, "5排3號", 5, (byte)0 },
                    { 315, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3000), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3001), false, "5排4號", 5, (byte)0 },
                    { 316, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3003), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3004), false, "5排5號", 5, (byte)0 },
                    { 317, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3005), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3006), false, "5排6號", 5, (byte)0 },
                    { 318, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3008), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3009), false, "5排7號", 5, (byte)0 },
                    { 319, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3013), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3014), false, "5排8號", 5, (byte)0 },
                    { 320, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3016), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3016), false, "4排5號", 6, (byte)0 },
                    { 321, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3018), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3019), false, "4排6號", 6, (byte)0 },
                    { 322, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3021), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3022), false, "4排7號", 6, (byte)0 },
                    { 323, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3023), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3024), false, "4排8號", 6, (byte)0 },
                    { 324, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3026), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3027), false, "4排9號", 6, (byte)0 },
                    { 325, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3030), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3030), false, "4排10號", 6, (byte)0 },
                    { 326, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3032), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3033), false, "4排11號", 6, (byte)0 },
                    { 327, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3035), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3036), false, "4排12號", 6, (byte)0 },
                    { 328, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3038), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3039), false, "4排13號", 6, (byte)0 },
                    { 329, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3040), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3041), false, "4排14號", 6, (byte)0 },
                    { 330, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3043), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3044), false, "2排2號", 7, (byte)1 },
                    { 331, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3046), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3047), false, "2排3號", 7, (byte)1 },
                    { 332, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3050), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3050), false, "2排4號", 7, (byte)1 },
                    { 333, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3052), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3053), false, "2排5號", 7, (byte)1 },
                    { 334, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3055), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3056), false, "2排6號", 7, (byte)1 },
                    { 335, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3058), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3058), false, "2排7號", 7, (byte)1 },
                    { 336, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3060), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3061), false, "2排8號", 7, (byte)1 },
                    { 337, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3063), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3064), false, "2排9號", 7, (byte)1 },
                    { 338, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3065), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3066), false, "2排10號", 7, (byte)1 },
                    { 339, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3068), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3069), false, "2排11號", 7, (byte)1 },
                    { 340, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3071), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3072), false, "4排10號", 7, (byte)0 },
                    { 341, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3074), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3074), false, "4排11號", 7, (byte)0 },
                    { 342, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3076), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3077), false, "4排12號", 7, (byte)0 },
                    { 343, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3079), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3080), false, "4排13號", 7, (byte)0 },
                    { 344, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3083), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3083), false, "4排14號", 7, (byte)0 },
                    { 345, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3085), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3086), false, "4排15號", 7, (byte)0 },
                    { 346, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3088), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3089), false, "4排16號", 7, (byte)0 },
                    { 347, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3091), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3091), false, "4排17號", 7, (byte)0 },
                    { 348, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3093), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3094), false, "4排5號", 8, (byte)0 },
                    { 349, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3096), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3097), false, "4排6號", 8, (byte)0 },
                    { 350, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3099), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3099), false, "4排7號", 8, (byte)0 },
                    { 351, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3101), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3102), false, "4排8號", 8, (byte)0 },
                    { 352, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3104), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3105), false, "4排9號", 8, (byte)0 },
                    { 353, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3136), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3137), false, "4排10號", 8, (byte)0 },
                    { 354, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3139), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3140), false, "4排11號", 8, (byte)0 },
                    { 355, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3142), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3143), false, "4排12號", 8, (byte)0 },
                    { 356, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3145), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3146), false, "3排18號", 9, (byte)0 },
                    { 357, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3148), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3149), false, "3排19號", 9, (byte)0 },
                    { 358, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3151), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3152), false, "3排20號", 9, (byte)0 },
                    { 359, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3154), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3155), false, "3排21號", 9, (byte)0 },
                    { 360, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3157), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3157), false, "3排22號", 9, (byte)0 },
                    { 361, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3159), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3160), false, "3排23號", 9, (byte)0 },
                    { 362, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3162), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3163), false, "3排24號", 9, (byte)0 },
                    { 363, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3165), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3166), false, "3排25號", 9, (byte)0 },
                    { 364, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3168), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3169), false, "3排12號", 10, (byte)1 },
                    { 365, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3171), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3171), false, "3排13號", 10, (byte)1 },
                    { 366, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3173), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3174), false, "3排14號", 10, (byte)1 },
                    { 367, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3176), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3177), false, "3排15號", 10, (byte)1 },
                    { 368, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3179), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3179), false, "3排16號", 10, (byte)1 },
                    { 369, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3182), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3183), false, "3排17號", 10, (byte)1 },
                    { 370, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3185), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3186), false, "3排18號", 10, (byte)1 },
                    { 371, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3188), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3188), false, "3排19號", 10, (byte)1 },
                    { 372, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3191), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3191), false, "3排20號", 10, (byte)1 },
                    { 373, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3193), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3194), false, "3排21號", 10, (byte)1 },
                    { 374, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3196), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3197), false, "3排6號", 11, (byte)1 },
                    { 375, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3199), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3199), false, "3排7號", 11, (byte)1 },
                    { 376, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3201), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3202), false, "3排8號", 11, (byte)1 },
                    { 377, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3204), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3205), false, "3排9號", 11, (byte)1 },
                    { 378, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3207), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3207), false, "3排10號", 11, (byte)1 },
                    { 379, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3209), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3210), false, "3排11號", 11, (byte)1 },
                    { 380, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3212), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3213), false, "3排12號", 11, (byte)1 },
                    { 381, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3216), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3217), false, "3排13號", 11, (byte)1 },
                    { 382, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3219), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3219), false, "3排14號", 11, (byte)1 },
                    { 383, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3221), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3222), false, "3排15號", 11, (byte)1 },
                    { 384, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3224), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3224), false, "4排10號", 12, (byte)0 },
                    { 385, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3227), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3227), false, "4排11號", 12, (byte)0 },
                    { 386, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3230), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3231), false, "4排12號", 12, (byte)0 },
                    { 387, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3233), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3234), false, "4排13號", 12, (byte)0 },
                    { 388, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3236), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3236), false, "4排14號", 12, (byte)0 },
                    { 389, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3238), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3239), false, "4排15號", 12, (byte)0 },
                    { 390, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3241), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3242), false, "4排16號", 12, (byte)0 },
                    { 391, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3244), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3244), false, "4排17號", 12, (byte)0 },
                    { 392, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3246), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3247), false, "5排1號", 12, (byte)0 },
                    { 393, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3249), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3250), false, "5排2號", 12, (byte)0 },
                    { 394, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3253), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3253), false, "5排3號", 12, (byte)0 },
                    { 395, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3255), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3256), false, "5排4號", 12, (byte)0 },
                    { 396, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3258), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3259), false, "5排5號", 12, (byte)0 },
                    { 397, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3261), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3261), false, "5排6號", 12, (byte)0 },
                    { 398, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3263), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3264), false, "5排7號", 12, (byte)0 },
                    { 399, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3266), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3267), false, "5排8號", 12, (byte)0 },
                    { 400, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3269), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3270), false, "4排10號", 12, (byte)0 },
                    { 401, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3272), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3272), false, "4排11號", 12, (byte)0 },
                    { 402, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3274), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3275), false, "4排12號", 12, (byte)0 },
                    { 403, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3277), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3278), false, "4排13號", 12, (byte)0 },
                    { 404, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3280), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3281), false, "1排1號", 13, (byte)1 },
                    { 405, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3283), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3283), false, "1排2號", 13, (byte)1 },
                    { 406, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3286), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3287), false, "1排3號", 13, (byte)1 },
                    { 407, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3289), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3290), false, "1排4號", 13, (byte)1 },
                    { 408, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3292), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3292), false, "1排5號", 13, (byte)1 },
                    { 409, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3294), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3295), false, "1排6號", 13, (byte)1 },
                    { 410, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3297), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3298), false, "1排7號", 13, (byte)1 },
                    { 411, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3300), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3300), false, "1排8號", 13, (byte)1 },
                    { 412, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3302), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3303), false, "1排9號", 13, (byte)1 },
                    { 413, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3305), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3306), false, "1排10號", 13, (byte)1 },
                    { 414, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3308), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3308), false, "1排11號", 13, (byte)1 },
                    { 415, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3310), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3311), false, "1排12號", 13, (byte)1 },
                    { 416, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3313), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3313), false, "1排13號", 13, (byte)1 },
                    { 417, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3315), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3316), false, "1排14號", 13, (byte)1 },
                    { 418, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3318), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3320), false, "1排15號", 13, (byte)1 },
                    { 419, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3322), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3323), false, "1排16號", 13, (byte)1 },
                    { 420, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3325), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3325), false, "1排17號", 13, (byte)1 },
                    { 421, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3327), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3328), false, "2排1號", 13, (byte)1 },
                    { 422, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3330), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3330), false, "2排2號", 13, (byte)1 },
                    { 423, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3332), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3333), false, "2排3號", 13, (byte)1 },
                    { 424, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3335), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3336), false, "2排4號", 13, (byte)1 },
                    { 425, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3338), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3338), false, "2排5號", 13, (byte)1 },
                    { 426, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3375), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3375), false, "2排6號", 13, (byte)1 },
                    { 427, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3378), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3378), false, "2排7號", 13, (byte)1 },
                    { 428, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3380), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3381), false, "2排8號", 13, (byte)1 },
                    { 429, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3383), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3384), false, "2排9號", 13, (byte)1 },
                    { 430, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3386), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3387), false, "2排10號", 13, (byte)1 },
                    { 431, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3390), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3391), false, "2排11號", 13, (byte)1 },
                    { 432, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3393), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3394), false, "2排12號", 13, (byte)1 },
                    { 433, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3396), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3397), false, "2排13號", 13, (byte)1 },
                    { 434, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3399), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3399), false, "2排14號", 13, (byte)1 },
                    { 435, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3401), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3402), false, "2排15號", 13, (byte)1 },
                    { 436, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3404), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3405), false, "2排16號", 13, (byte)1 },
                    { 437, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3407), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3407), false, "2排17號", 13, (byte)1 },
                    { 438, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3410), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3410), false, "3排1號", 13, (byte)1 },
                    { 439, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3412), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3413), false, "3排2號", 13, (byte)1 },
                    { 440, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3415), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3416), false, "3排3號", 13, (byte)1 },
                    { 441, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3417), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3418), false, "3排4號", 13, (byte)1 },
                    { 442, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3420), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3421), false, "3排5號", 13, (byte)1 },
                    { 443, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3424), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3425), false, "3排6號", 13, (byte)1 },
                    { 444, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3427), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3428), false, "3排7號", 13, (byte)1 },
                    { 445, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3429), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3430), false, "3排8號", 13, (byte)1 },
                    { 446, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3432), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3433), false, "3排9號", 13, (byte)1 },
                    { 447, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3435), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3436), false, "3排10號", 13, (byte)1 },
                    { 448, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3438), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3438), false, "3排11號", 13, (byte)1 },
                    { 449, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3440), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3441), false, "3排12號", 13, (byte)1 },
                    { 450, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3443), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3444), false, "3排13號", 13, (byte)1 },
                    { 451, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3446), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3446), false, "3排14號", 13, (byte)1 },
                    { 452, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3448), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3449), false, "3排16號", 13, (byte)0 },
                    { 453, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3451), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3452), false, "3排17號", 13, (byte)0 },
                    { 454, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3454), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3454), false, "4排1號", 13, (byte)0 },
                    { 455, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3456), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3458), false, "4排2號", 13, (byte)0 },
                    { 456, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3460), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3461), false, "4排3號", 13, (byte)0 },
                    { 457, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3463), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3464), false, "4排4號", 13, (byte)0 },
                    { 458, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3466), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3466), false, "4排5號", 13, (byte)0 },
                    { 459, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3468), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3469), false, "4排6號", 13, (byte)0 },
                    { 460, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3471), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3472), false, "4排7號", 13, (byte)0 },
                    { 461, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3474), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3474), false, "4排8號", 13, (byte)0 },
                    { 462, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3476), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3477), false, "4排9號", 13, (byte)0 },
                    { 463, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3479), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3480), false, "4排10號", 13, (byte)0 },
                    { 464, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3482), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3482), false, "4排11號", 13, (byte)0 },
                    { 465, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3484), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3485), false, "4排12號", 13, (byte)0 },
                    { 466, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3487), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3488), false, "4排13號", 13, (byte)0 }
                });

            migrationBuilder.InsertData(
                table: "ArchiveOrders",
                columns: new[] { "OrderId", "CreatedAt", "EditedAt", "EventName", "EventStartTime", "IsDeleted", "LocationAddress", "LocationName", "PurchaseAmount", "SeatNumber", "StreamingPlatform", "StreamingUrl", "TicketNumber", "TicketPrice", "TicketTypeName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(4224), null, "演唱會", new DateTime(2024, 3, 25, 19, 0, 0, 0, DateTimeKind.Unspecified), false, "台北市松山區南京東路四段2號", "台北小巨蛋", 1, "3排13號", null, null, "A123456789", 1000m, "一般票" },
                    { 2, new DateTime(2024, 3, 26, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(4238), null, "線上研討會", new DateTime(2024, 4, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, 2, null, "Zoom", "https://zoom.us/j/123456789", null, 0m, "免費票" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Capacity", "CoOrganizer", "ContactPerson", "CreatedAt", "Description", "EditedAt", "EndTime", "EventImage", "Introduction", "IsDeleted", "IsFree", "IsPrivateEvent", "Latitude", "LocationAddress", "LocationName", "Longitude", "MainOrganizer", "Name", "OrganizationId", "ParticipantPeople", "Sort", "StartTime", "Status", "StreamingPlatform", "StreamingUrl", "Type" },
                values: new object[,]
                {
                    { 1, 500, null, "", new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3827), "線上活動描述內容區", new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3828), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://picsum.photos/1300/600/?random=11", "線上活動簡介內容區", null, true, false, "120.33333", "台北市松山區南京東路四段2號", "大巨蛋", "120.33333", "Build School", "【線上直播課】掌握網路三大流量，讓你在同行中脫穎而出", 1, "[\r\n  {\r\n    \"ParticipantPeopleImage\": \"https://picsum.photos/200/200/?random=10\",\r\n    \"ParticipantPeopleId\": \"DDDD\"\r\n  },\r\n  {\r\n    \"ParticipantPeopleImage\": \"https://picsum.photos/200/200/?random=14\",\r\n    \"ParticipantPeopleId\": \"EEEE\"\r\n  },\r\n  {\r\n    \"ParticipantPeopleImage\": \"https://picsum.photos/200/200/?random=18\",\r\n    \"ParticipantPeopleId\": \"FFFF\"\r\n  }\r\n]\r\n", null, new DateTime(2024, 4, 10, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3818), (byte)1, "http;", "http;", (byte)0 },
                    { 2, 1000, null, "", new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3837), "實體活動描述內容區", new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3838), new DateTime(2024, 4, 10, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3832), "https://picsum.photos/1300/600/?random=15", "實體活動簡介內容區", null, false, false, "120.33333", "台北市松山區南京東路四段2號", "大巨蛋", "120.33333", "卡米地", "【演唱會】五月天", 2, "[\r\n  {\r\n    \"ParticipantPeopleImage\": \"https://picsum.photos/200/200/?random=10\",\r\n    \"ParticipantPeopleId\": \"DDDD\"\r\n  },\r\n  {\r\n    \"ParticipantPeopleImage\": \"https://picsum.photos/200/200/?random=14\",\r\n    \"ParticipantPeopleId\": \"EEEE\"\r\n  },\r\n  {\r\n    \"ParticipantPeopleImage\": \"https://picsum.photos/200/200/?random=18\",\r\n    \"ParticipantPeopleId\": \"FFFF\"\r\n  }\r\n]\r\n", null, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3831), (byte)1, null, null, (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "OrgFan",
                columns: new[] { "Id", "FanTime", "OrganizationId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3949), 1, 1 },
                    { 2, new DateTime(2024, 3, 26, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3952), 2, 2 }
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
                    { 1, 300, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3983), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3984), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3980), 1, null, null, "Free", 0m, null, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3979) },
                    { 2, 50, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3991), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3991), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3987), 2, null, null, "搖滾票", 6800m, null, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3986) },
                    { 3, 200, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3995), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3996), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3994), 2, null, null, "一般票", 2800m, null, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3993) },
                    { 4, 400, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3999), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(4000), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3998), 2, null, null, "站票", 800m, null, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(3998) }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "CheckCode", "CreatedAt", "EditedAt", "IsDeleted", "Number", "OrderId", "SeatId", "Status", "TicketTypeId" },
                values: new object[,]
                {
                    { 1, 123, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(4043), null, false, "A123456789", 1, 1, (byte)0, 1 },
                    { 2, 123, new DateTime(2024, 3, 26, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(4047), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(4048), false, "B987654321", 2, null, (byte)1, 2 },
                    { 3, 123, new DateTime(2024, 3, 25, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(4051), null, true, "C123456789", null, 3, (byte)0, 3 },
                    { 4, 123, new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(4054), null, false, "A123456789", 1, 1, (byte)0, 1 },
                    { 5, 123, new DateTime(2024, 3, 26, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(4057), new DateTime(2024, 3, 27, 1, 51, 12, 494, DateTimeKind.Local).AddTicks(4058), false, "B987654321", 2, null, (byte)1, 2 }
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
