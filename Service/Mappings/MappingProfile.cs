using AutoMapper;
using Repository;
using Service.DTOs.Build;

namespace service.mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Build, BuildDto>().ReverseMap();
            CreateMap<Build, BuildListDto>().ReverseMap();
            CreateMap<Build, BuildCreateDto>().ReverseMap();
            CreateMap<Build, BuildUpdateDto>().ReverseMap();
        }
    }
}
