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

        public CreateStudentCourseHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<StudentCourse> Handle(CreateStudentCourseCommand request, CancellationToken cancellationToken)
        {
            var studentCourse = _mapper.Map<StudentCourse>(request.StudentCourseModel);

            await _unitOfWork.StudentCourseRepository.Add(studentCourse);
            await _unitOfWork.Save();

            return studentCourse;
        }
    }
}
