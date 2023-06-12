using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentsCoursesManager.Application.Queries.StudentCoursesQueries;
using StudentsCoursesManager.Infrastructure.Repositories;

namespace StudentsCoursesManager.Application.Handlers.StudentCoursesHandlers
{
    public class GetAllStudentCoursesByCourseIdHandler : IRequestHandler<GetAllStudentCoursesByCourseIdQuery, List<object>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllStudentCoursesByCourseIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<object>> Handle(GetAllStudentCoursesByCourseIdQuery request, CancellationToken cancellationToken)
        {
            var allcourses = _unitOfWork.StudentCourseRepository.GetAll();

            var studentCourses = await allcourses
                .Where(sc => sc.StudentId == request.CourseId)
                .Select(sc => new
                {
                    sc.StartDate,
                    sc.EndDate,
                    StudentFullName = sc.Student.FirstName + " " + sc.Student.LastName,
                    Courses = sc.Course.Name
                }).ToListAsync<object>();

            return studentCourses;
        }
    }
}
