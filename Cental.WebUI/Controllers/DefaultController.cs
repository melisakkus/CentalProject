using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController(IBookingService _bookingService,UserManager<AppUser> _userManager) : Controller
    {

        public IActionResult Index() 
        {
            ViewBag.IsUserAuthenticated = User.Identity.IsAuthenticated;
            return View();
        }

        [HttpPost] //anasayfada kullanıcının oluşturduğu rezervasyon talebi
        public async Task<IActionResult> BookingCarAsync(Booking model)
        {
            if (string.IsNullOrEmpty(User.Identity.Name))
            {
                ModelState.AddModelError(" ", "Lütfen rezervasyon işlemi için giriş yapınız.");
                return RedirectToAction("Index");
            }
            model.Status = "Beklemede";
            model.IsApproved = null;
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            model.UserId = user.Id;
            _bookingService.TCreate(model);
            return RedirectToAction("Index");
        }
    }
}
