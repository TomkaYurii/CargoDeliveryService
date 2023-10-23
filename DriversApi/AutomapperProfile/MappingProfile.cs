using AutoMapper;
using Drivers.BLL.DTOs.Requests;
using Drivers.BLL.DTOs.Responses;
using Drivers.DAL_EF.Entities;

namespace Drivers.Api.AutomapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            /////////////////////////////////////////////////////////////////////
            ///   Responces
            /////////////////////////////////////////////////////////////////////
            CreateMap<EFDriver, FullDriverResponceDTO>()
                .ForMember(dest => dest.CompanyDTO, opt => opt.MapFrom(src => src.Company));      
            CreateMap<FullDriverResponceDTO, EFDriver>();

            CreateMap<EFDriver, ShortDriverResponceDTO>().ReverseMap();
            CreateMap<EFCompany, CompanyResponceDTO>().ReverseMap ();

            /////////////////////////////////////////////////////////////////////
            ///   Requests
            /////////////////////////////////////////////////////////////////////
            CreateMap<EFDriver, MiniDriverReqDTO>().ReverseMap();
        }
    }
}
