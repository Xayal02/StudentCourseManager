using AutoMapper;
using MediatR;
using StudentsCoursesManager.Application.Commands.CourseCommands;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Infrastructure.Repositories;

namespace StudentsCoursesManager.Application.Handlers.CourseHandlers
{
    public class UpdateCourseHandler : IRequestHandler<UpdateCourseCommand,Course>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCourseHandler> _logger;

        public UpdateCourseHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateCourseHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Course> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _unitOfWork.CourseRepository.Find(request.Id);
            if (course is null) return null;

            _mapper.Map(request.CourseModel, course);
            await _unitOfWork.CourseRepository.Update(course);
            await _unitOfWork.Save();
            _logger.LogInformation($"Course with id {course.Id} was updated");

            return course;
        }
    }
}
