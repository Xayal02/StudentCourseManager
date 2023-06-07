using StudentsCoursesManager.Data.Common;

namespace StudentsCoursesManager.Data.Entities
{
    public class Student : BaseEntity<int>
    {
        public override int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }
        public int GenderId { get; set; }
        public string Email { get; set; }

        public IEnumerable<StudentCourse> StudentCourses { get; set; }

    }
}
