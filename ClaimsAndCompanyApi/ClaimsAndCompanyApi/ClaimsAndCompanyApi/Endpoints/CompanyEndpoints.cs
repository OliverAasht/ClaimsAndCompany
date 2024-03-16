using AutoMapper;
using ClaimsAndCompany.Application.Services.Company;

namespace ClaimsAndCompanyApi.Endpoints
{
    public static class CompanyEndpoints
    {
        public static void MapCompanyEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapGet(
                "company/{companyId:int:min(1)}",
                (int companyId, ICompanyService companyService, IMapper mapper) =>
            {
                var companyDto = companyService.GetCompany(companyId, mapper);
                if (companyDto is null)
                {
                    return Results.NotFound("Company not found");
                }

                return Results.Ok(companyDto);
            });
        }
    }
}
