using StudentsCoursesManager.Domain.Common;

namespace StudentsCoursesManager.Data.Entities
{
    public class Gender : BaseEntity<int>
    {
        public override int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}