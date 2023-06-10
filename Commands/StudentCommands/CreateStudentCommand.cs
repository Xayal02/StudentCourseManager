using MediatR;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Models;

namespace StudentsCoursesManager.Commands.StudentCommands
{
    public class CreateStudentCommand:IRequest<Student>
    {
        public StudentModel StudentModel { get; set; }
        public CreateStudentCommand(StudentModel studentModel)
        {
            StudentModel = studentModel;
        }
    }
}
