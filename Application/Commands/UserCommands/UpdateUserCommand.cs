using MediatR;
using StudentsCoursesManager.Application.Models;
using StudentsCoursesManager.Data.Entities;

namespace StudentsCoursesManager.Application.Commands.UserCommands
{
    public class UpdateUserCommand : IRequest<User>
    {
        public int UserId { get; set; }
        public UserModel UserModel { get; set; }
        public UpdateUserCommand(int userId, UserModel userModel)
        {
            UserId = userId;
            UserModel = userModel;
        }
    }
}
