using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class UserRepository(AppDbContext db) : IUserRepository
{
    public Task<Users?> GetByIdAsync(Guid id) =>
        db.Users.FirstOrDefaultAsync(u => u.Id == id);

    public Task<Users?> GetByEmailAsync(string email) =>
        db.Users.FirstOrDefaultAsync(u => u.Email == email);

    public async Task AddAsync(Users user)
    {
        db.Users.Add(user);
        await db.SaveChangesAsync();
    }
}
