﻿using Microsoft.AspNetCore.Mvc;

namespace ShowNest.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult UserEdit()
        {
            return View();
        }
        public IActionResult Prefills()
        {
            return View();
        }
        public IActionResult ChangePassword()
        {
            return View();
        }
        public IActionResult Identities()
        {
            return View();
        }
        public IActionResult Orders()
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
        public IActionResult MyTicketList()
        {
            return View();
        }
        
        public IActionResult LogIn()
        {
            return View();
        }
    }
}
