using ClaimsAndCompany.Domain.Entities;

namespace ClaimsAndCompany.Domain.Interfaces.Repositories
{
    public interface ICompanyRepository
    {
        CompanyEntity? GetCompany(int companyId);
    }
}
