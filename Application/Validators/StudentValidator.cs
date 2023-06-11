using FluentValidation;
using StudentsCoursesManager.Application.Models;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Infrastructure.Repositories;
using System.Globalization;
using System.Text.RegularExpressions;

namespace StudentsCoursesManager.Application.Validators
{
    public class StudentValidator : AbstractValidator<StudentModel>
    {
        IUnitOfWork _unitOfWork;

        public StudentValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(s => s.FirstName)
                .MinimumLength(3)
                .MaximumLength(15)
                .NotEmpty();

            RuleFor(s => s.LastName)
                .MinimumLength(3)
                .MaximumLength(20)
                .NotEmpty();

            RuleFor(s => s.Email)
                .EmailAddress()
                .NotEmpty();

            RuleFor(s => s.GenderId)
                .NotEmpty()
                .MustAsync(IsGenderTypeExistAsync)
                .WithMessage("Invalid gender type");
        }
        private async Task<bool> IsGenderTypeExistAsync(int genderId, CancellationToken cancellationToken)
        {
            var genders = await _unitOfWork.GenderRepository.GetAllList();
            return genders.Any(g => g.Id == genderId);
        }
    }

}
