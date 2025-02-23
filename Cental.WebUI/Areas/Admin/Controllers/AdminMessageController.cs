using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.MessageDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class AdminMessageController(IMessageService _messageService, IMapper _mapper) : Controller
    {
        public IActionResult Index()
        {
            var messages = _messageService.TGetAll();
            var dtos = _mapper.Map<List<ResultMessageDto>>(messages);
            return View(dtos);
        }

        public IActionResult DeleteMessage(int id)
        {
            _messageService.TDelete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto model)
        {
            var message = _mapper.Map<Message>(model);
            _messageService.TCreate(message);
            return RedirectToAction("Index");
        }

        public IActionResult DetailMessage(int id)
        {
            var value = _messageService.TGetById(id);
            var message = _mapper.Map<DetailMessageDto>(value);
            return View(message);
        }
    }
}
