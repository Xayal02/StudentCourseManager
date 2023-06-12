using AutoMapper;
using MediatR;
using StudentsCoursesManager.Application.Models;
using StudentsCoursesManager.Infrastructure.Repositories;
using StudentsCoursesManager.Application.Queries.StudentQueries;

namespace StudentsCoursesManager.Application.Handlers.StudentHandler
{
    public class GetAllStudentsHandler : IRequestHandler<GetAllStudentsQuery, List<StudentModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllStudentsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<StudentModel>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _unitOfWork.StudentRepository.GetAllList();
            var studentModels = students.Select(student => _mapper.Map<StudentModel>(student)).ToList();

            return studentModels;
        }
    }
}
