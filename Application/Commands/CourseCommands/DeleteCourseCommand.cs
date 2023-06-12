using MediatR;
using StudentsCoursesManager.Data.Entities;

namespace StudentsCoursesManager.Application.Commands.CourseCommands
{
    public class DeleteCourseCommand : IRequest<Course>
    {
        public int Id { get; set; }
        public DeleteCourseCommand(int id)
        {
            Id = id;
        }
    }
}
