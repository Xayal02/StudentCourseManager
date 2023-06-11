using MediatR;
using StudentsCoursesManager.Application.Models;

namespace StudentsCoursesManager.Application.Queries.CourseQueries
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
