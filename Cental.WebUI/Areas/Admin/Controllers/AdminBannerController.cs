using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BannerDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AdminBannerController : Controller
    {
        private readonly IBannerService _bannerService;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public AdminBannerController(IBannerService bannerService, IMapper mapper, IImageService imageService)
        {
            _bannerService = bannerService;
            _mapper = mapper;
            _imageService = imageService;
        }

        public IActionResult Index()
        {
            var values = _bannerService.TGetAll();
            var banners = _mapper.Map<List<ResultBannerDto>>(values);
            return View(banners);
        }

        public IActionResult CreateBanner()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDto model)
        {
            var banner = _mapper.Map<Banner>(model);
            if(model.ImageFile != null)
            {
                var imageUrl = await _imageService.SaveImageAsync(model.ImageFile);
                banner.ImageUrl = imageUrl;
            }
            _bannerService.TCreate(banner);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteBanner(int id)
        {
            _bannerService.TDelete(id);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateBanner(int id)
        {
            var value = _bannerService.TGetById(id);
            var banner = _mapper.Map<UpdateBannerDto>(value);
            return View(banner);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto model)
        {
            var updatedBanner = _mapper.Map<Banner>(model);
            if (model.ImageFile != null)
            {
                var imageUrl = await _imageService.SaveImageAsync(model.ImageFile);
                updatedBanner.ImageUrl = imageUrl;
            }
            _bannerService.TUpdate(updatedBanner);
            return RedirectToAction("Index");
        }
    }
}
