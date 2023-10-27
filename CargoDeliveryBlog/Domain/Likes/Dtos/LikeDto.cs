namespace CargoDeliveryBlog.Domain.Likes.Dtos;

using Destructurama.Attributed;

public sealed record LikeDto
{
    public Guid Id { get; set; }
    public string Text { get; set; }
}
