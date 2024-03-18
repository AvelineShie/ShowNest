using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities;

/// <summary>
/// 訂單紀錄
/// </summary>
public partial class ArchiveOrder
{
    public int OrderId { get; set; }

    /// <summary>
    /// 活動開始時間
    /// </summary>
    public DateTime EventStartTime { get; set; }

    /// <summary>
    /// 活動名稱
    /// </summary>
    public string EventName { get; set; } = null!;

    /// <summary>
    /// 活動地點
    /// </summary>
    public string? LocationName { get; set; }

    /// <summary>
    /// 活動地址
    /// </summary>
    public string? LocationAddress { get; set; }

    /// <summary>
    /// 串流平台
    /// </summary>
    public string? StreamingPlatform { get; set; }

    /// <summary>
    /// 串流URL
    /// </summary>
    public string? StreamingUrl { get; set; }

    /// <summary>
    /// 票種名稱
    /// </summary>
    public string TicketTypeName { get; set; } = null!;

    /// <summary>
    /// 票號
    /// </summary>
    public string? TicketNumber { get; set; }

    /// <summary>
    /// 座位號碼ex3排13號
    /// </summary>
    public string? SeatNumber { get; set; }

    /// <summary>
    /// 票價
    /// </summary>
    public decimal TicketPrice { get; set; }

    /// <summary>
    /// 購買數量
    /// </summary>
    public int PurchaseAmount { get; set; }

    /// <summary>
    /// 標記封存
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// 新增時間
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// 修改時間
    /// </summary>
    public DateTime? EditedAt { get; set; }

    public virtual Order Order { get; set; } = null!;
}
