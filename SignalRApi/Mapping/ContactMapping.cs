using AutoMapper;
using SignalR.DtoLayer.CategoryDto;

namespace SignalRApi.Mapping
{
    public class ContactMapping:Profile
    {
        public ContactMapping()
        {
            CreateMap<ContactMapping,ResultCategoryDto>().ReverseMap();
            CreateMap<ContactMapping, UpdateCategoryDto>().ReverseMap();
            CreateMap<ContactMapping, CreateCategoryDto>().ReverseMap();
            CreateMap<ContactMapping, GetCategoryDto>().ReverseMap();
        }
    }
}
