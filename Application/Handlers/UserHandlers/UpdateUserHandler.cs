using AutoMapper;
using MediatR;
using StudentsCoursesManager.Commands.UserCommands;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Infrastructure.Repositories;
using StudentsCoursesManager.Models;

namespace StudentsCoursesManager.Application.Handlers.UserHandlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

            return user;
        }
    }
}
