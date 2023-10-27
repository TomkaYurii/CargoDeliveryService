namespace CargoDeliveryBlog.Domain.Likes.Mappings;

using CargoDeliveryBlog.Domain.Likes.Dtos;
using CargoDeliveryBlog.Domain.Likes.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class LikeMapper
{
    public static partial LikeForCreation ToLikeForCreation(this LikeForCreationDto likeForCreationDto);
    public static partial LikeForUpdate ToLikeForUpdate(this LikeForUpdateDto likeForUpdateDto);
    public static partial LikeDto ToLikeDto(this Like like);
    public static partial IQueryable<LikeDto> ToLikeDtoQueryable(this IQueryable<Like> like);
}