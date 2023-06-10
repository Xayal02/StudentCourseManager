using AutoMapper;
using MediatR;
using StudentsCoursesManager.Commands;
using StudentsCoursesManager.Commands.CourseCommands;
using StudentsCoursesManager.Models;
using StudentsCoursesManager.Persistence;

namespace StudentsCoursesManager.Handlers.CourseHandlers
{
    public class UpdateCourseHandler : IRequestHandler<UpdateCourseCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCourseHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {

            var course = await _unitOfWork.CourseRepository.Find(request.Id);

            _mapper.Map(request.CourseModel, course);

            await _unitOfWork.CourseRepository.Update(course);
            await _unitOfWork.Save();
            var value = Unit.Value;
            return value;
        }
    }
}
