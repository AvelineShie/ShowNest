using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities;

public partial class Ticket
{
    /// <summary>
    /// 票券ID
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 訂單ID
    /// </summary>
    public int? OrderId { get; set; }

    /// <summary>
    /// 票種ID
    /// </summary>
    public int TicketTypeId { get; set; }

    /// <summary>
    /// 座位ID
    /// </summary>
    public int? SeatId { get; set; }

    /// <summary>
    /// 票號
    /// </summary>
    public string Number { get; set; }

    /// <summary>
    /// 0未驗票1驗票成功
    /// </summary>
    public byte Status { get; set; }

    /// <summary>
    /// 作廢票券
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
    /// 檢查碼
    /// </summary>
    public int? CheckCode { get; set; }

    public virtual Order Order { get; set; }

    public virtual Seat Seat { get; set; }

    public virtual TicketType TicketType { get; set; }
}
