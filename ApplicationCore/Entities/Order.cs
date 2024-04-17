using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities;

/// <summary>
/// 訂單
/// </summary>
public partial class Order
{
    /// <summary>
    /// 訂單ID
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 使用者ID
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// 0免費1信用卡
    /// </summary>
    public byte PaymentType { get; set; }

    /// <summary>
    /// 0待付款1成功2付款失敗3取消
    /// </summary>
    public byte Status { get; set; }

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

    /// <summary>
    /// 聯絡人資料JSON
    /// </summary>
    public string ContactPerson { get; set; }

    /// <summary>
    /// 報名人資料JSON
    /// </summary>
    public string ParticipantPeople { get; set; }

    /// <summary>
    /// 0不顯示參加活動1顯示
    /// </summary>
    public bool IsDisplayed { get; set; }

    public string EcpayTradeNo { get; set; }

    public int EventId { get; set; }

    public virtual ArchiveOrder ArchiveOrder { get; set; }

    public virtual ICollection<EcpayOrder> EcpayOrders { get; set; } = new List<EcpayOrder>();

    public virtual Event Event { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual User User { get; set; }
}
