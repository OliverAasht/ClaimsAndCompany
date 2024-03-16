using AutoMapper;
using ClaimsAndCompany.Application.DTOs;
using ClaimsAndCompany.Domain.Entities;

namespace ClaimsAndCompany.Application.MappingProfiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<CompanyEntity, CompanyDTO>()
               .ForMember(dest => dest.Active,
                           opt => opt.MapFrom(src => IsCompanyActive(src.InsuranceEndDate)));
        }

        private bool IsCompanyActive(DateTime insuranceEndDate)
        {
            return insuranceEndDate > DateTime.Now;
        }
    }
}
