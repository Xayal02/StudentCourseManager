using MediatR;
using StudentsCoursesManager.Application.Models;
using StudentsCoursesManager.Data.Entities;

namespace StudentsCoursesManager.Application.Commands.StudentCommands
{
    public class UpdateStudentCommand : IRequest<Student>
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
