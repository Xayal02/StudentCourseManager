using MediatR;
using StudentsCoursesManager.Models;

namespace StudentsCoursesManager.Queries.StudentQueries
{
    public  class GetAllStudentsQuery :IRequest<List<StudentModel>>
    {

    }
}