using MediatR;
using StudentsCoursesManager.Models;

namespace StudentsCoursesManager.Application.Commands.StudentCourseCommands
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
