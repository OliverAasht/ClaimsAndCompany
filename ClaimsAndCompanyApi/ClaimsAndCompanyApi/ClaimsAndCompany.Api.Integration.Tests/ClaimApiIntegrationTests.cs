using ClaimsAndCompany.Application.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text;
using System.Text.Json;

namespace ClaimsAndCompany.Api.Integration.Tests
{
    public class ClaimApiIntegrationTests
    {
        [Fact]
        public async Task GetClaimsEndpoint_Returns_Success()
        {
            // Arrange
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            // Act
            var response = await client.GetAsync("/claims/1");

            //Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetClaimsEndpoint_Returns_NotFound()
        {
            // Arrange
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            // Act
            var response = await client.GetAsync("/claims/200");
            var responseContent = await response.Content.ReadAsStringAsync();

            //Assert
            response.StatusCode.Equals(HttpStatusCode.NotFound);
            Assert.Contains("No claims found for provided company", responseContent);
        }

        [Fact]
        public async Task GetClaimEndpoint_Returns_NotFound()
        {
            // Arrange
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            // Act
            var response = await client.GetAsync("/claim/200/Hulio Jashan/");
            var responseContent = await response.Content.ReadAsStringAsync();

            //Assert
            response.StatusCode.Equals(HttpStatusCode.NotFound);
            Assert.Contains("No matching claim found", responseContent);
        }

        [Fact]
        public async Task GetClaimEndpoint_Returns_Success()
        {
            // Arrange
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            // Act
            var response = await client.GetAsync("/claim/1/George Cantwell/");
            var responseContent = await response.Content.ReadAsStringAsync();

            //Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetClaimEndpoint_Returns_BadRequest()
        {
            // Arrange
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            // Act
            var response = await client.GetAsync("/claim/1/  /");
            var responseContent = await response.Content.ReadAsStringAsync();

            //Assert
            response.StatusCode.Equals(HttpStatusCode.BadRequest);
            Assert.Contains("Assured name cannot be null, empty or whitespace", responseContent);
        }

        [Fact]
        public async Task PutClaimEndpoint_Returns_BadRequest()
        {
            // Arrange
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            var updatedClaim = new ClaimDTO
            {
                CompanyId = 1,
                AssuredName = "John Doe"
            };

            var jsonContent = JsonSerializer.Serialize(updatedClaim);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Act
            var response = await client.PutAsync("/claim", httpContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            //Assert
            response.StatusCode.Equals(HttpStatusCode.NotFound);
            Assert.Contains("No existing claim found to update", responseContent);
        }

        [Fact]
        public async Task PutClaimEndpoint_Returns_UnprocessableEntity()
        {
            // Arrange
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            var updatedClaim = new ClaimDTO
            {
                CompanyId = 1,
                AssuredName = "George Cantwell",
                Closed = 1
            };

            var jsonContent = JsonSerializer.Serialize(updatedClaim);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Act
            var response = await client.PutAsync("/claim", httpContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            //Assert
            response.StatusCode.Equals(HttpStatusCode.UnprocessableEntity);
            Assert.Contains("Existing claim not updated", responseContent);
        }

        [Fact]
        public async Task PutClaimEndpoint_Returns_Success()
        {
            // Arrange
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();
            Random random = new Random();

            var updatedClaim = new ClaimDTO
            {
                CompanyId = 1,
                AssuredName = "George Cantwell",
                IncurredLoss = random.Next(1, 101)
            };

            var jsonContent = JsonSerializer.Serialize(updatedClaim);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Act
            var response = await client.PutAsync("/claim", httpContent);

            //Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
