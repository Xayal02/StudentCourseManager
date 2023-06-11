using MediatR;
using StudentsCoursesManager.Data.Entities;

namespace StudentsCoursesManager.Application.Models
{
    public class CourseModel : IRequest<Course>
    {
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
