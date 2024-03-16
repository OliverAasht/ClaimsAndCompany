using AutoMapper;
using ClaimsAndCompany.Application.DTOs;

namespace ClaimsAndCompany.Application.Services.Company
{
    public interface ICompanyService
    {
        CompanyDTO? GetCompany(int companyId, IMapper mapper);
    }
}
