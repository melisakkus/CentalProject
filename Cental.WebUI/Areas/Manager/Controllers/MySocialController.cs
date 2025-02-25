﻿using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.UserSocialDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles ="Manager")]
    public class MySocialController(IUserSocialService _userSocialService, IMapper _mapper, UserManager<AppUser> _userManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _userSocialService.TGetSocialsByUserId(user.Id);
            return View(values);
        }

        public IActionResult CreateSocial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocial(CreateUserSocialDto model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var newSocial = _mapper.Map<UserSocial>(model);
            newSocial.UserId = user.Id;
            _userSocialService.TCreate(newSocial);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateSocial(int id)
        {
            var socialmedia = _userSocialService.TGetById(id);
            var dto = _mapper.Map<UpdateUserSocialDto>(socialmedia);
            return View(dto);
        }

        [HttpPost]
        public IActionResult UpdateSocial(UpdateUserSocialDto model)
        {
            var newSocial = _mapper.Map<UserSocial>(model);
            _userSocialService.TUpdate(newSocial);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSocial(int id)
        {
            _userSocialService.TDelete(id);
            return RedirectToAction("Index");
        }
    }
}
