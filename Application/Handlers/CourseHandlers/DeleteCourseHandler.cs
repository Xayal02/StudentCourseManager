using AutoMapper;
using MediatR;
using StudentsCoursesManager.Application.Commands.CourseCommands;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Infrastructure.Repositories;

namespace StudentsCoursesManager.Application.Handlers.CourseHandlers
{
    public class DeleteCourseHandler : IRequestHandler<DeleteCourseCommand,Course>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteCourseHandler> _logger;

        public DeleteCourseHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteCourseHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Course> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _unitOfWork.CourseRepository.Find(request.Id);
            if (course is null) return null;

            await _unitOfWork.CourseRepository.Delete(course);
            await _unitOfWork.Save();
            _logger.LogInformation($"Course with id {course.Id} was deleted from database");
            return course;
            
        }
    }
}
