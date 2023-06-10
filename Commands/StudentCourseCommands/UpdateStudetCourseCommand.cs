using MediatR;
using StudentsCoursesManager.Models;

namespace StudentsCoursesManager.Commands.StudentCourseCommands
{
    public class UpdateStudentCourseCommand : IRequest
    {
        public int Id { get; set; }
        public StudentCourseModel StudentCourseModel { get; set; }
        public UpdateStudentCourseCommand(int id,StudentCourseModel studentCourseModel)
        {
            Id = id;
            StudentCourseModel = studentCourseModel;
        }
    }
}
