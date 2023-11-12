namespace DriversManagement.SharedTestHelpers.Fakes.RolePermission;

using AutoBogus;
using DriversManagement.Domain;
using DriversManagement.Domain.RolePermissions.Dtos;
using DriversManagement.Domain.Roles;
using DriversManagement.Domain.RolePermissions.Models;

public sealed class FakeRolePermissionForCreation : AutoFaker<RolePermissionForCreation>
{
    public FakeRolePermissionForCreation()
    {
        RuleFor(rp => rp.Permission, f => f.PickRandom(Permissions.List()));
        RuleFor(rp => rp.Role, f => f.PickRandom(Role.ListNames()));
    }
}