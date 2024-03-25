using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities;

/// <summary>
/// 組織
/// </summary>
public partial class Organization
{
    /// <summary>
    /// 組織ID
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 擁有者UserId
    /// </summary>
    public int OwnerId { get; set; }

    /// <summary>
    /// 組織名稱
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// 站內連結
    /// </summary>
    public string OrganizationUrl { get; set; } = null!;

    /// <summary>
    /// 站外連結
    /// </summary>
    public string? OuterUrl { get; set; }

    /// <summary>
    /// 組織簡介
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// FB連結
    /// </summary>
    public string? Fblink { get; set; }

    /// <summary>
    /// IG連結
    /// </summary>
    public string? Igaccount { get; set; }

    /// <summary>
    /// Email
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// 組織形象圖
    /// </summary>
    public string? ImgUrl { get; set; }

    /// <summary>
    /// 聯絡人姓名
    /// </summary>
    public string ContactName { get; set; } = null!;

    /// <summary>
    /// 聯絡手機
    /// </summary>
    public string ContactMobile { get; set; } = null!;

    /// <summary>
    /// 連絡電話
    /// </summary>
    public string ContactTelephone { get; set; } = null!;

    /// <summary>
    /// 標記封存
    /// </summary>
    public bool? IsDeleted { get; set; }

    /// <summary>
    /// 新增時間
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// 修改時間
    /// </summary>
    public DateTime? EditedAt { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<OrgFan> OrgFans { get; set; } = new List<OrgFan>();

    public virtual ICollection<OrganizationAndUserMapping> OrganizationAndUserMappings { get; set; } = new List<OrganizationAndUserMapping>();

    public virtual User Owner { get; set; } = null!;
}
