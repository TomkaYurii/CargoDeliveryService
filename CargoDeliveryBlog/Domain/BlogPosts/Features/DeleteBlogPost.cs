namespace CargoDeliveryBlog.Domain.BlogPosts.Features;

using CargoDeliveryBlog.Domain.BlogPosts.Services;
using CargoDeliveryBlog.Services;
using CargoDeliveryBlog.Exceptions;
using MediatR;

public static class DeleteBlogPost
{
    public sealed record Command(Guid BlogPostId) : IRequest;

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
            var recordToDelete = await _blogPostRepository.GetById(request.BlogPostId, cancellationToken: cancellationToken);
            _blogPostRepository.Remove(recordToDelete);
            await _unitOfWork.CommitChanges(cancellationToken);
        }
    }
}