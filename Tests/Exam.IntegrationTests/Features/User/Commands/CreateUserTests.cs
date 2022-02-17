namespace Exam.IntegrationTests.Features.User.Commands;

using Exam.API;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Exam.Domain.Entities;
using System.Net.Http.Json;
using Shouldly;
using System.Net;

[Collection("User")]
public class CreateUserTests
{
    private readonly HttpClient client;

    public CreateUserTests()
    {
        var application = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>{});
        this.client = application.CreateClient();
    }

    [Fact]
    public async Task CreateUserWithValidDataTest()
    {
        var user = new User
        {
            FirstName = "Test",
            LastName = "Test",
            NationalCode = "1234567890",
            PhoneNumber = "09307878735"
        };

        // Send a post request to create the user
        var response = await client.PostAsJsonAsync("api/user", user);

        // Ensure user is created
        response.StatusCode.ShouldBe(HttpStatusCode.Created);
    }
    
    [Fact]
    public async Task CreateUserWithInvalidDataTest()
    {
        var user = new User
        {
            FirstName = "Test",
            LastName = "Test",
            NationalCode = "0",
            PhoneNumber = "000"
        };

        // Send a post request to create the invalid user
        var response = await client.PostAsJsonAsync("api/user", user);

        // Ensure user is not created
        response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
    }
}
