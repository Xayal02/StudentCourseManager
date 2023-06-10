using MediatR;
using StudentsCoursesManager.Models;

namespace StudentsCoursesManager.Queries.CourseQueries
{
    public class GetCourseByIdQuery : IRequest<CourseModel>
    {
        public int Id { get; set; }
        public GetCourseByIdQuery(int id)
        {
            Id = id;
        }
    }
}
