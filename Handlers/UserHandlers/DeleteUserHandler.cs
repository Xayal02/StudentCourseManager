using AutoMapper;
using MediatR;
using StudentsCoursesManager.Commands.UserCommands;
using StudentsCoursesManager.Persistence;

namespace StudentsCoursesManager.Handlers.UserHandlers
{
    public class DeleteUserHandler:IRequestHandler<DeleteUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
