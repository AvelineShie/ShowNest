using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities;

public partial class LogInInfo
{
    /// <summary>
    /// 使用者ID
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// 帳號
    /// </summary>
    public string Account { get; set; }

    /// <summary>
    /// 電子郵件
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// 密碼
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// 新增時間
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// 修改時間
    /// </summary>
    public DateTime? EditedAt { get; set; }

    /// <summary>
    /// GoogleId
    /// </summary>
    public int? Gid { get; set; }

    public virtual User User { get; set; }
}
