using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities;

public partial class Event
{
    /// <summary>
    /// 活動ID
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 組織ID
    /// </summary>
    public int OrganizationId { get; set; }

    /// <summary>
    /// 活動名稱
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 開始時間
    /// </summary>
    public DateTime StartTime { get; set; }

    /// <summary>
    /// 結束時間
    /// </summary>
    public DateTime? EndTime { get; set; }

    /// <summary>
    /// 0線上1實體
    /// </summary>
    public byte Type { get; set; }

    /// <summary>
    /// 活動地點
    /// </summary>
    public string LocationName { get; set; }

    /// <summary>
    /// 活動地址
    /// </summary>
    public string LocationAddress { get; set; }

    /// <summary>
    /// 經度
    /// </summary>
    public string Longitude { get; set; }

    /// <summary>
    /// 緯度
    /// </summary>
    public string Latitude { get; set; }

    /// <summary>
    /// 串流平台
    /// </summary>
    public string StreamingPlatform { get; set; }

    /// <summary>
    /// 串流網址
    /// </summary>
    public string StreamingUrl { get; set; }

    /// <summary>
    /// 可容納人數
    /// </summary>
    public int? Capacity { get; set; }

    /// <summary>
    /// 聯絡人欄位JSON
    /// </summary>
    public string ContactPerson { get; set; }

    /// <summary>
    /// 報名人欄位JSON
    /// </summary>
    public string ParticipantPeople { get; set; }

    /// <summary>
    /// 活動主圖
    /// </summary>
    public string EventImage { get; set; }

    /// <summary>
    /// 活動簡介
    /// </summary>
    public string Introduction { get; set; }

    /// <summary>
    /// 活動描述HTML
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 主辦單位
    /// </summary>
    public string MainOrganizer { get; set; }

    /// <summary>
    /// 協辦單位
    /// </summary>
    public string CoOrganizer { get; set; }

    /// <summary>
    /// 是否公開活動
    /// </summary>
    public bool IsPrivateEvent { get; set; }

    /// <summary>
    /// 是否免費
    /// </summary>
    public bool IsFree { get; set; }

    /// <summary>
    /// 0未發佈1已發佈
    /// </summary>
    public byte Status { get; set; }

    /// <summary>
    /// 預設值50
    /// </summary>
    public int? Sort { get; set; }

    /// <summary>
    /// 資料封存或強制下架
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

    public virtual ICollection<EventAndTagMapping> EventAndTagMappings { get; set; } = new List<EventAndTagMapping>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Organization Organization { get; set; }

    public virtual ICollection<TicketType> TicketTypes { get; set; } = new List<TicketType>();
}
