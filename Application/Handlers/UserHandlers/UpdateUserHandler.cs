using AutoMapper;
using MediatR;
using StudentsCoursesManager.Application.Commands.UserCommands;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Infrastructure.Repositories;

namespace StudentsCoursesManager.Application.Handlers.UserHandlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateUserHandler> _logger;

        public UpdateUserHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateUserHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.Find(request.UserId);

            //Check if such username has been taken or not
            if (request.UserModel.UserName != user.UserName &&
                await _unitOfWork.UserRepository.Any(user => user.UserName == request.UserModel.UserName))

                return null;

            _mapper.Map(request.UserModel, user);
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            await _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.Save();
            _logger.LogInformation($"User with id {user.Id} was updated");

            return user;
        }
    }
}
