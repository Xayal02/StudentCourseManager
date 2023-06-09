using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using StudentsCoursesManager.Models;

namespace StudentsCoursesManager.Validators
{
    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator()
        {
            RuleFor(u => u.UserName)
                .MaximumLength(15)
                .NotEmpty();

            RuleFor(u => u.Password)
                .NotEmpty();

            RuleFor(u => u.DateOfBirth)
                .NotEmpty();

            RuleFor(u => u.Email)
                .EmailAddress()
                .NotEmpty();


            RuleFor(u => u.Role)
                .NotEmpty();

            RuleFor(u => u.FirstName)
               .MaximumLength(15)
               .NotEmpty();

            RuleFor(u => u.LastName)
               .MaximumLength(25)
               .NotEmpty();
        }
    }
}
