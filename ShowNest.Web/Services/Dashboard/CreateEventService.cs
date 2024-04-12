﻿using ShowNest.Web.ViewModels.Dashboard;

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
            // 根據 userID 找到它底下所有組織
            var organizations = _eventRepository.GetOrgsByOwnerId(OwnerId).ToList();

            // userID 所有組織 OrgId, OrgName組成VM
            var result = new CreateEventViewModel
            {
                OrgNames = new List<OrgNameList>()
            };


            if (result.OrgNames == null)
            {
                throw new NullReferenceException("OrgNames 屬性為空");
            }

            foreach (var org in organizations)
            {
                var newOrgNameList = new OrgNameList()
                {
                    OrgId = org.Id,
                    OrgName = org.Name,
                };

                result.OrgNames.Add(newOrgNameList);
            }

            return result;
        }

        //public CreateEventViewModel GetOrganizationAndEventDetails(int ownerId)
        //{

        //    var organizations = _eventRepository.GetOrgsByOwnerId(ownerId).ToList();

        //    var result = new CreateEventViewModel
        //    {
        //        OrgNames = new List<OrgNameList>()
        //    };

        //    foreach (var org in organizations)
        //    {
        //        var newOrgNameList = new OrgNameList()
        //        {
        //            OrgId = org.Id,
        //            OrgName = org.Name,
        //            EventNames = new List<EventNameList>()
        //        };

        //        var events = _eventRepository.GetEventsByOrgId(org.Id).ToList();
        //        foreach (var eventItem in events)
        //        {
        //            newOrgNameList.EventNames.Add(new EventNameList
        //            {
        //                EventId = eventItem.Id,
        //                EventName = eventItem.Name 
        //            });
        //        }

        //        result.OrgNames.Add(newOrgNameList);
        //    }

        //    return result;
        //}


    }
}
