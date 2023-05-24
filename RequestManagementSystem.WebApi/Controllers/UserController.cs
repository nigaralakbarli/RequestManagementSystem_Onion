using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestManagementSystem.Application.DTOs.Category.Request;
using RequestManagementSystem.Application.DTOs.User.Request;
using RequestManagementSystem.Application.Interfaces;
using RequestManagementSystem.Application.Services;

namespace RequestManagementSystem.WebApi.Controllers
{
    [Route("User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_userService.GetUsers());
        }

        [Route("GetById")]
        [HttpGet]
        public IActionResult GetUserById(int userId)
        {
            return Ok(_userService.GetUserById(userId));
        }

        [Route("Create")]
        [HttpPost]
        public IActionResult CreateCategory(UserCreateDTO userCreateDTO)
        {
            if (_userService.CreateUser(userCreateDTO))
            {
                return BadRequest();
            }
            return Ok("Successfully created");
        }

        [Route("Update")]
        [HttpPut]
        public IActionResult UpdateUser(UserUpdateDTO userUpdateDTO)
        {
            if (_userService.UpdateUser(userUpdateDTO))
            {
                return Ok("Successfully updated");
            }
            return NotFound();
        }

        [Route("Delete")]
        [HttpDelete]
        public IActionResult DeleteUser(int userId)
        {
            if (_userService.DeleteUser(userId))
            {
                return Ok("Successfully deleted");
            }
            return NotFound();
        }
    }
}
