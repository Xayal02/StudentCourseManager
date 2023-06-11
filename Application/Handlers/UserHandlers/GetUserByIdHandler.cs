using AutoMapper;
using MediatR;
using StudentsCoursesManager.Application.Models;
using StudentsCoursesManager.Infrastructure.Repositories;
using StudentsCoursesManager.Queries.UserQueries;

namespace StudentsCoursesManager.Application.Handlers.UserHandlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.Find(request.UserId);
            var userModel = _mapper.Map<UserModel>(user);

            return userModel;
        }
    }
}
