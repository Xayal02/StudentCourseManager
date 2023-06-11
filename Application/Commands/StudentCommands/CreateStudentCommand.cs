using MediatR;
using StudentsCoursesManager.Application.Models;
using StudentsCoursesManager.Data.Entities;

namespace StudentsCoursesManager.Application.Commands.StudentCommands
{
    public class CreateStudentCommand : IRequest<Student>
    {
        public StudentModel StudentModel { get; set; }
        public CreateStudentCommand(StudentModel studentModel)
        {
            StudentModel = studentModel;
        }
    }
}
