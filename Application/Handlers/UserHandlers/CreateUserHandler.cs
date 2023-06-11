using AutoMapper;
using MediatR;
using StudentsCoursesManager.Commands.UserCommands;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Infrastructure.Repositories;
using StudentsCoursesManager.Models;

namespace StudentsCoursesManager.Application.Handlers.UserHandlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.UserRepository.Any(user => user.UserName == request.UserModel.UserName))
                return null;

            var user = _mapper.Map<User>(request.UserModel);
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            await _unitOfWork.UserRepository.Add(user);
            await _unitOfWork.Save();

            return user;
        }
    }
}
