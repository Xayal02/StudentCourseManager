using MediatR;

namespace StudentsCoursesManager.Commands.CourseCommands
{
    public class DeleteCourseCommand : IRequest
    {
        public int Id { get; set; }
        public DeleteCourseCommand(int id)
        {
            Id = id;
        }
    }
}
