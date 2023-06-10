using MediatR;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Models;

namespace StudentsCoursesManager.Commands.StudentCourseCommands
{
    public class CreateStudentCourseCommand :IRequest<StudentCourse>
    {
        public StudentCourseModel StudentCourseModel { get; set; }
        public CreateStudentCourseCommand(StudentCourseModel studentCourseModel)
        {

            StudentCourseModel = studentCourseModel;

        }
    }
}
