using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities;

/// <summary>
/// 偏好地區列表
/// </summary>
public partial class Area
{
    /// <summary>
    /// 區域ID
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 地區名稱
    /// </summary>
    public string Name { get; set; } = null!;

    public virtual ICollection<PreferredActivityArea> PreferredActivityAreas { get; set; } = new List<PreferredActivityArea>();
}
