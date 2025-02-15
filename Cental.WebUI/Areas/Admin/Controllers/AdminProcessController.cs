using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ProcessDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminProcessController(IProcessService _processService, IMapper _mapper) : Controller
    {
        public IActionResult Index()
        {
            var processes = _processService.TGetAll();
            var processDtos = _mapper.Map<List<ResultProcessDto>>(processes);
            return View(processDtos);
        }

        public IActionResult DeleteProcess(int id)
        {
            _processService.TDelete(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateProcess()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProcess(CreateProcessDto model)
        {
            var process = _mapper.Map<Process>(model);
            _processService.TCreate(process);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateProcess(int id)
        {
            var process = _processService.TGetById(id);
            var dto = _mapper.Map<UpdateProcessDto>(process);
            return View(dto);
        }
        [HttpPost]
        public IActionResult UpdateProcess(UpdateProcessDto model)
        {
            var process = _mapper.Map<Process>(model);
            _processService.TUpdate(process);
            return RedirectToAction("Index");
        }
    }
}
