using AutoMapper;
using ClaimsAndCompany.Application.DTOs;
using ClaimsAndCompany.Domain.Entities;

namespace ClaimsAndCompany.Application.MappingProfiles
{
    public class ClaimProfile : Profile
    {
        public ClaimProfile()
        {
            CreateMap<ClaimEntity, ClaimDTO>()
                .ForMember(dest => dest.ClaimAgeInDays,
                            opt => opt.MapFrom(src => (DateTime.Now - src.ClaimDate).Days));

            CreateMap<ClaimDTO, ClaimEntity>();
        }
    }
}
