using MediatR;
using StudentsCoursesManager.Application.Models;

namespace StudentsCoursesManager.Application.Queries.UserQueries
{
    public class GetUserByIdQuery : IRequest<UserModel>
    {
        public int UserId { get; set; }
        public GetUserByIdQuery(int userId)
        {
            UserId = userId;
        }
    }
}
