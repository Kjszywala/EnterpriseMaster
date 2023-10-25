﻿using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMaster.Controllers
{
    public class RegisterController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register()
        {

            return RedirectToAction("Index", "Home");
        }
    }
}
