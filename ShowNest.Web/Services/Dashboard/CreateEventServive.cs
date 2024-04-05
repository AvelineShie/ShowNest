using System.Diagnostics;
using System.Security.Cryptography;
using ApplicationCore.Entities;
using Azure.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp;
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

        //1. 撈擁有人底下的所有OrgId, OrgName組成VM
        //public CreateEventViewModel GetOrgByOwner(int OwnerId)
        //{
        //    var orgNames = _eventRepository.GetOrgIdByOwnerId(OwnerId);
        //    var evetNames = _eventRepository.GetEventIdByOrgId(OrgId);

        //    foreach (OrgName in orgNames)
        //    {
        //        var result = new CreateEventViewModel
        //        {
        //            OrgNames =
        //        }
        //    }
        //}

        //2.撈組織下面所有活動，組成VM
        //public IEnumerable<Event> GetEventIdByOrgId(int orgId)
        //{

        //}

    }
}
