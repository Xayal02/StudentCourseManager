using AutoMapper;
using MediatR;
using StudentsCoursesManager.Commands.StudentCourseCommands;
using StudentsCoursesManager.Infrastructure.Repositories;

namespace StudentsCoursesManager.Application.Handlers.StudentCoursesHandlers
{
    public class DeleteStudentCourseHandler : IRequestHandler<DeleteStudentCourseCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteStudentCourseHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteStudentCourseCommand request, CancellationToken cancellationToken)
        {
            var studentCourse = await _unitOfWork.StudentCourseRepository.Find(request.Id);
            await _unitOfWork.StudentCourseRepository.Delete(studentCourse);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
