﻿using Microsoft.AspNetCore.Mvc;

namespace ShowNest.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Identities()
        {
            return View();
        }
        public IActionResult Prefills()
        {
            return View();
        }
        public IActionResult JoinedOrganizations()
        {
            return View();
        }
        public IActionResult ReclaimOrders()
        {
            return View();
        }
        public IActionResult ChangePassword()
        {
            return View();
        }

    }
}
