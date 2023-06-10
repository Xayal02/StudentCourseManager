using MediatR;
using StudentsCoursesManager.Models;

namespace StudentsCoursesManager.Queries.UserQueries
{
    public class GetAllUsersQuery:IRequest<List<UserModel>>
    {
    }
}
