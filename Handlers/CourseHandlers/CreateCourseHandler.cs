using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentsCoursesManager.Commands;
using StudentsCoursesManager.Commands.CourseCommands;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Data.Validators;
using StudentsCoursesManager.Models;
using StudentsCoursesManager.Persistence;

namespace StudentsCoursesManager.Handlers.CourseHandlers
{
    public class CreateCourseHandler : IRequestHandler<CreateCourseCommand, Course>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCourseHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Course> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = _mapper.Map<Course>(request.CourseModel);

            await _unitOfWork.CourseRepository.Add(course);
            await _unitOfWork.Save();

            return course;

        }
    }
}
