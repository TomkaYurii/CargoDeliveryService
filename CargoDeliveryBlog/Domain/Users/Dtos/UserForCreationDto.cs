namespace CargoDeliveryBlog.Domain.Users.Dtos;

using Destructurama.Attributed;

public sealed record UserForCreationDto
{
    public string UserName { get; set; }
    public string Email { get; set; }
}
