namespace CargoDeliveryBlog.Domain.Drivers;

using System.ComponentModel.DataAnnotations;
using CargoDeliveryBlog.Domain.BlogPosts;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using CargoDeliveryBlog.Exceptions;
using CargoDeliveryBlog.Domain.Drivers.Models;
using CargoDeliveryBlog.Domain.Drivers.DomainEvents;


public class Driver : BaseEntity
{
    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public BlogPost BlogPost { get; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static Driver Create(DriverForCreation driverForCreation)
    {
        var newDriver = new Driver();

        newDriver.FirstName = driverForCreation.FirstName;
        newDriver.LastName = driverForCreation.LastName;

        newDriver.QueueDomainEvent(new DriverCreated(){ Driver = newDriver });
        
        return newDriver;
    }

    public Driver Update(DriverForUpdate driverForUpdate)
    {
        FirstName = driverForUpdate.FirstName;
        LastName = driverForUpdate.LastName;

        QueueDomainEvent(new DriverUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected Driver() { } // For EF + Mocking
}
