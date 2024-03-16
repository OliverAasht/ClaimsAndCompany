using ClaimsAndCompany.Domain.Interfaces.Repositories;
using ClaimsAndCompany.Infrastructure.Persistence.Repositories;

namespace ClaimsAndCompany.Infrastructure.Tests.Repositories
{
    public class ClaimsRepositoryTests
    {
        private readonly IClaimsRepository _claimsRepository;

        public ClaimsRepositoryTests()
        {
            _claimsRepository = new ClaimsRepository();
        }

        [Fact]
        public void GetClaim_WithValidDetails_ReturnsClaimEntity()
        {
            // Arrange
            var companyId = 1;
            var assuredName = "George Cantwell";

            // Act
            var claim = _claimsRepository.GetClaim(companyId, assuredName);

            // Assert
            Assert.NotNull(claim);
            Assert.Equal(companyId, claim.CompanyId);
            Assert.Equal(assuredName, claim.AssuredName);
        }

        [Fact]
        public void GetClaim_ReturnsNull_WhenNoClaimFound()
        {
            // Arrange
            int companyId = 1;
            string assuredName = "NonExistentName";

            // Act
            var result = _claimsRepository.GetClaim(companyId, assuredName);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetClaims_ReturnsEmpty_WhenNoClaimsFound()
        {
            // Arrange
            int companyId = 999;

            // Act
            var result = _claimsRepository.GetClaims(companyId);

            // Assert
            Assert.Empty(result);
        }
    }
}
