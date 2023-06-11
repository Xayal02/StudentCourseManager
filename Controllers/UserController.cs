using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentsCoursesManager.Application.Models;
using StudentsCoursesManager.Commands.UserCommands;
using StudentsCoursesManager.Queries.UserQueries;

namespace StudentsCoursesManager.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
           _mediator = mediator;
        }


        [HttpGet("Get users")]
        public async Task<IActionResult> GetUsers()
        {
            var query = new GetAllUsersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }


        [HttpGet("Get user by id")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var query = new GetUserByIdQuery(userId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }


        [HttpPost("Create user")]
        public async Task<IActionResult> CreateUser([FromBody] UserModel userModel)
        {
            var command = new CreateUserCommand(userModel);
            var result = await _mediator.Send(command);

            return result == null ? Conflict("User with such username already exists") : Ok(result);
        }


        [HttpPut("Update User")]
        public async Task<IActionResult> UpdateUser(int userId, UserModel userModel)
        {
            var command = new UpdateUserCommand(userId, userModel);
            var result = _mediator.Send(command);

            return result == null ? Conflict("User with such username already exists") : Ok(result);

        }


        [HttpDelete("Delete User")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var command = new DeleteUserCommand(userId);
            var result = _mediator.Send(command);
            return Ok(result);
        }
    }
}
