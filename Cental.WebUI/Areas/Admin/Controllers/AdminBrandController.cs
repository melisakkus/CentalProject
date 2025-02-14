﻿using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BrandDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AdminBrandController(IBrandService _brandService,IMapper _mapper) : Controller
    {
        public IActionResult Index(int page = 1, int pageSize = 3)
        {
            var brands= _brandService.TGetAll();
            var brandDtos = _mapper.Map<List<ResultBrandDto>>(brands);
            var queryableBrands = brandDtos.AsQueryable();
            var values = new PagedList<ResultBrandDto>(queryableBrands, page, pageSize);
            return View(values);
        }

        public IActionResult DeleteBrand(int id)
        {
            _brandService.TDelete(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateBrand()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBrand(CreateBrandDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var newBrand = _mapper.Map<Brand>(model);
            _brandService.TCreate(newBrand);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateBrand(int id)
        {
            var brand = _brandService.TGetById(id);
            var model = _mapper.Map<UpdateBrandDto>(brand);
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateBrand(UpdateBrandDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var updatedBrand = _mapper.Map<Brand>(model);
            _brandService.TUpdate(updatedBrand);
            return RedirectToAction("Index");
        }
    }
}
