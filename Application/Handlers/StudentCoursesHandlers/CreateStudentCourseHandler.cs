using AutoMapper;
using MediatR;
using StudentsCoursesManager.Application.Commands.StudentCourseCommands;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Infrastructure.Repositories;

namespace StudentsCoursesManager.Application.Handlers.StudentCoursesHandlers
{
    public class CreateStudentCourseHandler : IRequestHandler<CreateStudentCourseCommand, StudentCourse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CreateStudentCourseHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<StudentCourse> Handle(CreateStudentCourseCommand request, CancellationToken cancellationToken)
        {
            var studentCourse = _mapper.Map<StudentCourse>(request.StudentCourseModel);

            await _unitOfWork.StudentCourseRepository.Add(studentCourse);
            await _unitOfWork.Save();
            _logger.LogInformation($"Student Course  with id {studentCourse.Id} was created");

            return studentCourse;
        }
    }
}
