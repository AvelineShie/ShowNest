﻿using Microsoft.AspNetCore.Mvc;
using ShowNest.Web.Services.Events;
using ShowNest.Web.Services.Organization;
using ShowNest.Web.ViewModels.Organization;

namespace ShowNest.Web.Controllers
{
    public class OrganizationsController : Controller
    {
        private readonly OrganizationIndexService _organizationService;
        private readonly EventDetailService _eventDetailService;

        public OrganizationsController(OrganizationIndexService organizationService)
        {
            _organizationService = organizationService;
        }

        public IActionResult Index(int organizationId)
        {
            var organizationData = _organizationService.GetOrganizationDetails(organizationId);

            if (organizationData == null)
            {
                return NotFound();
            }

            return View(organizationData);
        }
        public IActionResult ContactOrganization()
        {
            return View();
        }
        public IActionResult CreateOrganization()
        {
            return View();
        }

    }
}
