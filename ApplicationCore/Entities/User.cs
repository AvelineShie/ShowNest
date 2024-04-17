using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities;

public partial class User
{
    /// <summary>
    /// 使用者ID
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 暱稱
    /// </summary>
    public string Nickname { get; set; }

    /// <summary>
    /// 手機號碼
    /// </summary>
    public string Mobile { get; set; }

    /// <summary>
    /// 生日
    /// </summary>
    public DateTime Birthday { get; set; }

    /// <summary>
    /// 性別
    /// </summary>
    public byte? Gender { get; set; }

    /// <summary>
    /// 個人網址
    /// </summary>
    public string PersonalUrl { get; set; }

    /// <summary>
    /// 個人簡介
    /// </summary>
    public string PersonalProfile { get; set; }

    /// <summary>
    /// 訂閱電子報
    /// </summary>
    public bool EdmSubscription { get; set; }

    /// <summary>
    /// 帳號照片
    /// </summary>
    public string Image { get; set; }

    /// <summary>
    /// 上次登入時間
    /// </summary>
    public DateTime? LastLogInAt { get; set; }

    /// <summary>
    /// 0未驗證EMAIL1已驗證EMAIL
    /// </summary>
    public byte Status { get; set; }

    /// <summary>
    /// 新增時間
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// 修改時間
    /// </summary>
    public DateTime? EditedAt { get; set; }

    public virtual ICollection<HistoryPassword> HistoryPasswords { get; set; } = new List<HistoryPassword>();

    public virtual LogInInfo LogInInfo { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<OrgFan> OrgFans { get; set; } = new List<OrgFan>();

    public virtual ICollection<OrganizationAndUserMapping> OrganizationAndUserMappings { get; set; } = new List<OrganizationAndUserMapping>();

    public virtual ICollection<Organization> Organizations { get; set; } = new List<Organization>();

    public virtual ICollection<PreFill> PreFills { get; set; } = new List<PreFill>();

    public virtual ICollection<PreferredActivityArea> PreferredActivityAreas { get; set; } = new List<PreferredActivityArea>();
}
