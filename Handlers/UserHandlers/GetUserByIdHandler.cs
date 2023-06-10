using AutoMapper;
using MediatR;
using StudentsCoursesManager.Models;
using StudentsCoursesManager.Persistence;
using StudentsCoursesManager.Queries.UserQueries;

namespace StudentsCoursesManager.Handlers.UserHandlers
{
    public class GetUserByIdHandler:IRequestHandler<GetUserByIdQuery,UserModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async  Task<UserModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.Find(request.UserId);
            var userModel = _mapper.Map<UserModel>(user);

            return userModel;
        }
    }
}
