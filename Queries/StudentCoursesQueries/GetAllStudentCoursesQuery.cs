using MediatR;
using StudentsCoursesManager.Models;

namespace StudentsCoursesManager.Queries.StudentCoursesQueries
{
    public class GetAllStudentCoursesQuery : IRequest<List<object>>
    {
    }
}
