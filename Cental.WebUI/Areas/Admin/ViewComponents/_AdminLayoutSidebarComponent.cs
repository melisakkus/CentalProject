using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Admin.ViewComponents
{
    public class _AdminLayoutSidebarComponent(UserManager<AppUser> _userManager) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userImage = user.ImageUrl;
            ViewBag.nameSurname = user.FirstName + " " + user.LastName;
            return View();
        }
    }
}
