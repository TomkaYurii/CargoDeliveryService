namespace CargoDeliveryBlog.Domain.BlogPosts;

using System.ComponentModel.DataAnnotations;
using CargoDeliveryBlog.Domain.Likes;
using CargoDeliveryBlog.Domain.Comments;
using CargoDeliveryBlog.Domain.Users;
using CargoDeliveryBlog.Domain.Users.Models;
using CargoDeliveryBlog.Domain.Drivers;
using CargoDeliveryBlog.Domain.Drivers.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using CargoDeliveryBlog.Exceptions;
using CargoDeliveryBlog.Domain.BlogPosts.Models;
using CargoDeliveryBlog.Domain.BlogPosts.DomainEvents;
using CargoDeliveryBlog.Domain.Drivers;
using CargoDeliveryBlog.Domain.Drivers.Models;
using CargoDeliveryBlog.Domain.Users;
using CargoDeliveryBlog.Domain.Users.Models;
using CargoDeliveryBlog.Domain.Comments;
using CargoDeliveryBlog.Domain.Comments.Models;
using CargoDeliveryBlog.Domain.Likes;
using CargoDeliveryBlog.Domain.Likes.Models;


public class BlogPost : BaseEntity
{
    public string Title { get; private set; }

    public string Content { get; private set; }

    public Driver Driver { get; private set; } = Driver.Create(new DriverForCreation());

    public User User { get; private set; } = User.Create(new UserForCreation());

    private readonly List<Comment> _comments = new();
    public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();

    private readonly List<Like> _likes = new();
    public IReadOnlyCollection<Like> Likes => _likes.AsReadOnly();

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static BlogPost Create(BlogPostForCreation blogPostForCreation)
    {
        var newBlogPost = new BlogPost();

        newBlogPost.Title = blogPostForCreation.Title;
        newBlogPost.Content = blogPostForCreation.Content;

        newBlogPost.QueueDomainEvent(new BlogPostCreated(){ BlogPost = newBlogPost });
        
        return newBlogPost;
    }

    public BlogPost Update(BlogPostForUpdate blogPostForUpdate)
    {
        Title = blogPostForUpdate.Title;
        Content = blogPostForUpdate.Content;

        QueueDomainEvent(new BlogPostUpdated(){ Id = Id });
        return this;
    }

    public BlogPost AddComment(Comment comment)
    {
        _comments.Add(comment);
        return this;
    }
    
    public BlogPost RemoveComment(Comment comment)
    {
        _comments.RemoveAll(x => x.Id == comment.Id);
        return this;
    }

    public BlogPost AddLike(Like like)
    {
        _likes.Add(like);
        return this;
    }
    
    public BlogPost RemoveLike(Like like)
    {
        _likes.RemoveAll(x => x.Id == like.Id);
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected BlogPost() { } // For EF + Mocking
}
