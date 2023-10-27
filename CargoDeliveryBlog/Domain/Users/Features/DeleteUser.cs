namespace CargoDeliveryBlog.Domain.Users.Features;

using CargoDeliveryBlog.Domain.Users.Services;
using CargoDeliveryBlog.Services;
using CargoDeliveryBlog.Exceptions;
using MediatR;

public static class DeleteUser
{
    public sealed record Command(Guid UserId) : IRequest;

    public sealed class Handler : IRequestHandler<Command>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await _userRepository.GetById(request.UserId, cancellationToken: cancellationToken);
            _userRepository.Remove(recordToDelete);
            await _unitOfWork.CommitChanges(cancellationToken);
        }
    }
}