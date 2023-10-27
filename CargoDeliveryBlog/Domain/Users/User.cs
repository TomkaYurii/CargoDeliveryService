namespace CargoDeliveryBlog.Domain.Users;

using System.ComponentModel.DataAnnotations;
using CargoDeliveryBlog.Domain.Comments;
using CargoDeliveryBlog.Domain.BlogPosts;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using CargoDeliveryBlog.Exceptions;
using CargoDeliveryBlog.Domain.Users.Models;
using CargoDeliveryBlog.Domain.Users.DomainEvents;


public class User : BaseEntity
{
    public string UserName { get; private set; }

    public string Email { get; private set; }

    public BlogPost BlogPost { get; }

    public Comment Comment { get; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static User Create(UserForCreation userForCreation)
    {
        var newUser = new User();

        newUser.UserName = userForCreation.UserName;
        newUser.Email = userForCreation.Email;

        newUser.QueueDomainEvent(new UserCreated(){ User = newUser });
        
        return newUser;
    }

    public User Update(UserForUpdate userForUpdate)
    {
        UserName = userForUpdate.UserName;
        Email = userForUpdate.Email;

        QueueDomainEvent(new UserUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected User() { } // For EF + Mocking
}
