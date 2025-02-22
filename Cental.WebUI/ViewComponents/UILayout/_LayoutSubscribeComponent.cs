using AutoMapper;
using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.UILayout
{
    public class _LayoutSubscribeComponent() : ViewComponent
    {
        public IViewComponentResult Invoke(UserRegisterDto model)
        {
            return View(model ?? new UserRegisterDto());
        }

    }
}
