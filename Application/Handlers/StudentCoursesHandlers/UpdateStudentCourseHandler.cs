using AutoMapper;
using MediatR;
using StudentsCoursesManager.Application.Commands.StudentCourseCommands;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Infrastructure.Repositories;

namespace StudentsCoursesManager.Application.Handlers.StudentCoursesHandlers
{
    public class UpdateStudentCourseHandler : IRequestHandler<UpdateStudentCourseCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateStudentCourseHandler> _logger;

        public UpdateStudentCourseHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateStudentCourseHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Unit> Handle(UpdateStudentCourseCommand request, CancellationToken cancellationToken)
        {
            var studentCourse = await _unitOfWork.StudentCourseRepository.Find(request.Id);
            _mapper.Map(request.StudentCourseModel, studentCourse);
            await _unitOfWork.StudentCourseRepository.Update(studentCourse);
            await _unitOfWork.Save();
            _logger.LogInformation($"Student Course with id {studentCourse.Id} was updated");

            return Unit.Value;

        }
    }
}
