using MediatR;
using StudentsCoursesManager.Data.Entities;

namespace StudentsCoursesManager.Commands.UserCommands
{
    public class DeleteUserCommand:IRequest<User>
    {
        public int UserId { get; set; }
        public DeleteUserCommand(int userId)
        {
            UserId = userId;
        }
    }
}
