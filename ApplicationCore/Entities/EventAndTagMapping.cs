using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities;

/// <summary>
/// 活動與類別對照
/// </summary>
public partial class EventAndTagMapping
{
    /// <summary>
    /// 活動與類別對照ID
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 類別TagID
    /// </summary>
    public int CategoryTagId { get; set; }

    /// <summary>
    /// 活動ID
    /// </summary>
    public int EventId { get; set; }

    public virtual CategoryTag CategoryTag { get; set; } = null!;

    public virtual Event Event { get; set; } = null!;
}
