using AutoMapper;
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

            CreateMap<CompanyResponceDTO, EFCompany>();
            CreateMap<EFCompany, CompanyResponceDTO> ();
        }
    }
}
