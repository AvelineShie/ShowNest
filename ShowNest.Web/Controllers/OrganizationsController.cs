﻿using Jil;
using Microsoft.AspNetCore.Mvc;
using ShowNest.Web.Services.Events;
using ShowNest.Web.Services.Organization;
using ShowNest.Web.ViewModels.Organization;
using System.Text.Json;

namespace ShowNest.Web.Controllers
{
    public class OrganizationsController : Controller
    {
        private readonly OrganizationIndexService _organizationService;
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationsController(OrganizationIndexService organizationService, IOrganizationRepository organizationRepository)
        {
            _organizationService = organizationService;
            _organizationRepository = organizationRepository;
        }
        

        public IActionResult Index(int organizationId)
        {
            var organizationData = _organizationService.GetOrganizationDetails(organizationId);
            

            return View(organizationData);
        }


        public IActionResult ContactOrganization(int organizationId)
        {
            var ContactOrganizationDate= _organizationService.GetOrganizationDetails(organizationId);

            return View(ContactOrganizationDate);
        }

        public IActionResult CreateOrganization()
        {
            return View();
        }

        public IActionResult EditOrganization(string id)
        {
            return View("CreateOrganization");
        }
    }
}
