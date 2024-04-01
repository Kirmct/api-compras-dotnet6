using ApiCompras.Domain.Authentication;

namespace ApiCompras.Api.Authentication;

public class CurrentUser : ICurrentUser
{
    public CurrentUser(IHttpContextAccessor accessor)
    {
        var httpContext = accessor.HttpContext;
        var claims = httpContext.User.Claims;

        if (claims.Any(x => x.Type == "Id"))
        {
            var id = Convert.ToInt32(claims.First(x => x.Type == "Id").Value);
            Id = id;
        }

        if (claims.Any(x => x.Type == "Id"))
        {
            var email = claims.First(x => x.Type == "Email").Value;
            Email = email;
        }

        if (claims.Any(x => x.Type == "Id"))
        {
            var permissions = claims.First(x => x.Type == "Permissoes").Value;
            Permissions = permissions;
        }

    }

    public int Id { get ; set ; }
    public string Email { get ; set ; }
    public string Permissions { get ; set ; }
}
