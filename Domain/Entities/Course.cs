using StudentsCoursesManager.Domain.Common;

namespace StudentsCoursesManager.Data.Entities
{
    public class Course : BaseEntity<int>
    {
        public override int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
        public IEnumerable<StudentCourse> StudentsCourses { get; set; }
    }
}
