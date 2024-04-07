using System;
using System.Collections;
using System.Collections.Generic;

namespace ApplicationCore.Entities;

public partial class TicketType
{
    /// <summary>
    /// 票種ID
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 活動ID
    /// </summary>
    public int EventId { get; set; }

    /// <summary>
    /// 票種名稱
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 開始販售時間
    /// </summary>
    public DateTime StartSaleTime { get; set; }

    /// <summary>
    /// 結束販售時間
    /// </summary>
    public DateTime EndSaleTime { get; set; }

    /// <summary>
    /// 票券數量
    /// </summary>
    public int CapacityAmount { get; set; }

    /// <summary>
    /// 票價
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// 預設值50
    /// </summary>
    public int? Sort { get; set; }

    /// <summary>
    /// 是否顯示
    /// </summary>
    public int? IsDisplayed { get; set; }

    /// <summary>
    /// 強制下架
    /// </summary>
    public int? IsDeleted { get; set; }

    /// <summary>
    /// 新增時間
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// 修改時間
    /// </summary>
    public DateTime? EditedAt { get; set; }

    public virtual Event Event { get; set; }

    public virtual ICollection<TicketTypeAndSeatAreaMapping> TicketTypeAndSeatAreaMappings { get; set; } =
        new List<TicketTypeAndSeatAreaMapping>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}