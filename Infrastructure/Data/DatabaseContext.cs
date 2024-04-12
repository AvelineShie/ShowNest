using System;
using System.Collections.Generic;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ArchiveOrder> ArchiveOrders { get; set; }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<CategoryTag> CategoryTags { get; set; }

    public virtual DbSet<EcpayOrder> EcpayOrders { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventAndTagMapping> EventAndTagMappings { get; set; }

    public virtual DbSet<HistoryPassword> HistoryPasswords { get; set; }

    public virtual DbSet<IsPaidRecord> IsPaidRecords { get; set; }

    public virtual DbSet<LogInInfo> LogInInfos { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrgFan> OrgFans { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<OrganizationAndUserMapping> OrganizationAndUserMappings { get; set; }

    public virtual DbSet<PreFill> PreFills { get; set; }

    public virtual DbSet<PreferredActivityArea> PreferredActivityAreas { get; set; }

    public virtual DbSet<Seat> Seats { get; set; }

    public virtual DbSet<SeatArea> SeatAreas { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<TicketType> TicketTypes { get; set; }

    public virtual DbSet<TicketTypeAndSeatAreaMapping> TicketTypeAndSeatAreaMappings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DatabaseContext");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Chinese_Taiwan_Stroke_CI_AS");

        modelBuilder.Entity<ArchiveOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId);

            entity.ToTable(tb => tb.HasComment("訂單紀錄"));

            entity.Property(e => e.OrderId).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt)
                .HasComment("新增時間")
                .HasColumnType("datetime");
            entity.Property(e => e.EditedAt)
                .HasComment("修改時間")
                .HasColumnType("datetime");
            entity.Property(e => e.EventName)
                .IsRequired()
                .HasMaxLength(100)
                .HasComment("活動名稱");
            entity.Property(e => e.EventStartTime)
                .HasComment("活動開始時間")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasComment("標記封存");
            entity.Property(e => e.LocationAddress)
                .HasMaxLength(200)
                .HasComment("活動地址");
            entity.Property(e => e.LocationName)
                .HasMaxLength(100)
                .HasComment("活動地點");
            entity.Property(e => e.PurchaseAmount).HasComment("購買數量");
            entity.Property(e => e.SeatNumber)
                .HasMaxLength(50)
                .HasComment("座位號碼ex3排13號");
            entity.Property(e => e.StreamingPlatform)
                .HasMaxLength(100)
                .HasComment("串流平台");
            entity.Property(e => e.StreamingUrl).HasComment("串流URL");
            entity.Property(e => e.TicketNumber)
                .HasMaxLength(50)
                .HasComment("票號");
            entity.Property(e => e.TicketPrice)
                .HasComment("票價")
                .HasColumnType("money");
            entity.Property(e => e.TicketTypeName)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("票種名稱");

            entity.HasOne(d => d.Order).WithOne(p => p.ArchiveOrder)
                .HasForeignKey<ArchiveOrder>(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ArchiveOrders_Orders");
        });

        modelBuilder.Entity<Area>(entity =>
        {
            entity.ToTable("Area", tb => tb.HasComment("偏好地區列表"));

            entity.Property(e => e.Id).HasComment("區域ID");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("地區名稱");
        });

        modelBuilder.Entity<CategoryTag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Tags");

            entity.Property(e => e.Id).HasComment("類別TagID");
            entity.Property(e => e.CreatedAt)
                .HasComment("新增時間")
                .HasColumnType("datetime");
            entity.Property(e => e.EditeAt)
                .HasComment("修改時間")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasComment("標記刪除");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("類別Tag名稱");
            entity.Property(e => e.Sort).HasComment("排序預設50");
        });

        modelBuilder.Entity<EcpayOrder>(entity =>
        {
            entity.HasKey(e => e.MerchantTradeNo);

            entity.Property(e => e.MerchantTradeNo).HasMaxLength(50);
            entity.Property(e => e.MemberId)
                .HasMaxLength(50)
                .HasColumnName("MemberID");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentType).HasMaxLength(50);
            entity.Property(e => e.PaymentTypeChargeFee).HasMaxLength(50);
            entity.Property(e => e.RtnMsg).HasMaxLength(50);
            entity.Property(e => e.TradeDate).HasMaxLength(50);
            entity.Property(e => e.TradeNo).HasMaxLength(50);
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasIndex(e => e.OrganizationId, "IX_Events_OrganizationId");

            entity.Property(e => e.Id).HasComment("活動ID");
            entity.Property(e => e.Capacity).HasComment("可容納人數");
            entity.Property(e => e.CoOrganizer)
                .HasMaxLength(50)
                .HasComment("協辦單位");
            entity.Property(e => e.ContactPerson)
                .IsRequired()
                .HasComment("聯絡人欄位JSON");
            entity.Property(e => e.CreatedAt)
                .HasComment("新增時間")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasComment("活動描述HTML");
            entity.Property(e => e.EditedAt)
                .HasComment("修改時間")
                .HasColumnType("datetime");
            entity.Property(e => e.EndTime)
                .HasComment("結束時間")
                .HasColumnType("datetime");
            entity.Property(e => e.EventImage).HasComment("活動主圖");
            entity.Property(e => e.Introduction)
                .HasMaxLength(150)
                .HasComment("活動簡介");
            entity.Property(e => e.IsDeleted).HasComment("資料封存或強制下架");
            entity.Property(e => e.IsFree).HasComment("是否免費");
            entity.Property(e => e.IsPrivateEvent).HasComment("是否公開活動");
            entity.Property(e => e.Latitude)
                .HasMaxLength(50)
                .HasComment("緯度");
            entity.Property(e => e.LocationAddress)
                .HasMaxLength(200)
                .HasComment("活動地址");
            entity.Property(e => e.LocationName)
                .HasMaxLength(100)
                .HasComment("活動地點");
            entity.Property(e => e.Longitude)
                .HasMaxLength(50)
                .HasComment("經度");
            entity.Property(e => e.MainOrganizer)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("主辦單位");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasComment("活動名稱");
            entity.Property(e => e.OrganizationId).HasComment("組織ID");
            entity.Property(e => e.ParticipantPeople)
                .IsRequired()
                .HasComment("報名人欄位JSON");
            entity.Property(e => e.Sort).HasComment("預設值50");
            entity.Property(e => e.StartTime)
                .HasComment("開始時間")
                .HasColumnType("datetime");
            entity.Property(e => e.Status).HasComment("0未發佈1已發佈");
            entity.Property(e => e.StreamingPlatform)
                .HasMaxLength(100)
                .HasComment("串流平台");
            entity.Property(e => e.StreamingUrl)
                .HasMaxLength(500)
                .HasComment("串流網址");
            entity.Property(e => e.Type).HasComment("0線上1實體");

            entity.HasOne(d => d.Organization).WithMany(p => p.Events)
                .HasForeignKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Events_Organizations");
        });

        modelBuilder.Entity<EventAndTagMapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_EventAndTagMapping_1");

            entity.ToTable("EventAndTagMapping", tb => tb.HasComment("活動與類別對照"));

            entity.HasIndex(e => e.CategoryTagId, "IX_EventAndTagMapping_CategoryTagId");

            entity.HasIndex(e => e.EventId, "IX_EventAndTagMapping_EventID");

            entity.Property(e => e.Id).HasComment("活動與類別對照ID");
            entity.Property(e => e.CategoryTagId).HasComment("類別TagID");
            entity.Property(e => e.EventId)
                .HasComment("活動ID")
                .HasColumnName("EventID");

            entity.HasOne(d => d.CategoryTag).WithMany(p => p.EventAndTagMappings)
                .HasForeignKey(d => d.CategoryTagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Event and Tag Mapping_Tags");

            entity.HasOne(d => d.Event).WithMany(p => p.EventAndTagMappings)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventAndTagMapping_pEvents");
        });

        modelBuilder.Entity<HistoryPassword>(entity =>
        {
            entity.ToTable("HistoryPassword");

            entity.HasIndex(e => e.UserId, "IX_HistoryPassword_UserId");

            entity.Property(e => e.CreatedAt)
                .HasComment("新增時間")
                .HasColumnType("datetime");
            entity.Property(e => e.EditedAt)
                .HasComment("修改時間")
                .HasColumnType("datetime");
            entity.Property(e => e.UsedPassword)
                .IsRequired()
                .HasComment("使用過的密碼");
            entity.Property(e => e.UserId).HasComment("使用者ID");

            entity.HasOne(d => d.User).WithMany(p => p.HistoryPasswords)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HistoryPassword_Users1");
        });

        modelBuilder.Entity<IsPaidRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PaymentDetail");

            entity.ToTable(tb => tb.HasComment("付款紀錄"));

            entity.Property(e => e.Id).HasComment("付款紀錄ID");
            entity.Property(e => e.OrderId).HasComment("訂單ID");
            entity.Property(e => e.Result).HasComment("付款結果");
        });

        modelBuilder.Entity<LogInInfo>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("LogInInfo");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasComment("使用者ID");
            entity.Property(e => e.Account)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("帳號");
            entity.Property(e => e.CreatedAt)
                .HasComment("新增時間")
                .HasColumnType("datetime");
            entity.Property(e => e.EditedAt)
                .HasComment("修改時間")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasComment("電子郵件");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasComment("密碼");

            entity.HasOne(d => d.User).WithOne(p => p.LogInInfo)
                .HasForeignKey<LogInInfo>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LogInInfo_Users");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable(tb => tb.HasComment("訂單"));

            entity.HasIndex(e => e.UserId, "IX_Orders_UserId");

            entity.Property(e => e.Id).HasComment("訂單ID");
            entity.Property(e => e.ContactPerson)
                .IsRequired()
                .HasComment("聯絡人資料JSON");
            entity.Property(e => e.CreatedAt)
                .HasComment("新增時間")
                .HasColumnType("datetime");
            entity.Property(e => e.EditedAt)
                .HasComment("修改時間")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasComment("標記封存");
            entity.Property(e => e.IsDisplayed).HasComment("0不顯示參加活動1顯示");
            entity.Property(e => e.ParticipantPeople).HasComment("報名人資料JSON");
            entity.Property(e => e.PaymentType).HasComment("0免費1信用卡");
            entity.Property(e => e.SeatNumber)
                .HasMaxLength(50)
                .HasComment("座位號碼ex3排13號");
            entity.Property(e => e.Status).HasComment("0待付款1成功2付款失敗3取消");
            entity.Property(e => e.TicketId).HasComment("票券ID");
            entity.Property(e => e.UserId).HasComment("使用者ID");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Users1");
        });

        modelBuilder.Entity<OrgFan>(entity =>
        {
            entity.ToTable("OrgFan", tb => tb.HasComment("組織粉絲"));

            entity.HasIndex(e => e.OrganizationId, "IX_OrgFan_OrganizationId");

            entity.HasIndex(e => e.UserId, "IX_OrgFan_UserId");

            entity.Property(e => e.Id).HasComment("入坑ID");
            entity.Property(e => e.FanTime)
                .HasComment("成為粉絲時間")
                .HasColumnType("datetime");
            entity.Property(e => e.OrganizationId).HasComment("組織ID");
            entity.Property(e => e.UserId).HasComment("使用者ID");

            entity.HasOne(d => d.Organization).WithMany(p => p.OrgFans)
                .HasForeignKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrgFan_Organizations");

            entity.HasOne(d => d.User).WithMany(p => p.OrgFans)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrgFan_Users");
        });

        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_OrganizationInfo");

            entity.ToTable(tb => tb.HasComment("組織"));

            entity.HasIndex(e => e.OwnerId, "IX_Organizations_OwnerId");

            entity.Property(e => e.Id).HasComment("組織ID");
            entity.Property(e => e.ContactMobile)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("聯絡手機");
            entity.Property(e => e.ContactName)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("聯絡人姓名");
            entity.Property(e => e.ContactTelephone)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("連絡電話");
            entity.Property(e => e.CreatedAt)
                .HasComment("新增時間")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .HasComment("組織簡介");
            entity.Property(e => e.EditedAt)
                .HasComment("修改時間")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .HasComment("Email");
            entity.Property(e => e.Fblink)
                .HasComment("FB連結")
                .HasColumnName("FBLink");
            entity.Property(e => e.Igaccount)
                .HasComment("IG連結")
                .HasColumnName("IGAccount");
            entity.Property(e => e.ImgUrl)
                .HasComment("組織形象圖")
                .HasColumnName("ImgURL");
            entity.Property(e => e.IsDeleted).HasComment("標記封存");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("組織名稱");
            entity.Property(e => e.OrganizationUrl)
                .IsRequired()
                .HasComment("站內連結")
                .HasColumnName("OrganizationURL");
            entity.Property(e => e.OuterUrl)
                .HasComment("站外連結")
                .HasColumnName("OuterURL");
            entity.Property(e => e.OwnerId).HasComment("擁有者UserId");

            entity.HasOne(d => d.Owner).WithMany(p => p.Organizations)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Organizations_Users");
        });

        modelBuilder.Entity<OrganizationAndUserMapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_OrganizationUserMapping");

            entity.ToTable("OrganizationAndUserMapping", tb => tb.HasComment("組織與使用者對照"));

            entity.HasIndex(e => e.OrganizationId, "IX_OrganizationAndUserMapping_OrganizationId");

            entity.HasIndex(e => e.UserId, "IX_OrganizationAndUserMapping_UserId");

            entity.Property(e => e.Id).HasComment("組織與使用者對照ID");
            entity.Property(e => e.OrganizationId).HasComment("組織ID");
            entity.Property(e => e.UserId).HasComment("使用者ID");

            entity.HasOne(d => d.Organization).WithMany(p => p.OrganizationAndUserMappings)
                .HasForeignKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrganizationAndUserMapping_Organizations");

            entity.HasOne(d => d.User).WithMany(p => p.OrganizationAndUserMappings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrganizationAndUserMapping_Users");
        });

        modelBuilder.Entity<PreFill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Prefill_1");

            entity.ToTable("PreFill", tb => tb.HasComment("報名預填資料"));

            entity.HasIndex(e => e.UserId, "IX_PreFill_UserId");

            entity.Property(e => e.Id).HasComment("預填資料ID");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasComment("聯絡地址");
            entity.Property(e => e.CompanyAddress)
                .HasMaxLength(50)
                .HasComment("公司地址");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .HasComment("公司名稱");
            entity.Property(e => e.CompanyPostalCode).HasComment("公司郵遞區號");
            entity.Property(e => e.County)
                .HasMaxLength(50)
                .HasComment("縣市");
            entity.Property(e => e.CreatedAt)
                .HasComment("新增時間")
                .HasColumnType("datetime");
            entity.Property(e => e.District)
                .HasMaxLength(50)
                .HasComment("鄉鎮區域");
            entity.Property(e => e.EditedAt)
                .HasComment("修改時間")
                .HasColumnType("datetime");
            entity.Property(e => e.Mobile)
                .HasMaxLength(50)
                .HasComment("手機號碼");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasComment("姓名");
            entity.Property(e => e.PostalCode).HasComment("郵遞區號");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasComment("職稱");
            entity.Property(e => e.UserId).HasComment("使用者ID");

            entity.HasOne(d => d.User).WithMany(p => p.PreFills)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PreFill_Users");
        });

        modelBuilder.Entity<PreferredActivityArea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PreferredActivityArea_1");

            entity.ToTable("PreferredActivityArea", tb => tb.HasComment("使用者偏好活動區域"));

            entity.HasIndex(e => e.AreaId, "IX_PreferredActivityArea_AreaId");

            entity.HasIndex(e => e.UserId, "IX_PreferredActivityArea_UserId");

            entity.Property(e => e.Id).HasComment("偏好區域ID");
            entity.Property(e => e.AreaId).HasComment("區域ID");
            entity.Property(e => e.UserId).HasComment("使用者ID");

            entity.HasOne(d => d.Area).WithMany(p => p.PreferredActivityAreas)
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PreferredActivityArea_Area");

            entity.HasOne(d => d.User).WithMany(p => p.PreferredActivityAreas)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PreferredActivityArea_Users");
        });

        modelBuilder.Entity<Seat>(entity =>
        {
            entity.HasIndex(e => e.SeatAreaId, "IX_Seats_SeatAreaId");

            entity.Property(e => e.Id).HasComment("座位ID");
            entity.Property(e => e.CreatedAt)
                .HasComment("新增時間")
                .HasColumnType("datetime");
            entity.Property(e => e.EditedAt)
                .HasComment("修改時間")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasComment("標記封存");
            entity.Property(e => e.Number)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("座位號碼ex3排13號");
            entity.Property(e => e.SeatAreaId).HasComment("座位區域ID");
            entity.Property(e => e.Status).HasComment("0可選1已選2不可選");

            entity.HasOne(d => d.SeatArea).WithMany(p => p.Seats)
                .HasForeignKey(d => d.SeatAreaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seats_SeatAreas");
        });

        modelBuilder.Entity<SeatArea>(entity =>
        {
            entity.Property(e => e.Id).HasComment("座位區域ID");
            entity.Property(e => e.CreatedAt)
                .HasComment("新增時間")
                .HasColumnType("datetime");
            entity.Property(e => e.EditedAt)
                .HasComment("修改時間")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasComment("標記封存");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("座位區域名稱");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasIndex(e => e.OrderId, "IX_Tickets_OrderId");

            entity.HasIndex(e => e.SeatId, "IX_Tickets_SeatId");

            entity.HasIndex(e => e.TicketTypeId, "IX_Tickets_TicketTypeId");

            entity.Property(e => e.Id).HasComment("票券ID");
            entity.Property(e => e.CheckCode).HasComment("檢查碼");
            entity.Property(e => e.CreatedAt)
                .HasComment("新增時間")
                .HasColumnType("datetime");
            entity.Property(e => e.EditedAt)
                .HasComment("修改時間")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasComment("作廢票券");
            entity.Property(e => e.Number)
                .HasMaxLength(50)
                .HasComment("票號");
            entity.Property(e => e.OrderId).HasComment("訂單ID");
            entity.Property(e => e.SeatId).HasComment("座位ID");
            entity.Property(e => e.Status).HasComment("0未驗票1驗票成功");
            entity.Property(e => e.TicketTypeId).HasComment("票種ID");

            entity.HasOne(d => d.Order).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_Tickets_Orders");

            entity.HasOne(d => d.Seat).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.SeatId)
                .HasConstraintName("FK_Tickets_Seats");

            entity.HasOne(d => d.TicketType).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.TicketTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tickets_TicketTypes");
        });

        modelBuilder.Entity<TicketType>(entity =>
        {
            entity.HasIndex(e => e.EventId, "IX_TicketTypes_EventId");

            entity.Property(e => e.Id).HasComment("票種ID");
            entity.Property(e => e.CapacityAmount).HasComment("票券數量");
            entity.Property(e => e.CreatedAt)
                .HasComment("新增時間")
                .HasColumnType("datetime");
            entity.Property(e => e.EditedAt)
                .HasComment("修改時間")
                .HasColumnType("datetime");
            entity.Property(e => e.EndSaleTime)
                .HasComment("結束販售時間")
                .HasColumnType("datetime");
            entity.Property(e => e.EventId).HasComment("活動ID");
            entity.Property(e => e.IsDeleted).HasComment("強制下架");
            entity.Property(e => e.IsDisplayed).HasComment("是否顯示");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("票種名稱");
            entity.Property(e => e.Price)
                .HasComment("票價")
                .HasColumnType("money");
            entity.Property(e => e.Sort).HasComment("預設值50");
            entity.Property(e => e.StartSaleTime)
                .HasComment("開始販售時間")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Event).WithMany(p => p.TicketTypes)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TicketTypes_Events");
        });

        modelBuilder.Entity<TicketTypeAndSeatAreaMapping>(entity =>
        {
            entity.ToTable("TicketTypeAndSeatAreaMapping");

            entity.HasOne(d => d.SeatArea).WithMany(p => p.TicketTypeAndSeatAreaMappings)
                .HasForeignKey(d => d.SeatAreaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TicketTypeAndSeatAreaMapping_SeatAreas");

            entity.HasOne(d => d.TicketType).WithMany(p => p.TicketTypeAndSeatAreaMappings)
                .HasForeignKey(d => d.TicketTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TicketTypeAndSeatAreaMapping_TicketTypes");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).HasComment("使用者ID");
            entity.Property(e => e.Birthday)
                .HasComment("生日")
                .HasColumnType("date");
            entity.Property(e => e.CreatedAt)
                .HasComment("新增時間")
                .HasColumnType("datetime");
            entity.Property(e => e.EditedAt)
                .HasComment("修改時間")
                .HasColumnType("datetime");
            entity.Property(e => e.EdmSubscription).HasComment("訂閱電子報");
            entity.Property(e => e.Gender).HasComment("性別");
            entity.Property(e => e.Image).HasComment("帳號照片");
            entity.Property(e => e.LastLogInAt)
                .HasComment("上次登入時間")
                .HasColumnType("datetime");
            entity.Property(e => e.Mobile)
                .HasMaxLength(50)
                .HasComment("手機號碼");
            entity.Property(e => e.Nickname)
                .HasMaxLength(50)
                .HasComment("暱稱");
            entity.Property(e => e.PersonalProfile)
                .HasMaxLength(300)
                .HasComment("個人簡介");
            entity.Property(e => e.PersonalUrl)
                .HasComment("個人網址")
                .HasColumnName("PersonalURL");
            entity.Property(e => e.Status).HasComment("0未驗證EMAIL1已驗證EMAIL");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
