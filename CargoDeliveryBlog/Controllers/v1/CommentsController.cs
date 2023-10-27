namespace CargoDeliveryBlog.Controllers.v1;

using CargoDeliveryBlog.Domain.Comments.Features;
using CargoDeliveryBlog.Domain.Comments.Dtos;
using CargoDeliveryBlog.Wrappers;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using System.Threading;
using MediatR;

[ApiController]
[Route("api/comments")]
[ApiVersion("1.0")]
public sealed class CommentsController: ControllerBase
{
    private readonly IMediator _mediator;

    public CommentsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    

    /// <summary>
    /// Creates a new Comment record.
    /// </summary>
    [HttpPost(Name = "AddComment")]
    public async Task<ActionResult<CommentDto>> AddComment([FromBody]CommentForCreationDto commentForCreation)
    {
        var command = new AddComment.Command(commentForCreation);
        var commandResponse = await _mediator.Send(command);

        return CreatedAtRoute("GetComment",
            new { commentId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single Comment by ID.
    /// </summary>
    [HttpGet("{commentId:guid}", Name = "GetComment")]
    public async Task<ActionResult<CommentDto>> GetComment(Guid commentId)
    {
        var query = new GetComment.Query(commentId);
        var queryResponse = await _mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all Comments.
    /// </summary>
    [HttpGet(Name = "GetComments")]
    public async Task<IActionResult> GetComments([FromQuery] CommentParametersDto commentParametersDto)
    {
        var query = new GetCommentList.Query(commentParametersDto);
        var queryResponse = await _mediator.Send(query);

        var paginationMetadata = new
        {
            totalCount = queryResponse.TotalCount,
            pageSize = queryResponse.PageSize,
            currentPageSize = queryResponse.CurrentPageSize,
            currentStartIndex = queryResponse.CurrentStartIndex,
            currentEndIndex = queryResponse.CurrentEndIndex,
            pageNumber = queryResponse.PageNumber,
            totalPages = queryResponse.TotalPages,
            hasPrevious = queryResponse.HasPrevious,
            hasNext = queryResponse.HasNext
        };

        Response.Headers.Add("X-Pagination",
            JsonSerializer.Serialize(paginationMetadata));

        return Ok(queryResponse);
    }


    /// <summary>
    /// Updates an entire existing Comment.
    /// </summary>
    [HttpPut("{commentId:guid}", Name = "UpdateComment")]
    public async Task<IActionResult> UpdateComment(Guid commentId, CommentForUpdateDto comment)
    {
        var command = new UpdateComment.Command(commentId, comment);
        await _mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing Comment record.
    /// </summary>
    [HttpDelete("{commentId:guid}", Name = "DeleteComment")]
    public async Task<ActionResult> DeleteComment(Guid commentId)
    {
        var command = new DeleteComment.Command(commentId);
        await _mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}
