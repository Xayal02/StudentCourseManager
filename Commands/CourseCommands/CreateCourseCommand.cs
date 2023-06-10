using MediatR;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Models;

namespace StudentsCoursesManager.Commands.CourseCommands
{
    public class CreateCourseCommand : IRequest<Course>
    {
        public CourseModel CourseModel { get; set; }
        public CreateCourseCommand(CourseModel courseModel)
        {
            CourseModel = courseModel;
        }
    }
}
