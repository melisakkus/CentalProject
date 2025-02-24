﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class UserLayoutController : Controller
    {
        public IActionResult Layout()
        {
            return View();
        }
    }
}
