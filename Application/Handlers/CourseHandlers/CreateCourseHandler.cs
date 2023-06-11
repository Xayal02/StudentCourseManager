using AutoMapper;
using MediatR;
using StudentsCoursesManager.Application.Commands.CourseCommands;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Infrastructure.Repositories;

namespace StudentsCoursesManager.Application.Handlers.CourseHandlers
{
    public class CreateCourseHandler : IRequestHandler<CreateCourseCommand, Course>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCourseHandler> _logger;

        public CreateCourseHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateCourseHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Course> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = _mapper.Map<Course>(request.CourseModel);

            await _unitOfWork.CourseRepository.Add(course);
            await _unitOfWork.Save();
            _logger.LogWarning("Course created");


            return course;

        }
    }
}
