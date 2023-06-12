using MediatR;
using StudentsCoursesManager.Application.Models;
using StudentsCoursesManager.Data.Entities;

namespace StudentsCoursesManager.Application.Commands.StudentCourseCommands
{
    public class UpdateStudentCourseCommand : IRequest<StudentCourse>
    {
        public int Id { get; set; }
        public StudentCourseModel StudentCourseModel { get; set; }
        public UpdateStudentCourseCommand(int id, StudentCourseModel studentCourseModel)
        {
            Id = id;
            StudentCourseModel = studentCourseModel;
        }
    }
}
