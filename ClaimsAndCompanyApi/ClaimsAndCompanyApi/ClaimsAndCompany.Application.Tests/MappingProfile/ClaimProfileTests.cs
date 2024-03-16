using AutoMapper;
using ClaimsAndCompany.Application.DTOs;
using ClaimsAndCompany.Application.MappingProfiles;
using ClaimsAndCompany.Domain.Entities;

namespace ClaimsAndCompany.Application.Tests.MappingProfile
{
    public class ClaimProfileTests
    {
        [Fact]
        public void MappingClaimEntity_ToClaimDTO_ShouldWork()
        {
            // Arrange
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ClaimProfile());
            });

            var mapper = config.CreateMapper();

            var assuredName = "Bob Fossil";
            var closed = 1;
            var companyId = 278;
            var incurredLoss = 100;
            var claimDate = DateTime.Now.AddDays(-10);
            var lossDate = DateTime.Now.AddDays(10);
            var ucr = ClaimType.MedicalCheckup.ToString();

            var claimEntity = new ClaimEntity
            {
                ClaimDate = claimDate,
                AssuredName = assuredName,
                Closed = closed,
                CompanyId = companyId,
                IncurredLoss = incurredLoss,
                LossDate = lossDate,
                UCR = ucr
            };

            // Act
            var claimDto = mapper.Map<ClaimDTO>(claimEntity);

            // Assert
            Assert.Equal((DateTime.Now - claimDate).Days, claimDto.ClaimAgeInDays);
            Assert.Equal(assuredName, claimDto.AssuredName);
            Assert.Equal(closed, claimDto.Closed);
            Assert.Equal(companyId, claimDto.CompanyId);
            Assert.Equal(incurredLoss, claimDto.IncurredLoss);
            Assert.Equal(claimDate, claimDto.ClaimDate);
            Assert.Equal(lossDate, claimDto.LossDate);
            Assert.Equal(ucr, claimDto.UCR);
        }
    }
}