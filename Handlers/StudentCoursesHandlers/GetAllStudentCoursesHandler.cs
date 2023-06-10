using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Models;
using StudentsCoursesManager.Persistence;
using StudentsCoursesManager.Queries.StudentCoursesQueries;
using StudentsCoursesManager.Queries.StudentQueries;

namespace StudentsCoursesManager.Handlers.StudentCoursesHandlers
{
    public class GetAllStudentCoursesHandler : IRequestHandler<GetAllStudentCoursesQuery,List<object>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllStudentCoursesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<object>> Handle(GetAllStudentCoursesQuery request, CancellationToken cancellationToken)
        {
            var allCourses = _unitOfWork.StudentCourseRepository.GetAll();

            var studentCourses = await allCourses.Select(sc => new
            {
                sc.StartDate,
                sc.EndDate,
                StudentFullName = (sc.Student.FirstName + " " + sc.Student.LastName),
                Courses = new
                {
                    CourseName = sc.Course.Name
                }
            }).ToListAsync<object>();

            return studentCourses;
        }
    }
}
