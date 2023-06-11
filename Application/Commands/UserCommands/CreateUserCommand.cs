using MediatR;
using StudentsCoursesManager.Application.Models;
using StudentsCoursesManager.Data.Entities;

namespace StudentsCoursesManager.Application.Commands.UserCommands
{
    public class CreateUserCommand : IRequest<User>
    {
        public UserModel UserModel { get; set; }
        public CreateUserCommand(UserModel userModel)
        {
            UserModel = userModel;
        }
    }
}
