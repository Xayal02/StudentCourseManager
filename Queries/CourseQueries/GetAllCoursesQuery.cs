using MediatR;
using StudentsCoursesManager.Models;

namespace StudentsCoursesManager.Queries.CourseQueries
{
    public class GetAllCoursesQuery : IRequest<List<CourseModel>>
    {
    }
}
