using AutoMapper;
using Azure.Core;
using MediatR;
using StudentsCoursesManager.Commands.StudentCommands;
using StudentsCoursesManager.Infrastructure.Repositories;

namespace StudentsCoursesManager.Application.Handlers.StudentHandler
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteStudentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _unitOfWork.StudentRepository.Find(request.Id);
            await _unitOfWork.StudentRepository.Delete(student);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
