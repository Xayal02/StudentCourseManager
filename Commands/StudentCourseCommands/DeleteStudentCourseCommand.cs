using MediatR;
using StudentsCoursesManager.Models;

namespace StudentsCoursesManager.Commands.StudentCourseCommands
{
    public class DeleteStudentCourseCommand : IRequest
    {
        public int Id { get; set; }
        public DeleteStudentCourseCommand(int id)
        {
            Id = id;
        }
    }
}
