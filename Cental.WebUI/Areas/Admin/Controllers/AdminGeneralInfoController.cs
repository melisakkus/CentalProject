using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class AdminGeneralInfoController(IGeneralInfoService _generalInfoService) : Controller
    {
        public IActionResult Index()
        {
            var values = _generalInfoService.TGetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateInfo() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateInfo(GeneralInfo model)
        {
            _generalInfoService.TCreate(model);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteInfo(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpdateInfo(int id)
        {
            var value = _generalInfoService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateInfo(GeneralInfo model)
        {
            _generalInfoService.TUpdate(model);
            return RedirectToAction("Index");
        }
    }
}
