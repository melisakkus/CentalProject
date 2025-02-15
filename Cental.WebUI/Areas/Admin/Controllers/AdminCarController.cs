using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.CarDtos;
using Cental.DtoLayer.Enums;
using Cental.EntityLayer.Entities;
using Cental.WebUI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminCarController(ICarService _carService,IBrandService _brandService, IMapper _mapper) : Controller
    {
        public IActionResult Index()
        {
            var cars = _carService.TGetAll();
            var values = _mapper.Map<List<ResultCarDto>>(cars);
            return View(values);
        }

        public IActionResult DeleteCar(int id)
        {
            _carService.TDelete(id);
            return RedirectToAction("Index");
        }

        private void GetValuesinDropdown()
        {
            ViewBag.gasTypes = GetEnumValues.GetEnums<GasTypes>();
            ViewBag.gearTypes = GetEnumValues.GetEnums<GearTypes>();
            ViewBag.transmissions = GetEnumValues.GetEnums<Transmissions>();
            ViewBag.brands = (from x in _brandService.TGetAll()
                              select new SelectListItem
                              {
                                  Text = x.BrandName,
                                  Value = x.BrandId.ToString()
                              }).ToList();
        }

        public IActionResult CreateCar()
        {
            GetValuesinDropdown();
            return View();
        }
        [HttpPost]
        public IActionResult CreateCar(CreateCarDto model)
        {
            var car = _mapper.Map<Car>(model);
            _carService.TCreate(car);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateCar(int id)
        {
            GetValuesinDropdown();
            var car = _carService.TGetById(id);
            var dto = _mapper.Map<UpdateCarDto>(car);
            return View(dto);
        }
        [HttpPost]
        public IActionResult UpdateCar(UpdateCarDto model)
        {
            var car = _mapper.Map<Car>(model);
            _carService.TUpdate(car);
            return RedirectToAction("Index");
        }
    }
}
