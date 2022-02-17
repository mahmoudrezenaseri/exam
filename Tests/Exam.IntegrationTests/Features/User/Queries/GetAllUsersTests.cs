namespace Exam.IntegrationTests.Features.User.Queries;

using Exam.API;
using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

[Collection("User")]
public class GetAllUsersTests
{
    private readonly HttpClient client;

    public GetAllUsersTests()
    {
        var application = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>{});
        this.client = application.CreateClient();
    }

    [Fact]
    public async Task GetAllUsersTest()
    {
        // Send a get request to retrieve list of users
        var response = await client.GetAsync($"api/user");

        // Make sure correct status code is returned
        response.StatusCode.ShouldBe(HttpStatusCode.OK);
    }
}
