using MediatR;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Models;

namespace StudentsCoursesManager.Commands.UserCommands
{
    public class CreateUserCommand:IRequest<User>
    {
        public UserModel UserModel { get; set; }
        public CreateUserCommand(UserModel userModel)
        {
            UserModel = userModel;
        }
    }
}
