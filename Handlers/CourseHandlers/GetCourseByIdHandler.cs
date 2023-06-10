﻿using AutoMapper;
using MediatR;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Models;
using StudentsCoursesManager.Persistence;
using StudentsCoursesManager.Queries.CourseQueries;

namespace StudentsCoursesManager.Handlers.CourseHandlers
{
    public class GetCourseByIdHandler : IRequestHandler<GetCourseByIdQuery, CourseModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCourseByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CourseModel> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var course = await _unitOfWork.CourseRepository.Find(request.Id);

            return course == null ? null : _mapper.Map<CourseModel>(course);
        }
    }
}
