namespace CargoDeliveryBlog.Domain.Likes;

using System.ComponentModel.DataAnnotations;
using CargoDeliveryBlog.Domain.BlogPosts;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using CargoDeliveryBlog.Exceptions;
using CargoDeliveryBlog.Domain.Likes.Models;
using CargoDeliveryBlog.Domain.Likes.DomainEvents;


public class Like : BaseEntity
{
    public string Text { get; private set; }

    public BlogPost BlogPost { get; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static Like Create(LikeForCreation likeForCreation)
    {
        var newLike = new Like();

        newLike.Text = likeForCreation.Text;

        newLike.QueueDomainEvent(new LikeCreated(){ Like = newLike });
        
        return newLike;
    }

    public Like Update(LikeForUpdate likeForUpdate)
    {
        Text = likeForUpdate.Text;

        QueueDomainEvent(new LikeUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected Like() { } // For EF + Mocking
}
