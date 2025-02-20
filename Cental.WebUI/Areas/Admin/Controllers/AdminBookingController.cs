using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminBookingController(IBookingService _bookingService) : Controller
    {
        public IActionResult Index()
        {
            var bookings = _bookingService.TGetAll();
            return View(bookings);
        }
    }
}
