using MediatR;
using StudentsCoursesManager.Models;

namespace StudentsCoursesManager.Queries.StudentQueries
{
    public class GetStudentByIdQuery : IRequest<StudentModel>
    {
        public int Id { get; set; }
        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
