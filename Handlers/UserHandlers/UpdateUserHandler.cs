using AutoMapper;
using MediatR;
using StudentsCoursesManager.Commands.UserCommands;
using StudentsCoursesManager.Persistence;

namespace StudentsCoursesManager.Handlers.UserHandlers
{
    public class UpdateUserHandler:IRequestHandler<UpdateUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
