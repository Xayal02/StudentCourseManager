using MediatR;

namespace StudentsCoursesManager.Models
{
    public class CourseModel :IRequest
    {
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
