using MediatR;
using StudentsCoursesManager.Data.Entities;

namespace StudentsCoursesManager.Application.Models
{
    public class StudentCourseModel : IRequest<StudentCourse>
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
