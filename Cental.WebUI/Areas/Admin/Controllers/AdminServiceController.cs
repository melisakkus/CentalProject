using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ServiceDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AdminServiceController(IServiceService _serviceService, IMapper _mapper) : Controller
    {
        public IActionResult Index()
        {
            var services = _serviceService.TGetAll();
            var dtos = _mapper.Map<List<ResultServiceDto>>(services);   
            return View(dtos);
        }

        public IActionResult DeleteService(int id)
        {
            _serviceService.TDelete(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateService()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateService(CreateServiceDto model)
        {
            var service = _mapper.Map<Service>(model);
            _serviceService.TCreate(service);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateService(int id)
        {
            var values = _serviceService.TGetById(id);
            var service = _mapper.Map<UpdateServiceDto>(values);
            return View(service);
        }
        [HttpPost]
        public IActionResult UpdateService(UpdateServiceDto model)
        {
            var values = _mapper.Map<Service>(model);
            _serviceService.TUpdate(values);
            return RedirectToAction("Index");
        }
    }
}
