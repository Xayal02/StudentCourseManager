using MediatR;

namespace StudentsCoursesManager.Application.Commands.StudentCommands
{
    public class DeleteStudentCommand : IRequest
    {
        public int Id { get; set; }
        public DeleteStudentCommand(int id)
        {
            Id = id;
        }
    }
}
