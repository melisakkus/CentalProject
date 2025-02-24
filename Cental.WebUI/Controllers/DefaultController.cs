using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController(IBookingService _bookingService) : Controller
    {
        public IActionResult Index() 
        {
            return View();
        }

        [HttpPost] //anasayfada kullanıcının oluşturduğu rezervasyon talebi
        public IActionResult BookingCar(Booking model)
        {
            model.Status = "Beklemede";
            model.IsApproved = null;
            _bookingService.TCreate(model);
            return RedirectToAction("Index");
        }
    }
}
