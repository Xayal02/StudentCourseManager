﻿using FluentValidation;
using StudentsCoursesManager.Application.Models;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Infrastructure.Repositories;

namespace StudentsCoursesManager.Application.Validators
{
    public class StudentCourseValidator : AbstractValidator<StudentCourseModel>
    {
        IUnitOfWork _unitOfWork;
        public StudentCourseValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(sc => sc.StudentId)
                .MustAsync(IsStudentExistAsync)
                .WithMessage(sc => $"Student with {sc.StudentId} id doesn't exist");

            RuleFor(sc => sc.CourseId)
                .MustAsync(IsCourseExistAsync)
                .WithMessage(sc => $"Course with {sc.CourseId} id doesn't exist");

        }

        //check student id is valid or not

        private async Task<bool> IsStudentExistAsync(int studentId, CancellationToken cancellationToken)
        {
            var students = await _unitOfWork.StudentRepository.GetAllList();
            bool determiner = students.Any(s => s.Id == studentId);
            return determiner;
        }

        //check course id is valid or not
        private async Task<bool> IsCourseExistAsync(int courseId, CancellationToken cancellationToken)
        {
            var courses = await _unitOfWork.CourseRepository.GetAllList();
            return courses.Any(c => c.Id == courseId);
        }
    }
}
