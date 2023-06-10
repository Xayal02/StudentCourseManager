using MediatR;

namespace StudentsCoursesManager.Commands.StudentCommands
{
    public class DeleteStudentCommand:IRequest
    {
        public int Id { get; set; }
        public DeleteStudentCommand(int id)
        {
            Id = id;
        }
    }
}
