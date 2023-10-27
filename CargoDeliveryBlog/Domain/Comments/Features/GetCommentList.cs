namespace CargoDeliveryBlog.Domain.Comments.Features;

using CargoDeliveryBlog.Domain.Comments.Dtos;
using CargoDeliveryBlog.Domain.Comments.Services;
using CargoDeliveryBlog.Wrappers;
using CargoDeliveryBlog.Exceptions;
using CargoDeliveryBlog.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetCommentList
{
    public sealed record Query(CommentParametersDto QueryParameters) : IRequest<PagedList<CommentDto>>;

    public sealed class Handler : IRequestHandler<Query, PagedList<CommentDto>>
    {
        private readonly ICommentRepository _commentRepository;

        public Handler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<PagedList<CommentDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = _commentRepository.Query().AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToCommentDtoQueryable();

            return await PagedList<CommentDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}