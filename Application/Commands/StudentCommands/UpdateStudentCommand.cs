using MediatR;
using StudentsCoursesManager.Application.Models;

namespace StudentsCoursesManager.Application.Commands.StudentCommands
{
    public class UpdateStudentCommand : IRequest
    {
        public StudentModel StudentModel { get; set; }
        public int Id { get; set; }
        public UpdateStudentCommand(StudentModel studentModel, int id)
        {
            StudentModel = studentModel;
            Id = id;
        }
    }
}
