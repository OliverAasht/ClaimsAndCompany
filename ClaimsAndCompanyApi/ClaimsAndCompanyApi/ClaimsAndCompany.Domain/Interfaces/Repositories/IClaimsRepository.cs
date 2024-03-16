using ClaimsAndCompany.Domain.Entities;

namespace ClaimsAndCompany.Domain.Interfaces.Repositories
{
    public interface IClaimsRepository
    {
        List<ClaimEntity>? GetClaims(int companyId);

        ClaimEntity? GetClaim(int companyId, string assuredName);

        bool UpdateClaim(ClaimEntity claim);
    }
}
