using MediatR;
using StudentsCoursesManager.Application.Models;
using StudentsCoursesManager.Data.Entities;

namespace StudentsCoursesManager.Application.Commands.CourseCommands
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
