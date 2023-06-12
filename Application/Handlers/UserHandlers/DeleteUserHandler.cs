using AutoMapper;
using MediatR;
using StudentsCoursesManager.Application.Commands.UserCommands;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Infrastructure.Repositories;

namespace StudentsCoursesManager.Application.Handlers.UserHandlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, User>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeleteUserHandler> _logger;


        public DeleteUserHandler(IUnitOfWork unitOfWork, ILogger<DeleteUserHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<User> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.Find(request.UserId);
            await _unitOfWork.UserRepository.Delete(user);
            await _unitOfWork.Save();
            _logger.LogInformation($"User with id {user.Id} was deleted from database");

            return user;
        }
    }
}
