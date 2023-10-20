using AutoMapper;
using Drivers.BLL.DTOs.Requests;
using Drivers.BLL.DTOs.Responses;
using Drivers.DAL_EF.Entities;

namespace Drivers.Api.AutomapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<EFDriver, FullDriverResponceDTO>()
                .ForMember(dest => dest.CompanyDTO, opt => opt.MapFrom(src => src.Company));      
            CreateMap<FullDriverResponceDTO, EFDriver>();

            CreateMap<EFDriver, ShortDriverResponceDTO>();
            CreateMap<ShortDriverResponceDTO, EFDriver>();


            CreateMap<EFCompany, CompanyResponceDTO>().ReverseMap ();
            CreateMap<EFDriver, MiniDriverReqDTO>().ReverseMap();
        }
    }
}
