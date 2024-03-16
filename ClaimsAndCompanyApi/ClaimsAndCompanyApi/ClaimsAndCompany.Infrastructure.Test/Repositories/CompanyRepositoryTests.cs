using ClaimsAndCompany.Domain.Interfaces.Repositories;
using ClaimsAndCompany.Infrastructure.Persistence.Repositories;

namespace ClaimsAndCompany.Infrastructure.Tests.Repositories
{
    public class CompanyRepositoryTests
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyRepositoryTests()
        {
            _companyRepository = new CompanyRepository();
        }

        [Fact]
        public void GetCompany_WithValidCompanyId_ReturnsCompanyEntity()
        {
            // Arrange
            var expectedCompanyId = 1;
            var expectedCompanyName = "Lister Limited";
            var expectedAddress1 = "13 Weatlea Gardens";
            var expectedAddress2 = "Holbeck";
            var expectedAddress3 = "Leeds";
            var expectedPostcode = "LS18 7UI";
            var expectedCountry = "United Kingdom";
            var expectInsuranceEndDate = DateTime.Parse("2025-01-01");

            // Act
            var company = _companyRepository.GetCompany(expectedCompanyId);

            // Assert
            Assert.NotNull(company);
            Assert.Equal(expectedCompanyId, company.Id);
            Assert.Equal(expectedCompanyName, company.Name);
            Assert.Equal(expectedAddress1, company.Address1);
            Assert.Equal(expectedAddress2, company.Address2);
            Assert.Equal(expectedAddress3, company.Address3);
            Assert.Equal(expectedPostcode, company.Postcode);
            Assert.Equal(expectedCountry, company.Country);
            Assert.Equal(expectInsuranceEndDate, company.InsuranceEndDate);
        }

        [Fact]
        public void GetCompany_WithInvalidCompanyId_ReturnsNull()
        {
            // Arrange
            var invalidCompanyId = -1;

            // Act
            var company = _companyRepository.GetCompany(invalidCompanyId);

            // Assert
            Assert.Null(company);
        }

        [Fact]
        public void GetCompany_WithNonExistingCompanyId_ReturnsNull()
        {
            // Arrange
            var nonExistingCompanyId = 999;

            // Act
            var company = _companyRepository.GetCompany(nonExistingCompanyId);

            // Assert
            Assert.Null(company);
        }
    }
}
