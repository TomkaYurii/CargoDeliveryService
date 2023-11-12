namespace CargoDeliveryBlog.Domain.Users.Models;

using Destructurama.Attributed;

public sealed class UserForCreation
{
    public string UserName { get; set; }
    public string Email { get; set; }
}