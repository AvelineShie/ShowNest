using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Test03171600 : Migration
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
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序預設50"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "標記刪除"),
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
                name: "PreFill",
                columns: table => new
                {
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
                    table.PrimaryKey("PK_Prefill_1", x => x.UserId);
                },
                comment: "報名預填資料");

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
                    Id = table.Column<int>(type: "int", nullable: false, comment: "使用者ID"),
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
                    table.ForeignKey(
                        name: "FK_Users_Prefill",
                        column: x => x.Id,
                        principalTable: "PreFill",
                        principalColumn: "UserId");
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
                    UserId = table.Column<int>(type: "int", nullable: false, comment: "使用者ID"),
                    UsedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "使用過的密碼"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, comment: "新增時間"),
                    EditedAt = table.Column<DateTime>(type: "datetime", nullable: true, comment: "修改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryPassword", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_HistoryPassword_Users",
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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "標記封存"),
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
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "結束時間"),
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
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "預設值50"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "資料封存或強制下架"),
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
                    Sort = table.Column<byte>(type: "tinyint", nullable: false, comment: "預設值50"),
                    IsDisplayed = table.Column<bool>(type: "bit", nullable: false, comment: "是否顯示"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "強制下架"),
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
                    CheckCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "檢查碼")
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

            migrationBuilder.DropTable(
                name: "PreFill");
        }
    }
}
