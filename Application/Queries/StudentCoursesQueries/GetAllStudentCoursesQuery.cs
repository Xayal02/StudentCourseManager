using MediatR;
using StudentsCoursesManager.Models;

namespace StudentsCoursesManager.Application.Queries.StudentCoursesQueries
{
    public class GetAllStudentCoursesQuery : IRequest<List<object>>
    {
    }
}
