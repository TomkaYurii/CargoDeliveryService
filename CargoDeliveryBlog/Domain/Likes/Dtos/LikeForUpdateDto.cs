namespace CargoDeliveryBlog.Domain.Likes.Dtos;

using Destructurama.Attributed;

public sealed record LikeForUpdateDto
{
    public string Text { get; set; }
}
