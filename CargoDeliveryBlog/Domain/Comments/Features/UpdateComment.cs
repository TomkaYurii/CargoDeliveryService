namespace CargoDeliveryBlog.Domain.Comments.Features;

using CargoDeliveryBlog.Domain.Comments;
using CargoDeliveryBlog.Domain.Comments.Dtos;
using CargoDeliveryBlog.Domain.Comments.Services;
using CargoDeliveryBlog.Services;
using CargoDeliveryBlog.Domain.Comments.Models;
using CargoDeliveryBlog.Exceptions;
using Mappings;
using MediatR;

public static class UpdateComment
{
    public sealed record Command(Guid CommentId, CommentForUpdateDto UpdatedCommentData) : IRequest;

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
            var commentToUpdate = await _commentRepository.GetById(request.CommentId, cancellationToken: cancellationToken);
            var commentToAdd = request.UpdatedCommentData.ToCommentForUpdate();
            commentToUpdate.Update(commentToAdd);

            _commentRepository.Update(commentToUpdate);
            await _unitOfWork.CommitChanges(cancellationToken);
        }
    }
}