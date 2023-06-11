using MediatR;
using StudentsCoursesManager.Application.Models;

namespace StudentsCoursesManager.Application.Queries.StudentQueries
{
    public class GetAllStudentsQuery : IRequest<List<StudentModel>>
    {

    }
}