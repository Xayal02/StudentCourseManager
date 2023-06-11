using AutoMapper;
using MediatR;
using StudentsCoursesManager.Application.Models;
using StudentsCoursesManager.Infrastructure.Repositories;
using StudentsCoursesManager.Queries.CourseQueries;

namespace StudentsCoursesManager.Application.Handlers.CourseHandlers
{
    public class GetAllCoursesHandler : IRequestHandler<GetAllCoursesQuery, List<CourseModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCoursesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CourseModel>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await _unitOfWork.CourseRepository.GetAllList();
            var courseModels = courses.Select(course => _mapper.Map<CourseModel>(course)).ToList();

            return courseModels;
        }
    }
}
