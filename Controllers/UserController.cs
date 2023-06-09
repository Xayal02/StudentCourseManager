using AutoMapper;
using BCrypt.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Data.UnitOfWork;
using StudentsCoursesManager.Models;

namespace StudentsCoursesManager.Controllers
{
    //[Authorize(Policy = "AdminOnly")]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet("Get users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _unitOfWork.UserRepository.GetAllList();

            var userModels = users.Select(user => _mapper.Map<UserModel>(user));

            return Ok(userModels);
        }


        [HttpGet("Get user by id")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _unitOfWork.UserRepository.Find(id);
            if (user is null) return NotFound("Such user doesnt exist");

            return Ok(user);
        }


        [HttpPost("Create user")]
        public async Task<IActionResult> CreateUser([FromBody] UserModel userModel)
        {
            if (await _unitOfWork.UserRepository.Any(user => user.UserName == userModel.UserName)) 
                return Conflict("User with such username already exist");

            var user = _mapper.Map<User>(userModel);
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            await _unitOfWork.UserRepository.Add(user);
            await _unitOfWork.Save();

            return Ok(user);
        }


        [HttpPut("Update User")]
        public async Task<IActionResult> UpdateUser(int userId, UserModel userModel)
        {
            var user = await _unitOfWork.UserRepository.Find(userId);

            if (user is null) return NotFound("User with such Id doesnt exist");

            //Check if such username has been taken or not
            if (userModel.UserName != user.UserName &&
                await _unitOfWork.UserRepository.Any(user => user.UserName == userModel.UserName))
                return Conflict("Such username has alreary been taken");

            _mapper.Map(userModel,user);
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            await _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.Save();

            return Ok(user);
        }


        [HttpDelete("Delete User")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var user = await _unitOfWork.UserRepository.Find(userId);

            if (user is null) return NotFound("Such user doesnt exist");

            await _unitOfWork.UserRepository.Delete(user);
            await _unitOfWork.Save();

            return Ok(user);
        }
    }
}
