using AutoMapper;
using MediatR;
using StudentsCoursesManager.Commands.StudentCommands;
using StudentsCoursesManager.Models;
using StudentsCoursesManager.Persistence;

namespace StudentsCoursesManager.Handlers.StudentHandler
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateStudentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _unitOfWork.StudentRepository.Find(request.Id);
            _mapper.Map(request.StudentModel, student);
            await _unitOfWork.StudentRepository.Update(student);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
