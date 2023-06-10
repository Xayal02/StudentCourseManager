using MediatR;
using StudentsCoursesManager.Models;

namespace StudentsCoursesManager.Commands.UserCommands
{
    public class UpdateUserCommand:IRequest
    {
        public int UserId { get; set; }
        public UserModel UserModel{ get; set; }
        public UpdateUserCommand(int userId,UserModel userModel)
        {
            UserId = userId;
            UserModel = userModel;
        }
    }
}
