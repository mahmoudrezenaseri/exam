using Exam.API;
using Exam.API.Models;
using Exam.API.Models.DTOs;
using Exam.API.Services.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using RESTFulSense.Clients;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Exam.IntegrationTests
{
    public class UserControllerTest
    {
        private readonly RESTFulApiFactoryClient restClient;
        private readonly HttpClient httpClient;
        private readonly WebApplicationFactory<Startup> applicationFactory;


        public UserControllerTest()
        {
            applicationFactory = new WebApplicationFactory<Startup>();
            httpClient = applicationFactory.CreateClient();
            restClient = new RESTFulApiFactoryClient(httpClient);

        }

        private CreateUser CreateSomeUser()
        {
            return new CreateUser(firstName: "Maryam", lastName: "Ghoreishi", phoneNumber: "093237", nationalCode: "4333");
        }
        [Fact]
        public void Should_CreateNewUser()
        {
            //arrange
            const string path = "User/Create";
            CreateUser createUser = CreateSomeUser();


            //act
            var id = restClient.PostContentAsync<CreateUser, long>(path, createUser);


            //assert

            id.Should().NotBeNull();
        }


        [Fact]
        public async void Should_EditUser()
        {
            //arrange
            CreateUser createUser = CreateSomeUser();
            //act
            var id = await restClient.PostContentAsync<CreateUser, long>("User/Create", createUser);


            EditUser editUser = new EditUser(id: id, firstName: "mina", lastName: "gg", phoneNumber: "09365237", nationalCode: "34");
            await restClient.PutContentAsync<EditUser, long>("User/Edit", editUser);
            var actual = restClient.GetContentAsync<ResponseUser>("User/GetById/" + id);

            //assert
            actual.Result.FirstName.Should().Equals("mina");
        }
        [Fact]
        public void Should_GetUserById()
        {
            //arrange
            const string createPath = "User/Create";
            CreateUser createUser = new CreateUser(firstName: "parisa", lastName: "fds", phoneNumber: "093237", nationalCode: "4333");
            //act
            var userId = restClient.PostContentAsync<CreateUser, long>(createPath, createUser);
            var actual = restClient.GetContentAsync<ResponseUser>("User/GetById?id=" + userId);

            //assert
            actual.Should().NotBeNull();
        }


    }
}
