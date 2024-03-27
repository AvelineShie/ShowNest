using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
    public string Account { get; set; } = null!;

    /// <summary>
    /// 電子郵件
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// 密碼
    /// </summary>
    public string Password { get; set; } = null!;

    /// <summary>
    /// 新增時間
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// 修改時間
    /// </summary>
    public DateTime? EditedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
