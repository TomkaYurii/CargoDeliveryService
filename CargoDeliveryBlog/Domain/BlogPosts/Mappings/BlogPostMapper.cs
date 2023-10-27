namespace CargoDeliveryBlog.Domain.BlogPosts.Mappings;

using CargoDeliveryBlog.Domain.BlogPosts.Dtos;
using CargoDeliveryBlog.Domain.BlogPosts.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class BlogPostMapper
{
    public static partial BlogPostForCreation ToBlogPostForCreation(this BlogPostForCreationDto blogPostForCreationDto);
    public static partial BlogPostForUpdate ToBlogPostForUpdate(this BlogPostForUpdateDto blogPostForUpdateDto);
    public static partial BlogPostDto ToBlogPostDto(this BlogPost blogPost);
    public static partial IQueryable<BlogPostDto> ToBlogPostDtoQueryable(this IQueryable<BlogPost> blogPost);
}