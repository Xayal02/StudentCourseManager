using MediatR;
using StudentsCoursesManager.Models;

namespace StudentsCoursesManager.Commands.CourseCommands
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
