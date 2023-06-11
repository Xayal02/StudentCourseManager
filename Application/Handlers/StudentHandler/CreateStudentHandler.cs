using AutoMapper;
using MediatR;
using StudentsCoursesManager.Commands.StudentCommands;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Infrastructure.Repositories;
using StudentsCoursesManager.Models;

namespace StudentsCoursesManager.Application.Handlers.StudentHandler
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, Student>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateStudentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Student> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<Student>(request.StudentModel);
            await _unitOfWork.StudentRepository.Add(student);
            await _unitOfWork.Save();

            return student;
        }
    }
}
