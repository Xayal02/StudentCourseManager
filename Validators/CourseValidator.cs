using FluentValidation;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Models;

namespace StudentsCoursesManager.Data.Validators
{
    public class CourseValidator : AbstractValidator<CourseModel>
    {
        public CourseValidator()
        {
            RuleFor(c => c.Name)
                .MaximumLength(40)
                .NotEmpty();

        }

    }
}
