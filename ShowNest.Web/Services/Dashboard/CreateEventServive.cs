using System.Diagnostics;
using Azure.Core;

//namespace ShowNest.Web.Services.Dashboard
//{
//    public class CreateEventServive : IEventService
//    {
//        private readonly DbContext _dbContext;

//        public CreateEventServive(DbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public IEnumerable<Activity> GetEventsByOrganizationId(int organizationId)
//        {
//            //用組織ID去列出活動名稱
//            //get使用者選擇的項目，傳到下一個action


                //var selectedActivityId = Request.Form["ActivityId"];
                //var activity = _context.Activities.Find(selectedActivityId);
                // 使用 activity 變數進行後續操作



//            return _dbContext.Activities
//                .Where(x => x.OrganizationId == organizationId)
//                .ToList();
//        }

//    }
//}
