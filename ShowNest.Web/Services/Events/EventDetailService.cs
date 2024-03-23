using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using ShowNest.Web.ViewModels.Organization;

namespace ShowNest.Web.Services.Events
{
    public class EventDetailService
    {
        public List<EventDetail> AllEvents { get; }

        public EventDetailService()
        {
            AllEvents = new List<EventDetail>
            {
                new EventDetail
                {
                    Id=1,
                    EventImage="https://picsum.photos/200/200/?random=9",
                    EventName="測試活動",
                    StartTime=DateTime.Now,
                    EndTime=DateTime.Now,
                    EventIntroduction="活動簡介活動簡介活動簡介活動簡介活動簡介"
                },
                new EventDetail
                {
                    Id = 2,
                    EventImage = "https://picsum.photos/200/200/?random=7",
                    EventName = "絢彩音樂祭",
                    StartTime = DateTime.Now.AddMonths(1).AddDays(5).AddHours(18), 
                    EndTime = DateTime.Now.AddMonths(1).AddDays(5).AddHours(22),
                    EventIntroduction = "絢彩音樂祭將會帶來一場震撼人心的演唱會，匯聚了多位知名音樂人，讓您沉浸在音樂的海洋中。" 
                },
                new EventDetail
                {
                    Id = 3,
                    EventImage = "https://picsum.photos/200/200/?random=8",
                    EventName = "夏日音樂祭",
                    StartTime = DateTime.Now.AddMonths(2).AddDays(10).AddHours(17),
                    EndTime = DateTime.Now.AddMonths(2).AddDays(10).AddHours(21),
                    EventIntroduction = "夏日音樂祭將帶來一場激情四射的演唱會，讓您感受到夏日的熱情與活力。"
                },
                new EventDetail
                {
                    Id = 4,
                    EventImage = "https://picsum.photos/200/200/?random=10",
                    EventName = "星光音樂會",
                    StartTime = DateTime.Now.AddMonths(3).AddDays(20).AddHours(19),
                    EndTime = DateTime.Now.AddMonths(3).AddDays(20).AddHours(23),
                    EventIntroduction = "星光音樂會將邀請眾多明星和您共度一個難忘的夜晚，讓您沉浸在美妙的音樂之中。"
                }

            };
        }

        public (IEnumerable<IGrouping<string, EventDetail>>, IEnumerable<IGrouping<string, EventDetail>>) GetGroupedEvents()
        {
            // 取得正在進行中的活動清單
            var currentEvents = AllEvents
                .Where(e => e.EndTime >= DateTime.Now)
                .OrderByDescending(e => e.StartTime)
                .ToList();

            // 取得曾舉辦的活動清單
            var pastEvents = AllEvents
            .Where(e => e.EndTime < DateTime.Now)
            .OrderByDescending(e => e.StartTime)
            .ToList();

            // 以月份分組
           var groupedPastEvents = pastEvents.GroupBy(e => e.StartTime.ToString("yyyy/MM")).OrderByDescending(g => g.Key);
            var groupedCurrentEvents = currentEvents.GroupBy(e => e.StartTime.ToString("yyyy/MM")).OrderByDescending(g => g.Key);

            return (groupedPastEvents, groupedCurrentEvents);
        }
    }

}
