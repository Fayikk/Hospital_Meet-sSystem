using AutoMapper;
using Eksim_Bootcamp.Shared;
using Eksim_Bootcamp.Shared.DTO;

namespace Eksim_Bootcamp.Server.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {

            CreateMap<DoctorDTO,Doctor>().ReverseMap();
            CreateMap<MeetDTO, Meet>().ReverseMap();
        }
    }
}
