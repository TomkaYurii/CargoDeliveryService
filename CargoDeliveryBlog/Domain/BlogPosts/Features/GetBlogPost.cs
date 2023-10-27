namespace CargoDeliveryBlog.Domain.BlogPosts.Features;

using CargoDeliveryBlog.Domain.BlogPosts.Dtos;
using CargoDeliveryBlog.Domain.BlogPosts.Services;
using CargoDeliveryBlog.Exceptions;
using Mappings;
using MediatR;

public static class GetBlogPost
{
    public sealed record Query(Guid BlogPostId) : IRequest<BlogPostDto>;

    public sealed class Handler : IRequestHandler<Query, BlogPostDto>
    {
        private readonly IBlogPostRepository _blogPostRepository;

        public Handler(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public async Task<BlogPostDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await _blogPostRepository.GetById(request.BlogPostId, cancellationToken: cancellationToken);
            return result.ToBlogPostDto();
        }
    }
}