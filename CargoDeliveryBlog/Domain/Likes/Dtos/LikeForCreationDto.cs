namespace CargoDeliveryBlog.Domain.Likes.Dtos;

using Destructurama.Attributed;

public sealed record LikeForCreationDto
{
    public string Text { get; set; }
}
