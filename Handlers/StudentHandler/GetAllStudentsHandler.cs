using AutoMapper;
using MediatR;
using StudentsCoursesManager.Commands.CourseCommands;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Models;
using StudentsCoursesManager.Persistence;
using AutoMapper;
using MediatR;
using StudentsCoursesManager.Models;
using StudentsCoursesManager.Persistence;
using StudentsCoursesManager.Queries.CourseQueries;
using StudentsCoursesManager.Queries.StudentQueries;

namespace StudentsCoursesManager.Handlers.StudentHandler
{
    public class GetAllStudentsHandler:IRequestHandler<GetAllStudentsQuery,List<StudentModel>>
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
