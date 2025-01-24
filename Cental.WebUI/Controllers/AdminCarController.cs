﻿using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.CarDtos;
using Cental.DtoLayer.Enums;
using Cental.EntityLayer.Entities;
using Cental.WebUI.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.Controllers
{
    public class AdminCarController(ICarService _carService,IMapper _mapper, IBrandService _brandService) : Controller
    {
        public IActionResult Index()
        {
            //var values = _carService.TGetCarsWithBrands();
            var values = _carService.TGetAll();
            return View(values);
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
            GetValuesinDropdown();
            var newCar = _mapper.Map<Car>(model);
            _carService.TCreate(newCar);
            return RedirectToAction("Index");
        }
    }
}
