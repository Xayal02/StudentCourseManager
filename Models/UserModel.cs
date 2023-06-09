using Microsoft.AspNetCore.Mvc;

namespace StudentsCoursesManager.Models
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Role { get; set; }
    }
}
