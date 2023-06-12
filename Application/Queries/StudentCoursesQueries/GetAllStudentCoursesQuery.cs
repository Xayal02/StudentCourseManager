using MediatR;

namespace StudentsCoursesManager.Application.Queries.StudentCoursesQueries
{
    public class GetAllStudentCoursesQuery : IRequest<List<object>>
    {
    }
}
