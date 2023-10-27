namespace CargoDeliveryBlog.Domain.Comments.Features;

using CargoDeliveryBlog.Domain.Comments.Services;
using CargoDeliveryBlog.Services;
using CargoDeliveryBlog.Exceptions;
using MediatR;

public static class DeleteComment
{
    public sealed record Command(Guid CommentId) : IRequest;

    public sealed class Handler : IRequestHandler<Command>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await _commentRepository.GetById(request.CommentId, cancellationToken: cancellationToken);
            _commentRepository.Remove(recordToDelete);
            await _unitOfWork.CommitChanges(cancellationToken);
        }
    }
}