using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities;

public partial class HistoryPassword
{
    public int Id { get; set; }

    /// <summary>
    /// 使用者ID
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// 使用過的密碼
    /// </summary>
    public string UsedPassword { get; set; }

    /// <summary>
    /// 新增時間
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// 修改時間
    /// </summary>
    public DateTime? EditedAt { get; set; }

    public virtual User User { get; set; }
}
