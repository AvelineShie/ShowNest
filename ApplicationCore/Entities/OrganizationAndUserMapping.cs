using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities;

/// <summary>
/// 組織與使用者對照
/// </summary>
public partial class OrganizationAndUserMapping
{
    /// <summary>
    /// 組織與使用者對照ID
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

    public virtual Organization Organization { get; set; }

    public virtual User User { get; set; }
}
