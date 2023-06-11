using StudentsCoursesManager.Domain.Common;

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
        public DateTime DateOfBirth { get; set; }
        public int Age
        {
            get
            {
                int age = DateTime.Now.Year - DateOfBirth.Year;

                if (DateTime.Now.Date > DateOfBirth.Date) age--; //here we check if user's birthday has passed or not

                return age;
            }
        }
        public string Role { get; set; }
    }
}
