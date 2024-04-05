//using System.Diagnostics;
//using ApplicationCore.Entities;
//using Azure.Core;
//using Microsoft.AspNetCore.Mvc.Rendering;

//namespace ShowNest.Web.Services.Dashboard
//{
//    public class CreateEventServive : IEventService
//    {
//        private readonly DbContext _dbContext;

//        public CreateEventServive(DbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public IEnumerable<Event> GetEventsByOrgId(int orgId)
//        {

//            //找出資料庫當中所有組織名稱，並依據使用者點選，將相同組織名稱的活動,渲染上去
            
//                //var events = DbContext.Events.
//                //    Include(e => e.Organization)
//                //    .Where(e => e.OrganizationId == orgId);

//                //return events;
            
//        }

//    }
//}
