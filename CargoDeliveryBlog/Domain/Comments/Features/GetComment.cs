namespace CargoDeliveryBlog.Domain.Comments.Features;

using CargoDeliveryBlog.Domain.Comments.Dtos;
using CargoDeliveryBlog.Domain.Comments.Services;
using CargoDeliveryBlog.Exceptions;
using Mappings;
using MediatR;

public static class GetComment
{
    public sealed record Query(Guid CommentId) : IRequest<CommentDto>;

    public sealed class Handler : IRequestHandler<Query, CommentDto>
    {
        private readonly ICommentRepository _commentRepository;

        public Handler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<CommentDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await _commentRepository.GetById(request.CommentId, cancellationToken: cancellationToken);
            return result.ToCommentDto();
        }
    }
}