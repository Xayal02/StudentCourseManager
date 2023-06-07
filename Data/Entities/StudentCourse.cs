using StudentsCoursesManager.Data.Common;

namespace StudentsCoursesManager.Data.Entities
{
    public class StudentCourse : BaseEntity<int>
    {
        public override int Id { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
      

    }
}
