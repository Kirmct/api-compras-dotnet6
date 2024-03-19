using ApiCompras.Domain.Entities;

namespace ApiCompras.Domain.Authentication;

public interface ITokenGenerator
{
    dynamic Generator(User user);
}
