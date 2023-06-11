using MediatR;
using StudentsCoursesManager.Application.Models;

namespace StudentsCoursesManager.Application.Queries.CourseQueries
{
    public class GetAllCoursesQuery : IRequest<List<CourseModel>>
    {
    }
}
