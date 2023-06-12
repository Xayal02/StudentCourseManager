using MediatR;
using StudentsCoursesManager.Data.Entities;

namespace StudentsCoursesManager.Application.Commands.StudentCommands
{
    public class DeleteStudentCommand : IRequest<Student>
    {
        public int Id { get; set; }
        public DeleteStudentCommand(int id)
        {
            Id = id;
        }
    }
}
