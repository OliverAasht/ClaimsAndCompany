using AutoMapper;
using ClaimsAndCompany.Application.DTOs;
using ClaimsAndCompany.Application.MappingProfiles;
using ClaimsAndCompany.Domain.Entities;

namespace ClaimsAndCompany.Application.Tests.MappingProfile
{
    public class CompanyProfileTests
    {
        [Theory]
        [InlineData("Gray Industries", "2025-01-01", true)]
        [InlineData("Blue Corporation", "2020-01-01", false)] 
        public void Mapping_CompanyEntity_To_CompanyDTO_Should_Work(
            string companyName,
            string insuranceEndDate,
            bool expectedActive)
        {
            // Arrange
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CompanyProfile());
            });
            var mapper = config.CreateMapper();

            var companyEntity = new CompanyEntity
            {
                Name = companyName,
                InsuranceEndDate = DateTime.Parse(insuranceEndDate)
            };

            // Act
            var companyDto = mapper.Map<CompanyDTO>(companyEntity);

            // Assert
            Assert.Equal(expectedActive, companyDto.Active);
            Assert.Equal(companyEntity.Name, companyDto.Name);
        }
    }
}
