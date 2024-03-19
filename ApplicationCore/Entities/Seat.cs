using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities;

public partial class Seat
{
    /// <summary>
    /// 座位ID
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 座位區域ID
    /// </summary>
    public int SeatAreaId { get; set; }

    /// <summary>
    /// 座位號碼ex3排13號
    /// </summary>
    public string Number { get; set; } = null!;

    /// <summary>
    /// 0可選1已選2不可選
    /// </summary>
    public byte Status { get; set; }

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

    public virtual SeatArea SeatArea { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
