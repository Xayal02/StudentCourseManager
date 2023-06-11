using MediatR;

namespace StudentsCoursesManager.Application.Queries.StudentCoursesQueries
{
    public class GetAllStudentCoursesByCourseIdQuery : IRequest<List<object>>
    {
        public int CourseId { get; set; }

        public GetAllStudentCoursesByCourseIdQuery(int courseId)
        {
            CourseId = courseId;
        }
    }
}
