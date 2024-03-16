using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace ClaimsAndCompany.Api.Integration.Tests
{
    public class CompanyApiIntegrationTests
    {
        [Fact]
        public async Task GetCompanyEndpoint_Returns_Success()
        {
            // Arrange
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            // Act
            var response = await client.GetAsync("/company/1");

            //Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetCompanyEndpoint_Returns_NotFound()
        {
            // Arrange
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            // Act
            var response = await client.GetAsync("/company/200");
            var responseContent = await response.Content.ReadAsStringAsync();

            //Assert
            response.StatusCode.Equals(HttpStatusCode.NotFound);
            Assert.Contains("Company not found", responseContent);
        }
    }
}