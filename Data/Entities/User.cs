using StudentsCoursesManager.Data.Common;

namespace StudentsCoursesManager.Data.Entities
{
    public class User:BaseEntity<int>
    {
        public override int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
