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
    public class UserController : ControllerBase
    {
        
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        // GET: api/<UsersController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public UserDto Get(int id)
        {
            return _userService.GetUser(id) ;
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] UserDto userDto )
        {
            _userService.CreatUser(userDto);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] UserDto userDto)
        {
            return _userService.UpdateUser(id, userDto);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
