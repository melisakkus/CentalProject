using AutoMapper;
using Cental.DtoLayer.MessageDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class MessageMapping : Profile
    {
        public MessageMapping()
        {
            CreateMap<Message, ResultMessageDto>().ReverseMap();
            CreateMap<Message, DetailMessageDto>().ReverseMap();
            CreateMap<Message, CreateMessageDto>().ReverseMap();
        }
    }
}
