using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.CarDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AdminCarController(ICarService _carService, IMapper _mapper) : Controller
    {
        public IActionResult Index()
        {
            var cars = _carService.TGetAll();
            var values = _mapper.Map<List<ResultCarDto>>(cars);
            return View(values);
        }
    }
}
