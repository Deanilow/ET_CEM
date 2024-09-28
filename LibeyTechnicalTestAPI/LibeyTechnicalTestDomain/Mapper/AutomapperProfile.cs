using AutoMapper;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestDomain.Mapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<UserUpdateorCreateCommand, LibeyUser>().ReverseMap(); 
            CreateMap<LibeyUserResponse, LibeyUser>().ReverseMap();
        }
    }
}
