namespace CargoOrderingService.Domain.RolePermissions.DomainEvents;

public sealed class RolePermissionUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            