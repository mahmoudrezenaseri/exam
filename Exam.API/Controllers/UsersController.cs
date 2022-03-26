using Exam.API.Model.Dto;
using Exam.API.Model.Entity;
using Exam.API.Model.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private GetUserServices getUserServices;
        private UpdateUsersService updateUsersService;
        private CreateUsersService createUsersService;
        public UsersController(GetUserServices getUserServices,
            UpdateUsersService updateUsersService, 
            CreateUsersService createUsersService)
        {
            this.getUserServices = getUserServices;
            this.updateUsersService = updateUsersService;
            this.createUsersService = createUsersService;

        }

        // GET: api/<UsersController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public DtoUser Get(int id)
        {
            return getUserServices.getuser(id) ;
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] DtoUser dtoUse )
        {
            createUsersService.CreatUsers(dtoUse);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] DtoUser dtoUser)
        {
            updateUsersService.UpdateUser(id, dtoUser);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
