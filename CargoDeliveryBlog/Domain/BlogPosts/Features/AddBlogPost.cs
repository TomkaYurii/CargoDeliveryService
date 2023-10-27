namespace CargoDeliveryBlog.Domain.BlogPosts.Features;

using CargoDeliveryBlog.Domain.BlogPosts.Services;
using CargoDeliveryBlog.Domain.BlogPosts;
using CargoDeliveryBlog.Domain.BlogPosts.Dtos;
using CargoDeliveryBlog.Domain.BlogPosts.Models;
using CargoDeliveryBlog.Services;
using CargoDeliveryBlog.Exceptions;
using Mappings;
using MediatR;

public static class AddBlogPost
{
    public sealed record Command(BlogPostForCreationDto BlogPostToAdd) : IRequest<BlogPostDto>;

    public sealed class Handler : IRequestHandler<Command, BlogPostDto>
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IBlogPostRepository blogPostRepository, IUnitOfWork unitOfWork)
        {
            _blogPostRepository = blogPostRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BlogPostDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var blogPostToAdd = request.BlogPostToAdd.ToBlogPostForCreation();
            var blogPost = BlogPost.Create(blogPostToAdd);

            await _blogPostRepository.Add(blogPost, cancellationToken);
            await _unitOfWork.CommitChanges(cancellationToken);

            return blogPost.ToBlogPostDto();
        }
    }
}