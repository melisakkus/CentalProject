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

        [HttpGet]
        public IActionResult BookingCar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BookingCar(Booking model)
        {
            if(model.IsApproved == true)
            {
                model.Status = "Onaylandı";
            }
            else
            {
                model.Status = "Beklemede";
            }
            _bookingService.TCreate(model);
            return RedirectToAction("Index");
        }
    }
}
