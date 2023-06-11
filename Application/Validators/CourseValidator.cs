using FluentValidation;
using StudentsCoursesManager.Application.Models;
using StudentsCoursesManager.Data.Entities;

namespace StudentsCoursesManager.Application.Validators
{
    public class CourseValidator : AbstractValidator<CourseModel>
    {
        public CourseValidator()
        {
            RuleFor(c => c.Name)
                .MinimumLength(10)
                .MaximumLength(40)
                .NotEmpty();

        }

    }
}
