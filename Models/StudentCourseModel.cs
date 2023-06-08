using MediatR;

namespace StudentsCoursesManager.Models
{
    public class StudentCourseModel : IRequest
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
