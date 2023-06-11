using MediatR;
using StudentsCoursesManager.Application.Models;

namespace StudentsCoursesManager.Application.Commands.CourseCommands
{
    public class UpdateCourseCommand : IRequest
    {
        public int Id { get; set; }
        public CourseModel CourseModel { get; set; }
        public UpdateCourseCommand(int id, CourseModel courseModel)
        {
            Id = id;
            CourseModel = courseModel;

        }
    }
}
