using AutoMapper;
using MediatR;
using StudentsCoursesManager.Models;
using StudentsCoursesManager.Persistence;
using StudentsCoursesManager.Queries.UserQueries;

namespace StudentsCoursesManager.Handlers.UserHandlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<UserModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllUsersHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<UserModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.UserRepository.GetAllList();
            var userModels = users.Select(user => _mapper.Map<UserModel>(user)).ToList();

            return userModels;
        }
    }
}
