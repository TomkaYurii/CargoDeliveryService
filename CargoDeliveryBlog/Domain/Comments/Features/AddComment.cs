namespace CargoDeliveryBlog.Domain.Comments.Features;

using CargoDeliveryBlog.Domain.Comments.Services;
using CargoDeliveryBlog.Domain.Comments;
using CargoDeliveryBlog.Domain.Comments.Dtos;
using CargoDeliveryBlog.Domain.Comments.Models;
using CargoDeliveryBlog.Services;
using CargoDeliveryBlog.Exceptions;
using Mappings;
using MediatR;

public static class AddComment
{
    public sealed record Command(CommentForCreationDto CommentToAdd) : IRequest<CommentDto>;

    public sealed class Handler : IRequestHandler<Command, CommentDto>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CommentDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var commentToAdd = request.CommentToAdd.ToCommentForCreation();
            var comment = Comment.Create(commentToAdd);

            await _commentRepository.Add(comment, cancellationToken);
            await _unitOfWork.CommitChanges(cancellationToken);

            return comment.ToCommentDto();
        }
    }
}