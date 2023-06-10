using MediatR;
using StudentsCoursesManager.Models;

namespace StudentsCoursesManager.Commands.StudentCommands
{
    public class UpdateStudentCommand:IRequest
    {
        public StudentModel StudentModel { get; set; }
        public int Id { get; set; }
        public UpdateStudentCommand(StudentModel studentModel,int id)
        {
            StudentModel = studentModel;
            Id = id;
        }
    }
}
