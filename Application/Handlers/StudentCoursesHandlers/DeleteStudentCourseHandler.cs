using AutoMapper;
using MediatR;
using StudentsCoursesManager.Application.Commands.StudentCourseCommands;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Infrastructure.Repositories;

namespace StudentsCoursesManager.Application.Handlers.StudentCoursesHandlers
{
    public class DeleteStudentCourseHandler : IRequestHandler<DeleteStudentCourseCommand,StudentCourse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteStudentCourseHandler> _logger;

        public DeleteStudentCourseHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteStudentCourseHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<StudentCourse> Handle(DeleteStudentCourseCommand request, CancellationToken cancellationToken)
        {
            var studentCourse = await _unitOfWork.StudentCourseRepository.Find(request.Id);
            if (studentCourse is null) return null;

            await _unitOfWork.StudentCourseRepository.Delete(studentCourse);
            await _unitOfWork.Save();
            _logger.LogInformation($"Student Course with id {studentCourse.Id} was deleted from database");
            return studentCourse;
        }
    }
}
