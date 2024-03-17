using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities;

/// <summary>
/// 使用者偏好活動區域
/// </summary>
public partial class PreferredActivityArea
{
    /// <summary>
    /// 偏好區域ID
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 使用者ID
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// 區域ID
    /// </summary>
    public int AreaId { get; set; }

    public virtual Area Area { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
