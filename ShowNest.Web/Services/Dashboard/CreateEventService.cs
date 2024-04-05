using ShowNest.Web.ViewModels.Dashboard;

namespace ShowNest.Web.Services.Dashboard
{
    public class CreateEventService
    {
        private readonly IEventRepository _eventRepository;

        public CreateEventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        
        public CreateEventViewModel GetOrgByOwner(int OwnerId)
        {
            var organizations = _eventRepository.GetOrgsByOwnerId(OwnerId);
            //var events = _eventRepository.GetEventsByOrgId(OrgId);

            //1. 撈擁有人底下的所有OrgId, OrgName組成VM
            var result = new OrgNameList
            {
                OrgName = organizations.FirstOrDefault().Name,
            };

            return new CreateEventViewModel { };

            //2.撈組織下面所有活動，組成VM
        }




    }
}
