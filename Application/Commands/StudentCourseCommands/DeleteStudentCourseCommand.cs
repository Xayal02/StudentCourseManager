using MediatR;
using StudentsCoursesManager.Data.Entities;

namespace StudentsCoursesManager.Application.Commands.StudentCourseCommands
{
    public class DeleteStudentCourseCommand : IRequest<StudentCourse>
    {
        public int Id { get; set; }
        public DeleteStudentCourseCommand(int id)
        {
            Id = id;
        }
    }
}
