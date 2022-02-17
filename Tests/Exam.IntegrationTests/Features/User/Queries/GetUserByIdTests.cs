namespace Exam.IntegrationTests.Features.User.Queries;

using Exam.API;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Exam.Domain.Entities;
using System.Net.Http.Json;
using System;
using Shouldly;
using System.Net;
using Newtonsoft.Json;

[Collection("User")]
public class GetUserByIdTests
{
    private readonly HttpClient client;

    public GetUserByIdTests()
    {
        var application = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>{});
        this.client = application.CreateClient();
    }

    [Fact]
    public async Task GetUserByIdTest()
    {
        var user = new User
        {
            FirstName = "Test",
            LastName = "Test",
            NationalCode = "1234567890",
            PhoneNumber = "09307878735"
        };

        // Create a test user
        var response = await client.PostAsJsonAsync("api/user", user);

        // Ensure user is created
        response.StatusCode.ShouldBe(HttpStatusCode.Created);

        // Get id of created user
        var json = await response.Content.ReadAsStringAsync();
        user = JsonConvert.DeserializeObject<User>(json);

        // Send a get request to retrieve the user
        response = await client.GetAsync($"api/user/{user.Id}");

        // Make sure correct status code is returned
        response.StatusCode.ShouldBe(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetUserByInvalidIdTest()
    {
        // Send a get request to retrieve a non existing user
        var response = await client.GetAsync($"api/user/{Guid.NewGuid()}");

        // Make sure correct status code is returned
        response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
    }
}
