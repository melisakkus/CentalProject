﻿using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Cental.WebUI.Controllers
{
    public class AdminProfileController(UserManager<AppUser> _userManager,IImageService _imageService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var profileEditDto = user.Adapt<ProfileEditDto>();
            return View(profileEditDto);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ProfileEditDto model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var succeed = await _userManager.CheckPasswordAsync(user, model.CurrentPassword);
            if (succeed)
            {
                if(model.ImageFile != null)
                {
                    model.ImageUrl = await _imageService.SaveImageAsync(model.ImageFile);
                }

                var updateUser = model.Adapt<AppUser>();
                var result = await _userManager.UpdateAsync(updateUser);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "AdminAbout");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View();
            }
            ModelState.AddModelError(string.Empty, "Girdiğiniz şifre hatalı, güncelleme yapılamadı");
            return View(model);
        }

    }
}
