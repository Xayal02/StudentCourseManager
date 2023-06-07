
using MediatR;
using StudentsCoursesManager.Data.Entities;

namespace StudentsCoursesManager.Models
{
    public class StudentModel : IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int GenderId { get; set; }
        public string Email { get; set; }
    }
}
