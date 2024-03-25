using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities;

public partial class CategoryTag
{
    /// <summary>
    /// 類別TagID
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 類別Tag名稱
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// 排序預設50
    /// </summary>
    public int? Sort { get; set; }

    /// <summary>
    /// 標記刪除
    /// </summary>
    public int? IsDeleted { get; set; }

    /// <summary>
    /// 新增時間
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// 修改時間
    /// </summary>
    public DateTime? EditeAt { get; set; }

    public virtual ICollection<EventAndTagMapping> EventAndTagMappings { get; set; } = new List<EventAndTagMapping>();
}
