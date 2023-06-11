using MediatR;
using StudentsCoursesManager.Application.Models;

namespace StudentsCoursesManager.Application.Queries.UserQueries
{
    public class GetAllUsersQuery : IRequest<List<UserModel>>
    {
    }
}
