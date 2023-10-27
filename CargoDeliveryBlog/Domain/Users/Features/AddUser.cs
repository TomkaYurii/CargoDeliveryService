namespace CargoDeliveryBlog.Domain.Users.Features;

using CargoDeliveryBlog.Domain.Users.Services;
using CargoDeliveryBlog.Domain.Users;
using CargoDeliveryBlog.Domain.Users.Dtos;
using CargoDeliveryBlog.Domain.Users.Models;
using CargoDeliveryBlog.Services;
using CargoDeliveryBlog.Exceptions;
using Mappings;
using MediatR;

public static class AddUser
{
    public sealed record Command(UserForCreationDto UserToAdd) : IRequest<UserDto>;

    public sealed class Handler : IRequestHandler<Command, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var userToAdd = request.UserToAdd.ToUserForCreation();
            var user = User.Create(userToAdd);

            await _userRepository.Add(user, cancellationToken);
            await _unitOfWork.CommitChanges(cancellationToken);

            return user.ToUserDto();
        }
    }
}