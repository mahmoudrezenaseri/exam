using Exam.API.Models.DTOs;
using Exam.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exam.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }



        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var model = _userService.GetByUserId(id);

            return Ok(model);
        }



        [HttpPost]
        public IActionResult Create(CreateUser input)
        {
            var id = _userService.CreateUser(input);

            return Ok(id);
        }

        [HttpPut]
        public IActionResult Edit(EditUser input)
        {
            _userService.EditUser(input);

            return Ok();
        }
    }
}
