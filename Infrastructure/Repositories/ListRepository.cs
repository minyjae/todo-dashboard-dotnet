using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ListRepository(AppDbContext db) : IListRepository
{
    public Task<IEnumerable<Lists>> GetByUserIdAsync(Guid userId) =>
        Task.FromResult(db.Lists.Where(l => l.UserId == userId).AsEnumerable());

    public Task<Lists?> GetByIdAsync(Guid id) =>
        db.Lists.FirstOrDefaultAsync(l => l.Id == id);

    public async Task AddAsync(Lists list)
    {
        db.Lists.Add(list);
        await db.SaveChangesAsync();
    }

    public async Task UpdateAsync(Lists list)
    {
        db.Lists.Update(list);
        await db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var list = await db.Lists.FindAsync(id);
        if (list is not null)
        {
            db.Lists.Remove(list);
            await db.SaveChangesAsync();
        }
    }
}
