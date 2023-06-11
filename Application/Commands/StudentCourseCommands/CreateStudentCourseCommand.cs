using MediatR;
using StudentsCoursesManager.Application.Models;
using StudentsCoursesManager.Data.Entities;

namespace StudentsCoursesManager.Application.Commands.StudentCourseCommands
{
    public class CreateStudentCourseCommand : IRequest<StudentCourse>
    {
        public StudentCourseModel StudentCourseModel { get; set; }
        public CreateStudentCourseCommand(StudentCourseModel studentCourseModel)
        {

            StudentCourseModel = studentCourseModel;

        }
    }
}
