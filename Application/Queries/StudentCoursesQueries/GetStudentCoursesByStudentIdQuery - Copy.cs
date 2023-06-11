using MediatR;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Models;

namespace StudentsCoursesManager.Application.Queries.StudentCoursesQueries
{
    public class GetAllStudentCoursesQueryByStudentId : IRequest<List<object>>
    {
        public int StudentId { get; set; }
        public GetAllStudentCoursesQueryByStudentId(int studentId)
        {

            StudentId = studentId;

        }
    }
}
