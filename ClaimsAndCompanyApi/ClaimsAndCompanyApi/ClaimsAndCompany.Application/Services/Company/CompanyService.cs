using AutoMapper;
using ClaimsAndCompany.Application.DTOs;
using ClaimsAndCompany.Domain.Interfaces.Repositories;

namespace ClaimsAndCompany.Application.Services.Company
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepo;

        public CompanyService(ICompanyRepository companyRepo)
        {
            _companyRepo = companyRepo;
        }

        public CompanyDTO? GetCompany(int companyId, IMapper mapper)
        {
            var company = _companyRepo.GetCompany(companyId);
            if (company is null)
                return null;

            return mapper.Map<CompanyDTO>(company);
        }
    }
}
