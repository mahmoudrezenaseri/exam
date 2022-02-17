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
using Newtonsoft.Json;

[Collection("User")]
public class UpdateUserTests
{
    private readonly HttpClient client;

    public UpdateUserTests()
    {
        var application = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>{});
        this.client = application.CreateClient();
    }

    [Fact]
    public async Task UpdateUserWithValidDataTest()
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

        // Deserialize the created user
        var json = await response.Content.ReadAsStringAsync();
        user = JsonConvert.DeserializeObject<User>(json);

        // Send a put request to update the user
        user.FirstName = "Walter";
        user.LastName = "White";
        response = await client.PutAsJsonAsync($"api/user", user);

        // Make sure correct status code is returned
        response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
    }
    
    [Fact]
    public async Task UpdateUserWithInvalidDataTest()
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

        // Deserialize the created user
        var json = await response.Content.ReadAsStringAsync();
        user = JsonConvert.DeserializeObject<User>(json);

        // Send a put request to update the user with invalid data
        user.PhoneNumber = "000";
        response = await client.PutAsJsonAsync($"api/user", user);

        // Make sure correct status code is returned
        response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
    }
}
