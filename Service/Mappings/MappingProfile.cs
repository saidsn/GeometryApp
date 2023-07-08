using AutoMapper;
using Domain.Models;
using Service.DTOs.Build;

namespace Service.Mappings
{
    public class MappingProfile : Profile
    {
        protected MappingProfile()
        {
            CreateMap<Build, BuildDto>().ReverseMap();
        }
    }
}
