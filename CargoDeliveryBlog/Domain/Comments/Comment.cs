namespace CargoDeliveryBlog.Domain.Comments;

using System.ComponentModel.DataAnnotations;
using CargoDeliveryBlog.Domain.Users;
using CargoDeliveryBlog.Domain.Users.Models;
using CargoDeliveryBlog.Domain.BlogPosts;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using CargoDeliveryBlog.Exceptions;
using CargoDeliveryBlog.Domain.Comments.Models;
using CargoDeliveryBlog.Domain.Comments.DomainEvents;
using CargoDeliveryBlog.Domain.Users;
using CargoDeliveryBlog.Domain.Users.Models;


public class Comment : BaseEntity
{
    public string Text { get; private set; }

    public BlogPost BlogPost { get; }

    public User User { get; private set; } = User.Create(new UserForCreation());

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static Comment Create(CommentForCreation commentForCreation)
    {
        var newComment = new Comment();

        newComment.Text = commentForCreation.Text;

        newComment.QueueDomainEvent(new CommentCreated(){ Comment = newComment });
        
        return newComment;
    }

    public Comment Update(CommentForUpdate commentForUpdate)
    {
        Text = commentForUpdate.Text;

        QueueDomainEvent(new CommentUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected Comment() { } // For EF + Mocking
}
