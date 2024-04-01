using ApiCompras.Domain.Validation;

namespace ApiCompras.Domain.Entities;

public sealed class Permission
{
    public Permission(
        string visualName, 
        string permissionName)
    {
        Validation(visualName, permissionName);
        UserPermissions = new List<UserPermission>();
    }

    public int Id { get; private set; }
    public string VisualName { get; private set; }
    public string PermissionName { get; private set; }
    public ICollection<UserPermission> UserPermissions { get; set; }

    private void Validation(
        string visualName, 
        string permissionName)
    {
        DomainValidationException
            .When(string.IsNullOrEmpty(visualName), "VisualName inválido!");
        
        DomainValidationException
            .When(string.IsNullOrEmpty(permissionName), "PermissionName inválido!");

        VisualName = visualName;
        PermissionName = permissionName;
    }
    
}
