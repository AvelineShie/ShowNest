using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Test0325 : Migration
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
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "活動名稱"),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "開始時間"),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: true, comment: "結束時間"),
                    Type = table.Column<byte>(type: "tinyint", nullable: false, comment: "0線上1實體"),
                    LocationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "活動地點"),
                    LocationAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "活動地址"),
                    Longitude = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "經度"),
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
                    { 1, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4311), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4311), null, "音樂", null },
                    { 2, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4314), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4314), null, "戲劇", null },
                    { 3, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4316), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4317), null, "展覽", null }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ContactPerson", "CreatedAt", "EditedAt", "IsDeleted", "IsDisplayed", "ParticipantPeople", "PaymentType", "SeatNumber", "Status", "TicketId", "UserId" },
                values: new object[,]
                {
                    { 4, "{\"Name\":\"Sophia Davis\",\"Email\":\"sophia.davis@example.com\",\"Phone\":\"0935678901\"}", new DateTime(2024, 3, 5, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4530), new DateTime(2024, 3, 7, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4531), true, false, null, (byte)0, "7排20號", (byte)3, 4, 4 },
                    { 5, "{\"Name\":\"William Thompson\",\"Email\":\"william.thompson@example.com\",\"Phone\":\"0912345670\"}", new DateTime(2024, 2, 29, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4534), new DateTime(2024, 3, 3, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4543), false, true, "{\"Name\":\"Olivia Johnson\",\"Age\":28}", (byte)1, "4排3號", (byte)1, 5, 5 },
                    { 6, "{\"Name\":\"James Anderson\",\"Email\":\"james.anderson@example.com\",\"Phone\":\"0987654320\"}", new DateTime(2024, 2, 24, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4546), null, false, false, null, (byte)0, "6排18號", (byte)0, 6, 6 },
                    { 7, "{\"Name\":\"Emma Thomas\",\"Email\":\"emma.thomas@example.com\",\"Phone\":\"0923456780\"}", new DateTime(2024, 2, 19, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4549), new DateTime(2024, 2, 22, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4550), false, true, "{\"Name\":\"Daniel Wilson\",\"Age\":35}", (byte)1, "1排9號", (byte)2, 7, 7 },
                    { 8, "{\"Name\":\"Ava Jackson\",\"Email\":\"ava.jackson@example.com\",\"Phone\":\"0935678900\"}", new DateTime(2024, 2, 14, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4579), new DateTime(2024, 2, 16, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4580), true, false, null, (byte)0, "8排7號", (byte)3, 8, 8 },
                    { 9, "{\"Name\":\"Michael Taylor\",\"Email\":\"michael.taylor@example.com\",\"Phone\":\"0912345671\"}", new DateTime(2024, 2, 9, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4583), new DateTime(2024, 2, 12, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4584), false, true, "{\"Name\":\"Sophia Davis\",\"Age\":22}", (byte)1, "5排15號", (byte)1, 9, 9 },
                    { 10, "{\"Name\":\"Daniel Brown\",\"Email\":\"daniel.brown@example.com\",\"Phone\":\"0987654321\"}", new DateTime(2024, 2, 4, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4586), null, false, false, null, (byte)0, "3排6號", (byte)0, 10, 10 },
                    { 11, "{\"Name\":\"Olivia Wilson\",\"Email\":\"olivia.wilson@example.com\",\"Phone\":\"0923456781\"}", new DateTime(2024, 1, 30, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4589), new DateTime(2024, 2, 2, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4592), false, true, "{\"Name\":\"William Johnson\",\"Age\":40}", (byte)1, "7排11號", (byte)2, 11, 11 },
                    { 12, "{\"Name\":\"William Davis\",\"Email\":\"william.davis@example.com\",\"Phone\":\"0935678902\"}", new DateTime(2024, 1, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4594), new DateTime(2024, 1, 27, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4595), true, false, null, (byte)0, "4排22號", (byte)3, 12, 12 },
                    { 13, "{\"Name\":\"Sophia Thompson\",\"Email\":\"sophia.thompson@example.com\",\"Phone\":\"0912345672\"}", new DateTime(2024, 1, 20, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4598), new DateTime(2024, 1, 23, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4598), false, true, "{\"Name\":\"James Anderson\",\"Age\":27}", (byte)1, "6排4號", (byte)1, 13, 13 },
                    { 14, "{\"Name\":\"James Johnson\",\"Email\":\"james.johnson@example.com\",\"Phone\":\"0987654322\"}", new DateTime(2024, 1, 15, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4601), null, false, false, null, (byte)0, "2排17號", (byte)0, 14, 14 },
                    { 15, "{\"Name\":\"Emma Brown\",\"Email\":\"emma.brown@example.com\",\"Phone\":\"0923456782\"}", new DateTime(2024, 1, 10, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4603), new DateTime(2024, 1, 13, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4604), false, true, "{\"Name\":\"Olivia Thomas\",\"Age\":32}", (byte)1, "8排12號", (byte)2, 15, 15 },
                    { 16, "{\"Name\":\"Ava Wilson\",\"Email\":\"ava.wilson@example.com\",\"Phone\":\"0935678903\"}", new DateTime(2024, 1, 5, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4607), new DateTime(2024, 1, 7, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4608), true, false, null, (byte)0, "5排2號", (byte)3, 16, 16 },
                    { 17, "{\"Name\":\"Michael Davis\",\"Email\":\"michael.davis@example.com\",\"Phone\":\"0912345673\"}", new DateTime(2023, 12, 31, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4610), new DateTime(2024, 1, 3, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4611), false, true, "{\"Name\":\"Daniel Jackson\",\"Age\":29}", (byte)1, "6排9號", (byte)1, 17, 17 },
                    { 18, "{\"Name\":\"Daniel Taylor\",\"Email\":\"daniel.taylor@example.com\",\"Phone\":\"0987654323\"}", new DateTime(2023, 12, 26, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4613), null, false, false, null, (byte)0, "3排20號", (byte)0, 18, 18 },
                    { 19, "{\"Name\":\"Olivia Anderson\",\"Email\":\"olivia.anderson@example.com\",\"Phone\":\"0923456783\"}", new DateTime(2023, 12, 21, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4616), new DateTime(2023, 12, 24, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4617), false, true, "{\"Name\":\"Emma Davis\",\"Age\":36}", (byte)1, "7排3號", (byte)2, 19, 19 },
                    { 20, "{\"Name\":\"William Thomas\",\"Email\":\"william.thomas@example.com\",\"Phone\":\"0935678904\"}", new DateTime(2023, 12, 16, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4620), new DateTime(2023, 12, 18, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4621), true, false, null, (byte)0, "4排8號", (byte)3, 20, 20 }
                });

            migrationBuilder.InsertData(
                table: "PreFill",
                columns: new[] { "Id", "Address", "CompanyAddress", "CompanyName", "CompanyPostalCode", "County", "CreatedAt", "District", "EditedAt", "Mobile", "Name", "PostalCode", "Title", "UserId" },
                values: new object[,]
                {
                    { 11, "No.1, Lane 10, Section 3, Zhongxiao E Rd", null, null, null, "Taipei", new DateTime(2024, 3, 15, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4880), "Daan", null, "0912345678", "John Doe", 106, null, 11 },
                    { 12, "No.100, Guandu Rd", null, null, null, "New Taipei", new DateTime(2024, 3, 16, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4883), "Banqiao", null, "0912345679", "Jane Doe", 107, null, 12 },
                    { 13, "No.20, Jhongsing Rd", null, null, null, "Taoyuan", new DateTime(2024, 3, 17, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4885), "Zhongli", null, "0923456789", "Mike Chen", 108, null, 13 }
                });

            migrationBuilder.InsertData(
                table: "SeatAreas",
                columns: new[] { "Id", "CreatedAt", "EditedAt", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 6, new DateTime(2024, 3, 10, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4837), null, false, "F區" },
                    { 7, new DateTime(2024, 3, 11, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4840), null, false, "G區" },
                    { 8, new DateTime(2024, 3, 12, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4842), null, false, "H區" },
                    { 9, new DateTime(2024, 3, 13, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4843), null, false, "I區" },
                    { 10, new DateTime(2024, 3, 14, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4845), null, false, "J區" },
                    { 11, new DateTime(2024, 3, 15, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4847), null, false, "K區" },
                    { 12, new DateTime(2024, 3, 16, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4848), null, false, "L區" },
                    { 13, new DateTime(2024, 3, 17, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4850), null, false, "M區" },
                    { 14, new DateTime(2024, 3, 18, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4851), null, false, "N區" },
                    { 15, new DateTime(2024, 3, 19, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4855), null, false, "O區" },
                    { 16, new DateTime(2024, 3, 20, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4857), null, false, "P區" }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreatedAt", "EditedAt", "IsDeleted", "Number", "SeatAreaId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4032), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4033), false, "1排1號", 1, (byte)1 },
                    { 2, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4036), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4047), false, "1排2號", 1, (byte)1 },
                    { 3, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4059), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4060), false, "1排3號", 1, (byte)1 },
                    { 4, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4062), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4063), false, "1排4號", 1, (byte)1 },
                    { 5, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4064), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4065), false, "1排5號", 1, (byte)1 },
                    { 6, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4067), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4068), false, "1排6號", 1, (byte)1 },
                    { 7, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4070), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4070), false, "1排7號", 1, (byte)1 },
                    { 8, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4072), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4073), false, "1排8號", 1, (byte)1 },
                    { 9, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4075), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4075), false, "1排9號", 1, (byte)1 },
                    { 10, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4077), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4077), false, "1排10號", 1, (byte)1 },
                    { 11, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4079), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4080), false, "1排11號", 1, (byte)1 },
                    { 12, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4082), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4082), false, "1排12號", 1, (byte)1 },
                    { 13, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4084), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4084), false, "1排13號", 1, (byte)1 },
                    { 14, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4088), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4088), false, "1排14號", 1, (byte)1 },
                    { 15, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4090), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4090), false, "1排15號", 1, (byte)1 },
                    { 16, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4092), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4093), false, "1排16號", 1, (byte)1 },
                    { 17, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4095), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4095), false, "1排17號", 1, (byte)1 },
                    { 18, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4097), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4097), false, "2排1號", 1, (byte)1 },
                    { 19, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4099), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4100), false, "2排2號", 1, (byte)1 },
                    { 20, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4102), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4102), false, "2排3號", 1, (byte)1 },
                    { 21, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4104), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4104), false, "2排4號", 1, (byte)1 },
                    { 22, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4106), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4107), false, "2排5號", 1, (byte)1 },
                    { 23, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4109), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4109), false, "2排6號", 1, (byte)1 },
                    { 24, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4111), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4111), false, "2排7號", 1, (byte)1 },
                    { 25, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4113), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4114), false, "2排8號", 1, (byte)1 },
                    { 26, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4115), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4116), false, "2排9號", 1, (byte)1 },
                    { 27, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4121), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4121), false, "2排10號", 1, (byte)1 },
                    { 28, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4123), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4124), false, "2排11號", 1, (byte)1 },
                    { 29, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4125), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4126), false, "2排12號", 1, (byte)1 },
                    { 30, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4128), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4128), false, "2排13號", 1, (byte)1 },
                    { 31, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4130), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4131), false, "2排14號", 1, (byte)1 },
                    { 32, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4132), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4133), false, "2排15號", 1, (byte)1 },
                    { 33, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4135), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4135), false, "2排16號", 1, (byte)1 },
                    { 34, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4137), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4137), false, "2排17號", 1, (byte)1 },
                    { 35, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4139), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4140), false, "3排1號", 1, (byte)1 },
                    { 36, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4141), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4142), false, "3排2號", 1, (byte)1 },
                    { 37, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4144), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4144), false, "3排3號", 1, (byte)1 },
                    { 38, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4146), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4147), false, "3排4號", 1, (byte)1 },
                    { 39, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4148), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4149), false, "3排5號", 1, (byte)1 },
                    { 40, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4152), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4152), false, "3排6號", 1, (byte)1 },
                    { 41, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4154), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4155), false, "3排7號", 1, (byte)1 },
                    { 42, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4156), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4157), false, "3排8號", 1, (byte)1 },
                    { 43, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4158), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4159), false, "3排9號", 1, (byte)1 },
                    { 44, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4161), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4161), false, "3排10號", 1, (byte)1 },
                    { 45, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4163), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4163), false, "3排11號", 1, (byte)1 },
                    { 46, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4165), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4166), false, "3排12號", 1, (byte)1 },
                    { 47, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4167), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4168), false, "3排13號", 1, (byte)1 },
                    { 48, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4170), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4170), false, "3排14號", 1, (byte)1 },
                    { 49, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4172), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4173), false, "3排16號", 1, (byte)0 },
                    { 50, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4174), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4175), false, "3排17號", 1, (byte)0 },
                    { 51, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4177), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4177), false, "4排1號", 1, (byte)0 },
                    { 52, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4179), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4180), false, "4排2號", 1, (byte)0 },
                    { 53, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4182), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4183), false, "4排3號", 1, (byte)0 },
                    { 54, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4185), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4185), false, "4排4號", 1, (byte)0 },
                    { 55, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4187), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4188), false, "4排5號", 1, (byte)0 },
                    { 56, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4189), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4190), false, "4排6號", 1, (byte)0 },
                    { 57, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4192), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4192), false, "4排7號", 1, (byte)0 },
                    { 58, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4194), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4195), false, "4排8號", 1, (byte)0 },
                    { 59, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4196), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4197), false, "4排9號", 1, (byte)0 },
                    { 60, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4199), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4199), false, "4排10號", 1, (byte)0 },
                    { 61, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4201), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4202), false, "4排11號", 1, (byte)0 },
                    { 62, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4203), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4204), false, "4排12號", 1, (byte)0 },
                    { 63, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4234), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4234), false, "4排13號", 1, (byte)0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "CreatedAt", "EditedAt", "EdmSubscription", "Gender", "Image", "LastLogInAt", "Mobile", "Nickname", "PersonalProfile", "PersonalURL", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(3902), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(3903), true, (byte)1, "https://image.com/alice.jpg", new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(3889), "0912345678", "Alice", "I'm Alice!", "https://alice.com", (byte)1 },
                    { 2, new DateTime(1985, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(3909), null, false, (byte)2, null, null, "0987654321", "Bob", null, null, (byte)0 },
                    { 3, new DateTime(1995, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 15, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(3918), new DateTime(2024, 3, 23, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(3919), true, (byte)2, "https://image.com/charlie.png", new DateTime(2024, 3, 20, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(3912), "0955555555", "Charlie", "Hello world!", "https://charlie.com", (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "LogInInfo",
                columns: new[] { "UserId", "Account", "CreatedAt", "EditedAt", "Email", "Password" },
                values: new object[,]
                {
                    { 1, "abc123", new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(3997), null, "abc@gmail.com", "12345678" },
                    { 2, "def456", new DateTime(2024, 3, 24, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(3999), null, "def@gmail.com", "87654321" },
                    { 3, "ghi789", new DateTime(2024, 3, 23, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4002), null, "ghi@gmail.com", "98765432" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ContactPerson", "CreatedAt", "EditedAt", "IsDeleted", "IsDisplayed", "ParticipantPeople", "PaymentType", "SeatNumber", "Status", "TicketId", "UserId" },
                values: new object[,]
                {
                    { 1, "{\"Name\":\"John Doe\",\"Email\":\"john.doe@example.com\",\"Phone\":\"0912345678\"}", new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4518), new DateTime(2024, 3, 20, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4519), false, true, "{\"Name\":\"Jane Smith\",\"Age\":25}", (byte)1, "3排13號", (byte)1, 1, 1 },
                    { 2, "{\"Name\":\"Bob Johnson\",\"Email\":\"bob.johnson@example.com\",\"Phone\":\"0987654321\"}", new DateTime(2024, 3, 15, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4523), null, false, false, null, (byte)0, "5排8號", (byte)0, 2, 2 },
                    { 3, "{\"Name\":\"Emily Wilson\",\"Email\":\"emily.wilson@example.com\",\"Phone\":\"0923456789\"}", new DateTime(2024, 3, 10, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4526), new DateTime(2024, 3, 13, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4527), false, true, "{\"Name\":\"Michael Brown\",\"Age\":30}", (byte)1, "2排5號", (byte)2, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "ContactMobile", "ContactName", "ContactTelephone", "CreatedAt", "Description", "EditedAt", "Email", "FBLink", "IGAccount", "ImgURL", "IsDeleted", "Name", "OrganizationURL", "OuterURL", "OwnerId" },
                values: new object[,]
                {
                    { 1, "0123456789", "Alice", "02-2123-45678", new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4373), "組織簡介內容區", new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4374), null, null, null, null, null, "Build School", "HTTP", null, 1 },
                    { 2, "0123456789", "Bob", "02-2123-45678", new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4378), "組織簡介內容區", new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4379), null, null, null, null, null, "卡米地", "HTTP", null, 2 },
                    { 3, "0123456789", "Charlie", "02-2123-45678", new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4381), "組織簡介內容區", new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4382), null, null, null, null, null, "海邊的卡夫卡", "HTTP", null, 3 }
                });

            migrationBuilder.InsertData(
                table: "PreferredActivityArea",
                columns: new[] { "Id", "AreaId", "UserId" },
                values: new object[,]
                {
                    { 4, 1, 1 },
                    { 5, 2, 1 },
                    { 6, 3, 2 },
                    { 7, 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "ArchiveOrders",
                columns: new[] { "OrderId", "CreatedAt", "EditedAt", "EventName", "EventStartTime", "IsDeleted", "LocationAddress", "LocationName", "PurchaseAmount", "SeatNumber", "StreamingPlatform", "StreamingUrl", "TicketNumber", "TicketPrice", "TicketTypeName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4798), null, "演唱會", new DateTime(2024, 3, 25, 19, 0, 0, 0, DateTimeKind.Unspecified), false, "台北市松山區南京東路四段2號", "台北小巨蛋", 1, "3排13號", null, null, "A123456789", 1000m, "一般票" },
                    { 2, new DateTime(2024, 3, 24, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4810), null, "線上研討會", new DateTime(2024, 4, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, 2, null, "Zoom", "https://zoom.us/j/123456789", null, 0m, "免費票" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Capacity", "CoOrganizer", "ContactPerson", "CreatedAt", "Description", "EditedAt", "EndTime", "EventImage", "Introduction", "IsDeleted", "IsFree", "IsPrivateEvent", "Latitude", "LocationAddress", "LocationName", "Longitude", "MainOrganizer", "Name", "OrganizationId", "ParticipantPeople", "Sort", "StartTime", "Status", "StreamingPlatform", "StreamingUrl", "Type" },
                values: new object[,]
                {
                    { 1, 500, null, "", new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4279), "線上活動描述內容區", new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4280), null, "https://picsum.photos/1300/600/?random=11", "線上活動簡介內容區", null, true, false, null, null, null, null, "Build School", "【線上直播課】掌握網路三大流量，讓你在同行中脫穎而出", 1, "[\r\n  {\r\n    \"ParticipantPeopleImage\": \"https://picsum.photos/200/200/?random=10\",\r\n    \"ParticipantPeopleId\": \"DDDD\"\r\n  },\r\n  {\r\n    \"ParticipantPeopleImage\": \"https://picsum.photos/200/200/?random=14\",\r\n    \"ParticipantPeopleId\": \"EEEE\"\r\n  },\r\n  {\r\n    \"ParticipantPeopleImage\": \"https://picsum.photos/200/200/?random=18\",\r\n    \"ParticipantPeopleId\": \"FFFF\"\r\n  }\r\n]\r\n", null, new DateTime(2024, 4, 8, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4273), (byte)1, "http;", "http;", (byte)0 },
                    { 2, 1000, null, "", new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4288), "實體活動描述內容區", new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4288), new DateTime(2024, 4, 8, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4283), "https://picsum.photos/1300/600/?random=15", "實體活動簡介內容區", null, false, false, "120.33333", "", "大巨蛋", "120.33333", "卡米地", "【演唱會】五月天", 2, "[\r\n  {\r\n    \"ParticipantPeopleImage\": \"https://picsum.photos/200/200/?random=10\",\r\n    \"ParticipantPeopleId\": \"DDDD\"\r\n  },\r\n  {\r\n    \"ParticipantPeopleImage\": \"https://picsum.photos/200/200/?random=14\",\r\n    \"ParticipantPeopleId\": \"EEEE\"\r\n  },\r\n  {\r\n    \"ParticipantPeopleImage\": \"https://picsum.photos/200/200/?random=18\",\r\n    \"ParticipantPeopleId\": \"FFFF\"\r\n  }\r\n]\r\n", null, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4282), (byte)1, null, null, (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "OrgFan",
                columns: new[] { "Id", "FanTime", "OrganizationId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4433), 1, 1 },
                    { 2, new DateTime(2024, 3, 24, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4435), 2, 2 }
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
                    { 1, 300, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4479), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4479), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4476), 1, null, null, "Free", 0m, null, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4475) },
                    { 2, 50, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4485), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4486), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4482), 2, null, null, "搖滾票", 6800m, null, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4481) },
                    { 3, 200, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4489), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4490), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4488), 2, null, null, "一般票", 2800m, null, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4488) },
                    { 4, 400, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4493), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4493), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4492), 2, null, null, "站票", 800m, null, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4491) }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "CheckCode", "CreatedAt", "EditedAt", "IsDeleted", "Number", "OrderId", "SeatId", "Status", "TicketTypeId" },
                values: new object[,]
                {
                    { 21, 1234, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4651), null, false, "A123456789", 1, 1, (byte)0, 1 },
                    { 22, 1235, new DateTime(2024, 3, 24, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4654), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4655), false, "B987654321", 2, null, (byte)1, 2 },
                    { 23, 1236, new DateTime(2024, 3, 23, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4658), null, true, "C123456789", null, 3, (byte)0, 3 },
                    { 24, 1237, new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4660), null, false, "A123456789", 1, 1, (byte)0, 1 },
                    { 25, 1238, new DateTime(2024, 3, 24, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4663), new DateTime(2024, 3, 25, 14, 7, 46, 10, DateTimeKind.Local).AddTicks(4663), false, "B987654321", 2, null, (byte)1, 2 }
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
