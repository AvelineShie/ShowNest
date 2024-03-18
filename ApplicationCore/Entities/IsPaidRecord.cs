using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities;

/// <summary>
/// 付款紀錄
/// </summary>
public partial class IsPaidRecord
{
    /// <summary>
    /// 付款紀錄ID
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 付款結果
    /// </summary>
    public bool? Result { get; set; }

    /// <summary>
    /// 訂單ID
    /// </summary>
    public int OrderId { get; set; }
}
