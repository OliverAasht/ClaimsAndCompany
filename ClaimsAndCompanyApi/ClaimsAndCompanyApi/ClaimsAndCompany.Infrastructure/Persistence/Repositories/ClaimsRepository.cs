using ClaimsAndCompany.Domain.Entities;
using ClaimsAndCompany.Domain.Interfaces.Repositories;

namespace ClaimsAndCompany.Infrastructure.Persistence.Repositories
{
    public class ClaimsRepository : IClaimsRepository
    {
        public ClaimEntity? GetClaim(int companyId, string assuredName)
        {
            var claims = GetClaimTestData();

            return claims.FirstOrDefault(x => x.CompanyId == companyId && x.AssuredName == assuredName);
        }

        public List<ClaimEntity> GetClaims(int companyId)
        {
            var claims = GetClaimTestData();
            if (!claims.Any())
                return new List<ClaimEntity>();

            return claims.Where(x => x.CompanyId == companyId).ToList();
        }

        public bool UpdateClaim(ClaimEntity updatedClaim)
        {
            var existingCompanyClaims = GetClaims(updatedClaim.CompanyId);
            if (existingCompanyClaims is null)
                return false;

            var matchingClaim = existingCompanyClaims.FirstOrDefault(
                x => x.CompanyId == updatedClaim.CompanyId &&
                     x.AssuredName == updatedClaim.AssuredName);

            if (matchingClaim is null)
            {
                return false;
            }
            var propertiesToUpdate = UpdatedClaimProperties(updatedClaim, matchingClaim);
            if (!propertiesToUpdate)
                return false;

            return true;
        }

        private bool UpdatedClaimProperties(ClaimEntity updatedClaim, ClaimEntity matchingClaim)
        {
            var propertiesToUpdate = false;

            if (!string.IsNullOrEmpty(updatedClaim.UCR) &&
                updatedClaim.UCR != matchingClaim.UCR)
            {
                matchingClaim.UCR = updatedClaim.UCR;
                propertiesToUpdate = true;
            }

            if (updatedClaim.ClaimDate.Date != DateTime.MinValue.Date &&
                updatedClaim.ClaimDate.Date != DateTime.MaxValue.Date &&
                updatedClaim.ClaimDate.Date != matchingClaim.ClaimDate.Date)
            {
                matchingClaim.ClaimDate = updatedClaim.ClaimDate;
                propertiesToUpdate = true;
            }

            if (updatedClaim.LossDate.Date != DateTime.MinValue.Date &&
                updatedClaim.LossDate.Date != DateTime.MaxValue.Date &&
                updatedClaim.LossDate.Date != matchingClaim.LossDate.Date)
            {
                matchingClaim.LossDate = updatedClaim.LossDate;
                propertiesToUpdate = true;
            }

            if (updatedClaim.IncurredLoss != 0 && 
                updatedClaim.IncurredLoss != matchingClaim.IncurredLoss)
            {
                matchingClaim.IncurredLoss = updatedClaim.IncurredLoss;
                propertiesToUpdate = true;
            }

            if (updatedClaim.Closed != matchingClaim.Closed &&
                updatedClaim.Closed >= 0 &&
                updatedClaim.Closed <= 1 &&
                updatedClaim.Closed != matchingClaim.Closed)
            {
                matchingClaim.Closed = updatedClaim.Closed;
                propertiesToUpdate = true;
            }

            return propertiesToUpdate;
        }

        private List<ClaimEntity> GetClaimTestData()
        {
            return new List<ClaimEntity>
            {
                new ClaimEntity
                {
                    UCR = ClaimType.MedicalCheckup.ToString(),
                    CompanyId = 1,
                    ClaimDate = DateTime.Parse("2024-03-11"),
                    LossDate = DateTime.Parse("2024-03-15"),
                    AssuredName = "George Cantwell",
                    IncurredLoss = 1020,
                    Closed = 1
                },
                new ClaimEntity
                {
                    UCR = ClaimType.MedicalCheckup.ToString(),
                    CompanyId = 1,
                    ClaimDate = DateTime.Parse("2024-03-13"),
                    LossDate = DateTime.Parse("2024-03-19"),
                    AssuredName = "Rosalind Springs",
                    IncurredLoss = 170,
                    Closed = 1
                }
            };
        }
    }
}
