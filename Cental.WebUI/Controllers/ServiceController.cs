using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ServiceDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]

    public class ServiceController(IServiceService _serviceService, IMapper _mapper) : Controller
    {
        public IActionResult Index()
        {
            var services = _serviceService.TGetAll();
            var servicesDtos = _mapper.Map<List<ResultServiceDto>>(services);
            return View(servicesDtos);
        }
    }
}
