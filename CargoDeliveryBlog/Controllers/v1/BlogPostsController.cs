namespace CargoDeliveryBlog.Controllers.v1;

using CargoDeliveryBlog.Domain.BlogPosts.Features;
using CargoDeliveryBlog.Domain.BlogPosts.Dtos;
using CargoDeliveryBlog.Wrappers;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using System.Threading;
using MediatR;

[ApiController]
[Route("api/blogposts")]
[ApiVersion("1.0")]
public sealed class BlogPostsController: ControllerBase
{
    private readonly IMediator _mediator;

    public BlogPostsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    

    /// <summary>
    /// Creates a new BlogPost record.
    /// </summary>
    [HttpPost(Name = "AddBlogPost")]
    public async Task<ActionResult<BlogPostDto>> AddBlogPost([FromBody]BlogPostForCreationDto blogPostForCreation)
    {
        var command = new AddBlogPost.Command(blogPostForCreation);
        var commandResponse = await _mediator.Send(command);

        return CreatedAtRoute("GetBlogPost",
            new { blogPostId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single BlogPost by ID.
    /// </summary>
    [HttpGet("{blogPostId:guid}", Name = "GetBlogPost")]
    public async Task<ActionResult<BlogPostDto>> GetBlogPost(Guid blogPostId)
    {
        var query = new GetBlogPost.Query(blogPostId);
        var queryResponse = await _mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all BlogPosts.
    /// </summary>
    [HttpGet(Name = "GetBlogPosts")]
    public async Task<IActionResult> GetBlogPosts([FromQuery] BlogPostParametersDto blogPostParametersDto)
    {
        var query = new GetBlogPostList.Query(blogPostParametersDto);
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
    /// Updates an entire existing BlogPost.
    /// </summary>
    [HttpPut("{blogPostId:guid}", Name = "UpdateBlogPost")]
    public async Task<IActionResult> UpdateBlogPost(Guid blogPostId, BlogPostForUpdateDto blogPost)
    {
        var command = new UpdateBlogPost.Command(blogPostId, blogPost);
        await _mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing BlogPost record.
    /// </summary>
    [HttpDelete("{blogPostId:guid}", Name = "DeleteBlogPost")]
    public async Task<ActionResult> DeleteBlogPost(Guid blogPostId)
    {
        var command = new DeleteBlogPost.Command(blogPostId);
        await _mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}
