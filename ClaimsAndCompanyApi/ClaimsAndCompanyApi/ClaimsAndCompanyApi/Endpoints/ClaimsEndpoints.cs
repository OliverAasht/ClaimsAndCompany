using AutoMapper;
using ClaimsAndCompany.Application.DTOs;
using ClaimsAndCompany.Application.Services.Claim;

namespace ClaimsAndCompanyApi.Endpoints
{
    public static class ClaimsEndpoints
    {
        public static void MapClaimsEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapGet(
                "claims/{companyId:int:min(1)}",
                (int companyId, IClaimService claimService, IMapper mapper) =>
            {
                var claims = claimService.GetClaims(companyId, mapper);
                if (!claims.Any())
                    return Results.NotFound("No claims found for provided company");

                return Results.Ok(claims);
            });

            endpointRouteBuilder.MapGet(
                "claim/{companyId:int:min(1)}/{assuredName}",
                (int companyId, string assuredName, IClaimService claimService, IMapper mapper) =>
            {
                if (string.IsNullOrWhiteSpace(assuredName))
                    return Results.BadRequest("Assured name cannot be null, empty or whitespace");

                var claimDto = claimService.GetClaim(companyId, assuredName.Trim(), mapper);
                if (claimDto is null)
                    return Results.NotFound("No matching claim found");

                return Results.Ok(claimDto);
            });

            endpointRouteBuilder.MapPut(
                "claim",
                (ClaimDTO updatedClaim, IClaimService claimService, IMapper mapper) =>
            {
                var existingClaim = claimService.GetClaim(updatedClaim.CompanyId,
                                                          updatedClaim.AssuredName,
                                                          mapper);
                if (existingClaim is null)
                    return Results.NotFound("No existing claim found to update");

                var isClaimUpdated = claimService.UpdateClaim(updatedClaim, mapper);
                if (!isClaimUpdated)
                    return Results.UnprocessableEntity("Existing claim not updated");

                return Results.Created();
            });
        }
    }
}
