using MediatR;

namespace StudentsCoursesManager.Commands.UserCommands
{
    public class DeleteUserCommand:IRequest
    {
        public int UserId { get; set; }
        public DeleteUserCommand(int userId)
        {
            UserId = userId;
        }
    }
}
