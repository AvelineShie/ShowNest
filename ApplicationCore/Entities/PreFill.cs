using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities;

/// <summary>
/// 報名預填資料
/// </summary>
public partial class PreFill
{
    /// <summary>
    /// 預填資料ID
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 使用者ID
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// 姓名
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 手機號碼
    /// </summary>
    public string Mobile { get; set; }

    /// <summary>
    /// 郵遞區號
    /// </summary>
    public int? PostalCode { get; set; }

    /// <summary>
    /// 縣市
    /// </summary>
    public string County { get; set; }

    /// <summary>
    /// 鄉鎮區域
    /// </summary>
    public string District { get; set; }

    /// <summary>
    /// 聯絡地址
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// 公司名稱
    /// </summary>
    public string CompanyName { get; set; }

    /// <summary>
    /// 職稱
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// 公司郵遞區號
    /// </summary>
    public int? CompanyPostalCode { get; set; }

    /// <summary>
    /// 公司地址
    /// </summary>
    public string CompanyAddress { get; set; }

    /// <summary>
    /// 新增時間
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// 修改時間
    /// </summary>
    public DateTime? EditedAt { get; set; }

    public virtual User User { get; set; }
}
