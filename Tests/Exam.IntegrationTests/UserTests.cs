using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Exam.API;
using Exam.API.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace Exam.IntegrationTests;

public class UserTests
{
    private readonly HttpClient _client;
    private string _baseUrl = "api/User";
    private StringContent _content;

    public UserTests()
    {
        var application = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder => { });

        var model = CreateUserModel();
        _content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

        _client = application.CreateClient();
    }

    [Fact]
    public async Task create_user()
    {
        var response =
            await _client.PostAsync(_baseUrl, _content);

        Assert.True(response.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async Task Update_user()
    {
        var id = await InsertUser();

        var url = $"{_baseUrl}?id={id}";
        var response=await _client.PatchAsync(url, _content);

        Assert.True(response.StatusCode == HttpStatusCode.OK);
    }
    [Fact]
    public async Task Get_user()
    {
        var id = await InsertUser();

        var url = $"{_baseUrl}?id={id}";
        var response = await _client.GetAsync(url);


        Assert.True(response.StatusCode == HttpStatusCode.OK);
    }

    private async Task<string> InsertUser()
    {
        var postResponse =
            await _client.PostAsync(_baseUrl, _content);

        var id = await postResponse.Content.ReadAsStringAsync();
        id = id.Replace('\"', ' ');
        return id;
    }

    private static CreateUserModel CreateUserModel()
    {
        var model = new CreateUserModel()
        {
            NationalCode = "0014676214",
            LastName = "Karami",
            FirstName = "Soheil",
            PhoneNumber = "09125766570"
        };
        return model;
    }
}