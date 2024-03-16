using ClaimsAndCompany.Domain.Entities;
using ClaimsAndCompany.Domain.Interfaces.Repositories;

namespace ClaimsAndCompany.Infrastructure.Persistence.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        public CompanyEntity? GetCompany(int companyId)
        {
            var companies = GetCompanyTestData();

            return companies?.FirstOrDefault(x => x.Id == companyId);
        }

        private List<CompanyEntity> GetCompanyTestData()
        {
            return new List<CompanyEntity>
            {
                new CompanyEntity
                {
                    Id = 1,
                    Name = "Lister Limited",
                    Address1 = "13 Weatlea Gardens",
                    Address2 = "Holbeck",
                    Address3 = "Leeds",
                    Postcode = "LS18 7UI",
                    Country = "United Kingdom",
                    InsuranceEndDate = DateTime.Parse("2025-01-01")
                },
                new CompanyEntity
                {
                    Id = 2,
                    Name = "Golden Gate Productions",
                    Address1 = "250 Paradise View",
                    Address2 = "Beeston",
                    Address3 = "Leeds",
                    Postcode = "LS32 9EP",
                    Country = "United Kingdom",
                    InsuranceEndDate = DateTime.Parse("2026-01-01")
                },
                new CompanyEntity
                {
                    Id = 3,
                    Name = "Westland Wines",
                    Address1 = "17B Audacia Avenue",
                    Address2 = "Morley",
                    Address3 = "Leeds",
                    Postcode = "LS19 7OZ",
                    Country = "United Kingdom",
                    InsuranceEndDate = DateTime.Parse("2022-01-01")
                }
            };
        }
    }
}
