using ApiCompras.Domain.Entities;

namespace ApiCompras.Domain.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserByEmailAndPasswordAsync(string email, string password);
}
