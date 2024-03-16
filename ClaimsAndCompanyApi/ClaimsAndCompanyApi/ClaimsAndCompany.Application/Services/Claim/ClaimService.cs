using AutoMapper;
using ClaimsAndCompany.Application.DTOs;
using ClaimsAndCompany.Domain.Entities;
using ClaimsAndCompany.Domain.Interfaces.Repositories;

namespace ClaimsAndCompany.Application.Services.Claim
{
    public class ClaimService : IClaimService
    {
        private readonly IClaimsRepository _claimsRepo;

        public ClaimService(IClaimsRepository claimsRepo)
        {
            _claimsRepo = claimsRepo;
        }

        public ClaimDTO? GetClaim(int companyId, string assuredName, IMapper mapper)
        {
            var claimEntity = _claimsRepo.GetClaim(companyId, assuredName);
            if (claimEntity is null)
                return null;

            return mapper.Map<ClaimDTO>(claimEntity);
        }

        public IReadOnlyCollection<ClaimDTO> GetClaims(int companyId, IMapper mapper)
        {
            var claimsEntities = _claimsRepo.GetClaims(companyId);
            if (claimsEntities is null || !claimsEntities.Any())
                return new List<ClaimDTO>();

            return mapper.Map<IReadOnlyCollection<ClaimDTO>>(claimsEntities);
        }

        public bool UpdateClaim(ClaimDTO claim, IMapper mapper)
        {
            return _claimsRepo.UpdateClaim(mapper.Map<ClaimEntity>(claim));
        }
    }
}
