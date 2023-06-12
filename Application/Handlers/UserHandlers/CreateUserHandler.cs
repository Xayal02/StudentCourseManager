using AutoMapper;
using MediatR;
using StudentsCoursesManager.Application.Commands.UserCommands;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Infrastructure.Repositories;

namespace StudentsCoursesManager.Application.Handlers.UserHandlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateUserHandler> _logger;

        public CreateUserHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateUserHandler> loggger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = loggger;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.UserRepository.Any(user => user.UserName == request.UserModel.UserName))
                return null;

            var user = _mapper.Map<User>(request.UserModel);
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            await _unitOfWork.UserRepository.Add(user);
            await _unitOfWork.Save();
            _logger.LogInformation($"User with id {user.Id} was created");

            return user;
        }
    }
}
