using MediatR;
using StudentsCoursesManager.Models;

namespace StudentsCoursesManager.Queries.UserQueries
{
    public class GetUserByIdQuery:IRequest<UserModel>
    {
        public int UserId { get; set;}
        public GetUserByIdQuery(int userId)
        {
            UserId = userId;
        }
    }
}
