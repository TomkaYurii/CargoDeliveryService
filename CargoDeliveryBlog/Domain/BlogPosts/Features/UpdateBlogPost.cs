namespace CargoDeliveryBlog.Domain.BlogPosts.Features;

using CargoDeliveryBlog.Domain.BlogPosts;
using CargoDeliveryBlog.Domain.BlogPosts.Dtos;
using CargoDeliveryBlog.Domain.BlogPosts.Services;
using CargoDeliveryBlog.Services;
using CargoDeliveryBlog.Domain.BlogPosts.Models;
using CargoDeliveryBlog.Exceptions;
using Mappings;
using MediatR;

public static class UpdateBlogPost
{
    public sealed record Command(Guid BlogPostId, BlogPostForUpdateDto UpdatedBlogPostData) : IRequest;

    public sealed class Handler : IRequestHandler<Command>
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IBlogPostRepository blogPostRepository, IUnitOfWork unitOfWork)
        {
            _blogPostRepository = blogPostRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var blogPostToUpdate = await _blogPostRepository.GetById(request.BlogPostId, cancellationToken: cancellationToken);
            var blogPostToAdd = request.UpdatedBlogPostData.ToBlogPostForUpdate();
            blogPostToUpdate.Update(blogPostToAdd);

            _blogPostRepository.Update(blogPostToUpdate);
            await _unitOfWork.CommitChanges(cancellationToken);
        }
    }
}