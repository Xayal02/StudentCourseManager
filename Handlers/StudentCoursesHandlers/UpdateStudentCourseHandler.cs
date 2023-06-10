using AutoMapper;
using MediatR;
using StudentsCoursesManager.Commands.StudentCourseCommands;
using StudentsCoursesManager.Data.Validators;
using StudentsCoursesManager.Models;
using StudentsCoursesManager.Persistence;

namespace StudentsCoursesManager.Handlers.StudentCoursesHandlers
{
    public class UpdateStudentCourseHandler : IRequestHandler<UpdateStudentCourseCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateStudentCourseHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateStudentCourseCommand request, CancellationToken cancellationToken)
        {
            var studentCourse = await _unitOfWork.StudentCourseRepository.Find(request.Id);
            _mapper.Map(request.StudentCourseModel, studentCourse);
            await _unitOfWork.StudentCourseRepository.Update(studentCourse);
            await _unitOfWork.Save();

            return Unit.Value;

        }
    }
}
