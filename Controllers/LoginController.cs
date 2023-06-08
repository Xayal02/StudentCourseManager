using Microsoft.AspNetCore.Mvc;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Data.UnitOfWork;
using StudentsCoursesManager.Models;
using StudentsCoursesManager.Helpers;

namespace StudentsCoursesManager.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEnumerable<User> _users;
        private readonly IConfiguration _configuration;
        public AuthenticationController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _users =   _unitOfWork.UserRepository.GetAll();
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var user = _users.FirstOrDefault(u => u.UserName == loginModel.UserName && u.Password == loginModel.Password);

            if (user is null) return NotFound("Username or password is incorrect");

            var token = TokenFactory.GenerateJwtToken(_configuration,user);

            return Ok(new LoginResultModel() { Id = user.Id, AuthenticationToken = token });
        }
    }
}
