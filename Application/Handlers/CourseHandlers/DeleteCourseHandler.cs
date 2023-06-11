using AutoMapper;
using MediatR;
using StudentsCoursesManager.Commands;
using StudentsCoursesManager.Commands.CourseCommands;
using StudentsCoursesManager.Infrastructure.Repositories;

namespace StudentsCoursesManager.Application.Handlers.CourseHandlers
{
    public class DeleteCourseHandler : IRequestHandler<DeleteCourseCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCourseHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _unitOfWork.CourseRepository.Find(request.Id);
            await _unitOfWork.CourseRepository.Delete(course);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
