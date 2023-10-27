namespace CargoDeliveryBlog.Domain.BlogPosts.Features;

using CargoDeliveryBlog.Domain.BlogPosts.Dtos;
using CargoDeliveryBlog.Domain.BlogPosts.Services;
using CargoDeliveryBlog.Wrappers;
using CargoDeliveryBlog.Exceptions;
using CargoDeliveryBlog.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetBlogPostList
{
    public sealed record Query(BlogPostParametersDto QueryParameters) : IRequest<PagedList<BlogPostDto>>;

    public sealed class Handler : IRequestHandler<Query, PagedList<BlogPostDto>>
    {
        private readonly IBlogPostRepository _blogPostRepository;

        public Handler(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public async Task<PagedList<BlogPostDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = _blogPostRepository.Query().AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToBlogPostDtoQueryable();

            return await PagedList<BlogPostDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}