using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities;

/// <summary>
/// 組織粉絲
/// </summary>
public partial class OrgFan
{
    /// <summary>
    /// 入坑ID
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 組織ID
    /// </summary>
    public int OrganizationId { get; set; }

    /// <summary>
    /// 使用者ID
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// 成為粉絲時間
    /// </summary>
    public DateTime FanTime { get; set; }

    public virtual Organization Organization { get; set; }

    public virtual User User { get; set; }
}
