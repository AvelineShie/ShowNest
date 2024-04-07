using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities;

public partial class SeatArea
{
    /// <summary>
    /// 座位區域ID
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 座位區域名稱
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 新增時間
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// 修改時間
    /// </summary>
    public DateTime? EditedAt { get; set; }

    /// <summary>
    /// 標記封存
    /// </summary>
    public bool IsDeleted { get; set; }

    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();

    public virtual ICollection<TicketTypeAndSeatAreaMapping> TicketTypeAndSeatAreaMappings { get; set; } = new List<TicketTypeAndSeatAreaMapping>();
}
