using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BannerDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminBannerController(IBannerService _bannerService, IMapper _mapper) : Controller
    {
        //primary constructor veya
        //private readonly IBannerService _bannerService;
        //private readonly IMapper _mapper;

        //public AdminBannerController(IBannerService bannerService, IMapper mapper)
        //{
        //    _bannerService = bannerService;
        //    _mapper = mapper;
        //}

        public IActionResult Index()
        {
            var values = _bannerService.TGetAll();
            var banners = _mapper.Map<List<ResultBannerDto>>(values);
            return View(/*banners*/);
        }
    }
}
