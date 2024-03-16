using AutoMapper;
using ClaimsAndCompany.Application.DTOs;

namespace ClaimsAndCompany.Application.Services.Claim
{
    public interface IClaimService
    {
        IReadOnlyCollection<ClaimDTO> GetClaims(int companyId, IMapper mapper);

        ClaimDTO? GetClaim(int companyId, string assuredName, IMapper mapper);

        bool UpdateClaim(ClaimDTO claim, IMapper mapper);
    }
}
