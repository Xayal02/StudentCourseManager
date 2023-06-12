using AutoMapper;
using MediatR;
using StudentsCoursesManager.Application.Commands.StudentCommands;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Infrastructure.Repositories;

namespace StudentsCoursesManager.Application.Handlers.StudentHandler
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, Student>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateStudentHandler> _logger;

        public CreateStudentHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateStudentHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Student> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<Student>(request.StudentModel);
            await _unitOfWork.StudentRepository.Add(student);
            await _unitOfWork.Save();
            _logger.LogInformation($"Student with id {student.Id} was created");

            return student;
        }
    }
}
