using ApiCompras.Domain.Validation;

namespace ApiCompras.Domain.Entities;

public sealed class UserPermission
{
    public UserPermission(int userId, int permissionId)
    {
        Validation(userId, permissionId);
    }

    public int Id { get; private set; }
    public int UserId { get; private set; }
    public User User { get; set; }
    public int PermissionId { get; private set; }    
    public Permission Permission { get; set; }

    private void Validation(int userId, int permissionId)
    {
        DomainValidationException
            .When(userId <= 0, "UserId deve ser informado");
        DomainValidationException
           .When(permissionId <= 0, "PermissionId deve ser informado");
       
        UserId = userId;
        PermissionId = permissionId;
    }
}
