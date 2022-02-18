using Exam.Core.ApplicationService.Users.Commands.AddUser;
using Exam.Core.ApplicationService.Users.Commands.UpdateUser;
using Exam.Core.ApplicationService.Users.ViewModels;
using Exam.Core.Domain.Users.Entities;
using Exam.Framework.ApplicationService;
using Exam.Persistence.SqlServer;
using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace Exam.IntegrationTests.Controllers
{
    public class UserControllerTest : IntegrationTest
    {
        private const string Uri = "api/v1/users";

        #region Get

        [Fact]
        public async Task Get_ReturnNotFound_WhenUserIsNotExists() 
        {
            var client = GetClient();

            var response = await client.GetAsync($"{Uri}/1");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            (await response.Content.ReadFromJsonAsync<ApplicationServiceResult<UserViewModel>>()).Data.Should().BeNull();
        }

        [Fact]
        public async Task Get_ReturnUser_WhenPostIsExists()
        {
            var createdUser = GetTestUser(); 
            var client = GetClient(db => 
            {
                db.Users.Add(createdUser);
                db.SaveChanges();
            });

            var response = await client.GetAsync($"{Uri}/{createdUser.Id}");
            var responseContent = await response.Content.ReadFromJsonAsync<ApplicationServiceResult<UserViewModel>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            responseContent.Data.Id.Should().Be(createdUser.Id);
            responseContent.Data.FirstName.Should().Be(createdUser.FirstName);
            responseContent.Data.LastName.Should().Be(createdUser.LastName);
            responseContent.Data.NationalCode.Should().Be(createdUser.NationalCode);
            responseContent.Data.PhoneNumber.Should().Be(createdUser.PhoneNumber);
        }

        #endregion

        #region Post

        [Theory]
        [InlineData("", "", "", "")]
        [InlineData("mohsen", "", "", "")]
        [InlineData("mohsen", "ilkhani", "", "")]
        [InlineData("mohsen", "ilkhani", "0785266488", "")]
        [InlineData("mohsen", "ilkhani", "", "09354856252")]
        [InlineData("mohsen", "", "0785266488", "09354856252")]
        public async Task Post_ReturnValidationError_WhenPostedDataIsNotValid(string firstName, string lastName, string nationalCode, string phoneNumber)
        {
            var client = GetClient();

            var command = new AddUserCommand()
            {
                FirstName = firstName,
                LastName = lastName,
                NationalCode = nationalCode,
                PhoneNumber = phoneNumber
            };

            var response = await client.PostAsJsonAsync(Uri, command);
            var responseContent = await response.Content.ReadFromJsonAsync<ApplicationServiceResult<UserViewModel>>();

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            responseContent.Data.Should().BeNull();
            responseContent.Messages.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public async Task Post_ReturnUser_WhenPostedDataValid()
        {
            var client = GetClient();

            var command = new AddUserCommand()
            {
                FirstName = "mohsen",
                LastName = "ilkhani",
                NationalCode = "0785266488",
                PhoneNumber = "09354856252"
            };

            var response = await client.PostAsJsonAsync(Uri, command);
            var responseContent = await response.Content.ReadFromJsonAsync<ApplicationServiceResult<UserViewModel>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            responseContent.Data.Id.Should().BeGreaterThan(0);
            responseContent.Data.FirstName.Should().Be(command.FirstName);
            responseContent.Data.LastName.Should().Be(command.LastName);
            responseContent.Data.NationalCode.Should().Be(command.NationalCode);
            responseContent.Data.PhoneNumber.Should().Be(command.PhoneNumber);
        }

        #endregion

        #region Put

        [Theory]
        [InlineData("", "", "", "")]
        [InlineData("mohsen", "", "", "")]
        [InlineData("mohsen", "ilkhani", "", "")]
        [InlineData("mohsen", "ilkhani", "0785266488", "")]
        [InlineData("mohsen", "ilkhani", "", "09354856252")]
        [InlineData("mohsen", "", "0785266488", "09354856252")]
        public async Task Put_ReturnValidationError_WhenPostedDataIsNotValid(string firstName, string lastName, string nationalCode, string phoneNumber)
        {
            var createdUser = GetTestUser();
            var client = GetClient(db =>
            {
                db.Users.Add(createdUser);
                db.SaveChanges();
            });

            var command = new UpdateUserCommand()
            {
                Id = createdUser.Id,
                FirstName = firstName,
                LastName = lastName,
                NationalCode = nationalCode,
                PhoneNumber = phoneNumber
            };

            var response = await client.PutAsJsonAsync($"{Uri}/{createdUser.Id}", command);
            var responseContent = await response.Content.ReadFromJsonAsync<ApplicationServiceResult<UserViewModel>>();

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            responseContent.Data.Should().BeNull();
            responseContent.Messages.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public async Task Put_ReturnNotFound_WhenUserIsNotExists()
        {
            var client = GetClient();

            var command = new UpdateUserCommand()
            {
                Id = 1,
                FirstName = "mohsen",
                LastName = "ilkhani",
                NationalCode = "0785266488",
                PhoneNumber = "09354856252"
            };

            var response = await client.PutAsJsonAsync($"{Uri}/{command.Id}", command);
            var responseContent = await response.Content.ReadFromJsonAsync<ApplicationServiceResult<UserViewModel>>();

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            responseContent.Data.Should().BeNull();
        }

        [Fact]
        public async Task Put_ReturnModifiedPost_WhenUserIsExists()
        {
            var createdUser = GetTestUser();
            var client = GetClient(db =>
            {
                db.Users.Add(createdUser);
                db.SaveChanges();
            });

            var command = new UpdateUserCommand()
            {
                Id = createdUser.Id,
                FirstName = "ali",
                LastName = "zamani",
                NationalCode = "0785266489",
                PhoneNumber = "09354856253"
            };

            var response = await client.PutAsJsonAsync($"{Uri}/{command.Id}", command);
            var responseContent = await response.Content.ReadFromJsonAsync<ApplicationServiceResult<UserViewModel>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            responseContent.Data.Id.Should().Be(command.Id);
            responseContent.Data.FirstName.Should().Be(command.FirstName);
            responseContent.Data.LastName.Should().Be(command.LastName);
            responseContent.Data.NationalCode.Should().Be(command.NationalCode);
            responseContent.Data.PhoneNumber.Should().Be(command.PhoneNumber);
        }

        #endregion

        #region Private Methods

        private User GetTestUser() 
        {
            return new User()
            {
                FirstName = "mohsen",
                LastName = "ilkhani",
                NationalCode = "0785266488",
                PhoneNumber = "09354856252"
            };
        } 

        #endregion
    }
}
