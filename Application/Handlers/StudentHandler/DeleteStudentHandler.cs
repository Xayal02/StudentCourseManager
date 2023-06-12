using AutoMapper;
using Azure.Core;
using MediatR;
using StudentsCoursesManager.Application.Commands.StudentCommands;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Infrastructure.Repositories;

namespace StudentsCoursesManager.Application.Handlers.StudentHandler
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, Student>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteStudentHandler> _logger;

        public DeleteStudentHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteStudentHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Student> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _unitOfWork.StudentRepository.Find(request.Id);
            if (student is null) return null;

            await _unitOfWork.StudentRepository.Delete(student);
            await _unitOfWork.Save();
            _logger.LogInformation($"Student with id {student.Id} was deleted from database");
            return student;
        }
    }
}
