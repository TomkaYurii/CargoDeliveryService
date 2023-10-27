namespace CargoDeliveryBlog.Domain.Users.Features;

using CargoDeliveryBlog.Domain.Users.Dtos;
using CargoDeliveryBlog.Domain.Users.Services;
using CargoDeliveryBlog.Exceptions;
using Mappings;
using MediatR;

public static class GetUser
{
    public sealed record Query(Guid UserId) : IRequest<UserDto>;

    public sealed class Handler : IRequestHandler<Query, UserDto>
    {
        private readonly IUserRepository _userRepository;

        public Handler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetById(request.UserId, cancellationToken: cancellationToken);
            return result.ToUserDto();
        }
    }
}