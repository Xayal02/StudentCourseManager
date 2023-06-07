using FluentValidation;
using StudentsCoursesManager.Data.Common;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Data.UnitOfWork;
using StudentsCoursesManager.Models;

namespace StudentsCoursesManager.Data.Validators
{
    public class StudentCourseValidators:AbstractValidator<StudentCourseModel>
    {
        IUnitOfWork _unitOfWork;
        public StudentCourseValidators(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            //RuleFor(sc => sc.StudentId)
            //    .MustAsync(IsStudentExistAsync)
            //    .WithMessage(sc=> $"Student with {sc.StudentId} id doesn't exist");

            //RuleFor(sc => sc.CourseId)
            //    .MustAsync(IsCourseExistAsync)
            //    .WithMessage(sc=> $"Course with {sc.CourseId} id doesn't exist");

        }

        //check student id is valid or not

        private async Task<bool> IsStudentExistAsync(int studentId, CancellationToken cancellationToken)
        {
            var students = await _unitOfWork.StudentRepository.GetAllList();
            return students.Any(s => s.Id == studentId);
        }

        //check course id is valir or not
        private async Task<bool> IsCourseExistAsync(int courseId, CancellationToken cancellationToken)
        {
            var courses = await _unitOfWork.CourseRepository.GetAllList();
            return courses.Any(c => c.Id == courseId);
        }
    }
}
