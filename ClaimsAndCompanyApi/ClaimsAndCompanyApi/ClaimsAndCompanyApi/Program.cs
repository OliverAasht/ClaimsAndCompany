using ClaimsAndCompany.Application.MappingProfiles;
using ClaimsAndCompany.Application.Services.Claim;
using ClaimsAndCompany.Application.Services.Company;
using ClaimsAndCompany.Domain.Interfaces.Repositories;
using ClaimsAndCompany.Infrastructure.Persistence.Repositories;
using ClaimsAndCompanyApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(CompanyProfile));
builder.Services.AddAutoMapper(typeof(ClaimProfile));
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IClaimsRepository, ClaimsRepository>();
builder.Services.AddScoped<IClaimService, ClaimService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapCompanyEndpoints();
app.MapClaimsEndpoints();

app.Run();

public partial class Program { }