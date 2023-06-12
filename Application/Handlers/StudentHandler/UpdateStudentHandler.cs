using AutoMapper;
using MediatR;
using StudentsCoursesManager.Application.Commands.StudentCommands;
using StudentsCoursesManager.Infrastructure.Repositories;

namespace StudentsCoursesManager.Application.Handlers.StudentHandler
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateStudentHandler> _logger;

        public UpdateStudentHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateStudentHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _unitOfWork.StudentRepository.Find(request.Id);
            _mapper.Map(request.StudentModel, student);
            await _unitOfWork.StudentRepository.Update(student);
            await _unitOfWork.Save();
            _logger.LogInformation($"Student with id {student.Id} was updated");

            return Unit.Value;
        }
    }
}
