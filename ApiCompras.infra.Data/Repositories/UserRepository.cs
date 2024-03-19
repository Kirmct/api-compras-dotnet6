using ApiCompras.Domain.Entities;
using ApiCompras.Domain.Repositories;
using ApiCompras.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiCompras.Infra.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApiDbContext _db;

    public UserRepository(ApiDbContext db)
    {
        _db = db;
    }

    public async Task<User> GetUserByEmailAndPasswordAsync(
        string email, 
        string password)
    {
        return await _db.Users.FirstOrDefaultAsync(x =>
                        x.Email == email && x.Password == password);        
    }
}
