namespace CargoDeliveryBlog.Domain.Users.Features;

using CargoDeliveryBlog.Domain.Users;
using CargoDeliveryBlog.Domain.Users.Dtos;
using CargoDeliveryBlog.Domain.Users.Services;
using CargoDeliveryBlog.Services;
using CargoDeliveryBlog.Domain.Users.Models;
using CargoDeliveryBlog.Exceptions;
using Mappings;
using MediatR;

public static class UpdateUser
{
    public sealed record Command(Guid UserId, UserForUpdateDto UpdatedUserData) : IRequest;

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
            var userToUpdate = await _userRepository.GetById(request.UserId, cancellationToken: cancellationToken);
            var userToAdd = request.UpdatedUserData.ToUserForUpdate();
            userToUpdate.Update(userToAdd);

            _userRepository.Update(userToUpdate);
            await _unitOfWork.CommitChanges(cancellationToken);
        }
    }
}