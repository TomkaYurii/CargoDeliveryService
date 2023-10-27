namespace CargoDeliveryBlog.Domain.Users.Dtos;

using Destructurama.Attributed;

public sealed record UserDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
}
